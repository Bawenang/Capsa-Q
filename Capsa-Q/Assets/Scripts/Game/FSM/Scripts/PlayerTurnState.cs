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

    public override void Setup(object properties)
    {
        Properties props = properties as Properties;
        if (props == null) {
            Debug.LogError("Properties invalid! Should be of PlayerTurnState.Properties type.");
            return;
        }

        var player = props.repository.GetPlayer(playerType);
        props.mainGameView.ActivatePlayer(playerType, true);
    }

    public override void CleanUp()
    {
    }

    protected override int CheckTransition()
    {
        return -1;
    }

    protected override void DoUpdateAction()
    {
    }
}
