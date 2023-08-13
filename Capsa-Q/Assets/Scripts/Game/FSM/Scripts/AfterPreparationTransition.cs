using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AfterPreparationTransition", menuName = "ScriptableObjects/AfterPreparationTransition", order = 6)]
public class AfterPreparationTransition : FSM.Transition
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
