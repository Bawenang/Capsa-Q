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
        props.mainGameView.ShowPassText(false);
        props.mainGameView.ActivatePassButton(false);

        PlayerAction(props, player);
    }

    public override void CleanUp()
    {
        var player = props.repository.GetPlayer(playerType);
        props.mainGameView.ActivatePlayer(playerType, false);

        var aiPlayer = player as AIPlayer;
        if(aiPlayer == null) {
            props.mainGameView.onSelectedCardSet -= CheckValidity;
            props.mainGameView.onPlayCardSet -= PlaySelectedCard;
            props.mainGameView.ShowButtons(false);
        }
    }

    protected override int CheckTransition()
    {
        return nextTransition; //TEST next turn!
    }

    protected override void DoUpdateAction()
    {
    }

    private void PlayerAction(Properties props, IPlayer player)
    {
        var aiPlayer = player as AIPlayer;

        if(aiPlayer == null) {
            props.mainGameView.onSelectedCardSet += CheckValidity;
            props.mainGameView.onPlayCardSet += PlaySelectedCard;
            props.mainGameView.ShowButtons(true);
        } else {
            props.mainGameView.ShowButtons(false);
            var selectedCard = CardUtils.GetSingularCardSet(0, aiPlayer.Cards.ToArray());
            props.mainGameView.StartCoroutine(PlayCard(selectedCard, aiPlayer, 2f));
        }
    }

    private IEnumerator PlayCard(CardSet playSet, IPlayer player, float waitDuration)
    {
        yield return new WaitForSeconds(waitDuration);
        props.mainGameView.PlaySet(playSet);
        props.repository.AddPlayedCard(playSet);
        player.RemoveCards(playSet);
        props.mainGameView.UpdateCards(player.Type, player.Cards.ToArray());
        props.repository.lastPlaying = playerType;
        nextTransition = 0;
    }

    private void CheckValidity(CardSet selectedCardSet)
    {
        var isPlaySetButtonActive = selectedCardSet.SetType == CardSetType.Singular &&
                                    selectedCardSet.Cards[0].CardNumber == CardElement.Number.Three &&
                                    selectedCardSet.Cards[0].CardSuite == CardElement.Suite.Diamond;
        props.mainGameView.ActivatePlaySetButton(isPlaySetButtonActive);
    }

    private void PlaySelectedCard(CardSet selectedCardSet)
    {
        var player = props.repository.GetPlayer(playerType);
        props.mainGameView.StartCoroutine(PlayCard(selectedCardSet, player, 0f));
    }
}