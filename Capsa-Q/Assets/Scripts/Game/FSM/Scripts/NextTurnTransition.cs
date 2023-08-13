using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NextTurnTransition", menuName = "ScriptableObjects/NextTurnTransition", order = 7)]
public class NextTurnTransition : FSM.Transition
{
    public class Properties 
    {
        public MainGameView mainGameView;
        public GameRepository repository;
    }
    public PlayerType playerType;
    private Properties props;
    private bool shouldEndTransition = false;
    
    public override void Setup(object properties)
    {
        Debug.Log("NextTurnTransition Setup! player: " + playerType);
        props = properties as Properties;
        if (props == null) {
            Debug.LogError("Properties invalid! Should be of PlayerTurnState.Properties type.");
            return;
        }

        var player = props.repository.GetPlayer(playerType);
        props.mainGameView.ChangePhoto(playerType, player.PlaySprite);
        shouldEndTransition = false;
        props.mainGameView.StartCoroutine(ChangePhotoEndTransition());
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
        return shouldEndTransition;
    }

    private IEnumerator ChangePhotoEndTransition() 
    {
        Debug.Log("NextTurnTransition ChangePhotoEndTransition! player: " + playerType);
        yield return new WaitForSeconds(2f);
        var player = props.repository.GetPlayer(playerType);
        props.mainGameView.ChangePhoto(playerType, player.IdleSprite);
        shouldEndTransition = true;
    }
}
