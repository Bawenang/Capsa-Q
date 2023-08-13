using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerTurnState", menuName = "ScriptableObjects/PlayerTurnState", order = 5)]
public class PlayerTurnState : FSM.State
{
    public class Properties 
    {
        public MainGameView mainGameView;
        public GameRepository repository;
    }

    public PlayerType playerType;
    private Properties props;
    private int nextTransition = -1;

    public override void Setup(object properties)
    {
        Debug.Log("PlayerTurnState Setup! player: " + playerType);
        nextTransition = -1;
        props = properties as Properties;
        if (props == null) {
            Debug.LogError("Properties invalid! Should be of PlayerTurnState.Properties type.");
            return;
        }

        var player = props.repository.GetPlayer(playerType);
        props.mainGameView.ActivatePlayer(playerType, true);

        DoAIAction(props, player);
    }

    public override void CleanUp()
    {
        var player = props.repository.GetPlayer(playerType);
        props.mainGameView.ActivatePlayer(playerType, false);
    }

    protected override int CheckTransition()
    {
        return nextTransition; //TEST next turn!
    }

    protected override void DoUpdateAction()
    {
    }

    private IEnumerator NextTurn() 
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("PlayerTurnState NextTurn! player: " + playerType);
        nextTransition = 0;
    }

    private void DoAIAction(Properties props, Player player)
    {
        var aiPlayer = player as AIPlayer;

        if(aiPlayer != null)
        {
            var playedSet = props.repository.GetTopPlayedCards();
            if(props.repository.GetTopPlayedCards().Type == CardSetFactory.Invalid.Type) {
                var selectedCard = CardUtils.GetSingularCardSet(0, player.Cards.ToArray());
                PlayCard(selectedCard, player);
            } else {
                var selectedCard = aiPlayer.SelectPlayCardSet(playedSet);
                if (selectedCard.Type == CardSetFactory.Invalid.Type) {
                    PassTurn();
                } else {
                    PlayCard(selectedCard, player);
                }
            }
            props.mainGameView.StartCoroutine(NextTurn());
        } else {
            props.mainGameView.StartCoroutine(NextTurn());
        }
    }

    private void PlayCard(CardSet playSet, Player player)
    {
        props.mainGameView.PlaySet(playSet);
        props.repository.AddPlayedCard(playSet);
        player.RemoveCards(playSet);
        props.mainGameView.UpdateCards(player.Type, player.Cards.ToArray());
        props.repository.lastPlaying = playerType;
    }

    private void PassTurn()
    {
        props.mainGameView.PassTurn();
    }

}
