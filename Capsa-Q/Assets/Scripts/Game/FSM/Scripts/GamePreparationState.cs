using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "GamePreparationState", menuName = "ScriptableObjects/GamePreparationState", order = 3)]
public class GamePreparationState : FSM.State
{
    public class Properties 
    {
        public MainGameView mainGameView;
        public GameRepository repository;
        public CharacterData selectedCharacter;
        public CharacterData[] allCharacters;
    }

    private Properties properties;
    private int nextTransition = -1;
    public override void CleanUp()
    {
    }

    public override void Setup(object properties)
    {
        Properties props = properties as Properties;
        if (props == null) {
            Debug.LogError("Properties invalid! Should be of GamePreparationState.Properties type.");
            return;
        }
        
        var aiCharacters = CreateAICharacterData(props.selectedCharacter, props.allCharacters);
        var shuffler = new CardShuffler();
        var dealtCards = shuffler.ShuffleAndDeal();

        var cardSelector = CreateCardSelector();

        var selectedPlayer = new BasePlayer(PlayerType.Player1, 
                                            props.selectedCharacter,
                                            dealtCards[(int)PlayerType.Player1]);

        var aiPlayer1 = new AIPlayer(PlayerType.Player2,
                                     aiCharacters[0],
                                     dealtCards[(int)PlayerType.Player2],
                                     cardSelector);

        var aiPlayer2 = new AIPlayer(PlayerType.Player3,
                                     aiCharacters[1],
                                     dealtCards[(int)PlayerType.Player3],
                                     cardSelector);

        var aiPlayer3 = new AIPlayer(PlayerType.Player4,
                                     aiCharacters[2],
                                     dealtCards[(int)PlayerType.Player4],
                                     cardSelector);

        props.repository.AddPlayer(PlayerType.Player1, selectedPlayer);
        props.repository.AddPlayer(PlayerType.Player2, aiPlayer1);
        props.repository.AddPlayer(PlayerType.Player3, aiPlayer2);
        props.repository.AddPlayer(PlayerType.Player4, aiPlayer3);

        props.mainGameView.InitiatePlayer(selectedPlayer);
        props.mainGameView.InitiatePlayer(aiPlayer1);
        props.mainGameView.InitiatePlayer(aiPlayer2);
        props.mainGameView.InitiatePlayer(aiPlayer3);

        for(int i = 0; i < dealtCards.Length; i++) {
            if(Array.Exists(dealtCards[i], card => card.CardValue == 0)) {
                nextTransition = i;
            }
        }
    }

    protected override int CheckTransition()
    {
        return nextTransition;
    }

    protected override void DoUpdateAction()
    {
    }

    private CharacterData[] CreateAICharacterData(CharacterData exceptPlayer, CharacterData[] allCharacters) 
    {
        List<CharacterData> charList = new List<CharacterData>(allCharacters);
        charList.RemoveAll(character => character.charName == exceptPlayer.charName);
        return Shuffle(charList);
    }

    private static CharacterData[] Shuffle(List<CharacterData> charList)
    {
        System.Random r = new System.Random();
        
        for (int n = charList.Count - 1; n > 0; --n)
        {
            int k = r.Next(n + 1);

            CharacterData temp = charList[n];
            charList[n] = charList[k];
            charList[k] = temp;
        }

        return charList.Take(3).ToArray();
    }

    private CardSelecting CreateCardSelector()
    {
        var oneCardStrategy = new HigherOneCardStrategy();
        var twoCardStrategy = new HigherTwoCardsStrategy();
        var threeCardStrategy = new HigherThreeCardsStrategy();
        var fiveCardStrategy = new HigherFiveCardsStrategy();
        var strategies = new HigherCardSetStrategy[] {
            oneCardStrategy,
            twoCardStrategy,
            threeCardStrategy,
            fiveCardStrategy
        };
        var cardSelector = new CardSelector(strategies: strategies);
        return cardSelector;
    }
}
