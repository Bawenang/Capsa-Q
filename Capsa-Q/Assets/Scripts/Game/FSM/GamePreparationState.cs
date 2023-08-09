using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "State", menuName = "ScriptableObjects/GamePreparationState", order = 2)]
public class GamePreparationState : FSM.State
{
    public delegate void OnPopulateGame(GameRepository repository);
    public event OnPopulateGame onPopulateGame;

    public class Properties 
    {
        public CharacterData selectedCharacter;
        public CharacterData[] allCharacters;
        public OnPopulateGame onPopulateGame;
    }

    private Properties properties;
    public override void CleanUp()
    {
        onPopulateGame = null;
    }

    public override void Setup(object properties)
    {
        Properties props = properties as Properties;
        if (props == null) {
            Debug.LogError("Properties invalid! Should be of GamePreparationState.Properties type.");
            return;
        }

        onPopulateGame += props.onPopulateGame;
        
        var aiCharacters = CreateAICharacterData(props.selectedCharacter, props.allCharacters);
        var shuffler = new CardShuffler();
        var dealtCards = shuffler.ShuffleAndDeal();

        var selectedCharacter = new BasePlayer(PlayerType.Player1, 
                                               props.selectedCharacter,
                                               dealtCards[(int)PlayerType.Player1]);

        var aiCharacters1 = new BasePlayer(PlayerType.Player2,
                                           aiCharacters[0],
                                           dealtCards[(int)PlayerType.Player2]);

        var aiCharacters2 = new BasePlayer(PlayerType.Player3,
                                           aiCharacters[1],
                                           dealtCards[(int)PlayerType.Player3]);

        var aiCharacters3 = new BasePlayer(PlayerType.Player4,
                                           aiCharacters[2],
                                           dealtCards[(int)PlayerType.Player4]);

        var repository = new GameRepository();

        repository.AddPlayer(PlayerType.Player1, selectedCharacter);
        repository.AddPlayer(PlayerType.Player2, aiCharacters1);
        repository.AddPlayer(PlayerType.Player3, aiCharacters2);
        repository.AddPlayer(PlayerType.Player4, aiCharacters3);

        if(onPopulateGame != null) onPopulateGame(repository);
    }

    protected override int CheckTransition()
    {
        return -1;
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
}
