using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WinState", menuName = "ScriptableObjects/WinState", order = 6)]
public class WinState : FSM.State
{
    public class Properties 
    {
        public MainGameView mainGameView;
        public GameRepository repository;
    }

    private Properties props;
    private int nextTransition = -1;

    public override void Setup(object properties)
    {
        nextTransition = -1;
        props = properties as Properties;
        if (props == null) {
            Debug.LogError("Properties invalid! Should be of WinState.Properties type.");
            return;
        }

        DeactivateAllPlayers();
        SetAllPlayerPhotos(props);
        ShowCongratulationsDialog(props);
    }

    public override void CleanUp()
    {
    }

    protected override int CheckTransition()
    {
        return nextTransition; //TEST next turn!
    }

    protected override void DoUpdateAction()
    {
    }

    private void DeactivateAllPlayers()
    {
        props.mainGameView.ActivatePlayer(PlayerType.Player1, false);
        props.mainGameView.ActivatePlayer(PlayerType.Player2, false);
        props.mainGameView.ActivatePlayer(PlayerType.Player3, false);
        props.mainGameView.ActivatePlayer(PlayerType.Player4, false);
    }

    private void SetAllPlayerPhotos(Properties props)
    {
        SetPhoto(props, PlayerType.Player1);
        SetPhoto(props, PlayerType.Player2);
        SetPhoto(props, PlayerType.Player3);
        SetPhoto(props, PlayerType.Player4);
    }

    private void SetPhoto(Properties props, PlayerType playerType)
    {
        var player = props.repository.GetPlayer(playerType);
        if(player.Type == props.repository.winner) props.mainGameView.ChangePhoto(playerType, player.WinSprite);
        else props.mainGameView.ChangePhoto(playerType, player.LoseSprite);
    }

    private void ShowCongratulationsDialog(Properties props)
    {
        var winningPlayer = props.repository.GetPlayer(props.repository.winner);
        props.mainGameView.ShowCongratulations(winningPlayer.CharName);
    }
}
