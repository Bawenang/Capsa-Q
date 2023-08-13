using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerTurnState", menuName = "ScriptableObjects/PlayerTurnState", order = 4)]
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
        props.mainGameView.StartCoroutine(NextTurn());
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
        yield return new WaitForSeconds(3f);
        Debug.Log("PlayerTurnState NextTurn! player: " + playerType);
        nextTransition = 0;
    }

    private void DoAIAction(Properties props, Player player)
    {
        var aiPlayer = player as AIPlayer;

        if(aiPlayer != null)
        {
            var playedSet = props.repository.GetTopPlayedCards();
            var selectedCard = aiPlayer.SelectPlayCardSet(playedSet);
            if(selectedCard.Type == CardSetFactory.Invalid.Type) {
                props.mainGameView.PassTurn();
            } else {
                props.mainGameView.PlaySet(selectedCard);
            }
        }
    }
}
