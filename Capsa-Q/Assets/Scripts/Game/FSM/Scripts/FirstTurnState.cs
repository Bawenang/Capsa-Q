using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FirstTurnState", menuName = "ScriptableObjects/FirstTurnState", order = 4)]
public class FirstTurnState : FSM.State
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

    private void DoAIAction(Properties props, Player player)
    {
        var aiPlayer = player as AIPlayer;

        if(aiPlayer != null)
        {
            var selectedCard = CardUtils.GetSingularCardSet(0, aiPlayer.Cards.ToArray());
            props.mainGameView.StartCoroutine(PlayCard(selectedCard, aiPlayer));
        }
    }

    private IEnumerator PlayCard(CardSet playSet, Player player)
    {
        yield return new WaitForSeconds(2f);
        props.mainGameView.PlaySet(playSet);
        props.repository.AddPlayedCard(playSet);
        player.RemoveCards(playSet);
        props.mainGameView.UpdateCards(player.Type, player.Cards.ToArray());
        props.repository.lastPlaying = playerType;
        nextTransition = 0;
    }
}