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
        props.mainGameView.ShowPassText(false);
        props.mainGameView.ActivatePassButton(true);

        if(props.repository.lastPlaying == playerType) {
            ResetAndPlayAction(props, player);
        } else {
            PlayerAction(props, player);
        }
    }

    public override void CleanUp()
    {
        var player = props.repository.GetPlayer(playerType);
        props.mainGameView.ActivatePlayer(playerType, false);
        var aiPlayer = player as AIPlayer;
        if(aiPlayer == null) {
            props.mainGameView.onSelectedCardSet -= CheckValidity;
            props.mainGameView.onPlayCardSet -= PlaySelectedCard;
            props.mainGameView.onPassTurn -= Pass;
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
            props.mainGameView.onPassTurn += Pass;
            props.mainGameView.ShowButtons(true);
            props.mainGameView.ActivatePlaySetButton(false);
        } else {
            var playedSet = props.repository.GetTopPlayedCards();
            var selectedCard = aiPlayer.SelectPlayCardSet(playedSet);
            if (selectedCard.SetType == CardSetFactory.Invalid.SetType) {
                props.mainGameView.StartCoroutine(PassTurn(2f));
            } else {
                props.mainGameView.StartCoroutine(PlayCard(selectedCard, player, 2f));
            }
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
        if(player.Cards.Count == 0) {
            props.repository.winner = player.Type;
            nextTransition = 1;
        } else {
            nextTransition = 0;
        }
    }

    private IEnumerator PassTurn(float waitDuration)
    {
        yield return new WaitForSeconds(waitDuration);
        props.mainGameView.PassTurn();
        nextTransition = 0;
    }

    private void CheckValidity(CardSet selectedCardSet)
    {
        var topPlayedCardSet = props.repository.GetTopPlayedCards();
        var isPlaySetButtonActive = CardsComparator.IsHigherThan(selectedCardSet, topPlayedCardSet);
        props.mainGameView.ActivatePlaySetButton(isPlaySetButtonActive);
    }

    private void PlaySelectedCard(CardSet selectedCardSet)
    {
        var player = props.repository.GetPlayer(playerType);
        props.mainGameView.StartCoroutine(PlayCard(selectedCardSet, player, 0f));
    }

    private void Pass()
    {
        props.mainGameView.StartCoroutine(PassTurn(0f));
    }

    private void ResetAndPlayAction(Properties props, IPlayer player)
    {
        props.mainGameView.StartCoroutine(ResetCoroutine(props, player, 1f));
    }

    private IEnumerator ResetCoroutine(Properties props, IPlayer player, float waitDuration)
    {
        yield return new WaitForSeconds(waitDuration);
        props.repository.ResetPlayedCards();
        props.mainGameView.ClearPlayCards();
        PlayerAction(props, player);
    }
}
