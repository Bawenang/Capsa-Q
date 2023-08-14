using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameResultTransition", menuName = "ScriptableObjects/GameResultTransition", order = 9)]
public class GameResultTransition : FSM.Transition
{
    public override void Setup(object properties)
    {
    }

    public override void CleanUp()
    {
    }

    public override void OnEnter()
    {
    }

    public override void OnExit()
    {
    }

    protected override bool CheckTransitionFinished()
    {
        return true;
    }
}
