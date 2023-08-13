using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;

public class GameStateController : FSM.StateController
{
    private GameRepository repository = new GameRepository();
    public MainGameView mainGameView;
    public CharacterData selectedCharacter;
    public CharacterData[] allCharacters;
    protected override void OnActivateState(State state)
    {
        if(state is GamePreparationState) {
            var props = new GamePreparationState.Properties();
            props.mainGameView = mainGameView;
            props.repository = repository;
            props.selectedCharacter = selectedCharacter;
            props.allCharacters = allCharacters;
            state.Setup(props);
        } else if(state is FirstTurnState) {
            var props = new FirstTurnState.Properties();
            props.mainGameView = mainGameView;
            props.repository = repository;
            state.Setup(props);
        } else if(state is PlayerTurnState) {
            var props = new PlayerTurnState.Properties();
            props.mainGameView = mainGameView;
            props.repository = repository;
            state.Setup(props);
        }
    }

    protected override void OnActivateTransition(Transition transition)
    {
        if(transition is NextTurnTransition) {
            var props = new NextTurnTransition.Properties();
            props.mainGameView = mainGameView;
            props.repository = repository;
            transition.Setup(props);
        }
    }

    protected override void OnEndStateCallback(Transition withTransition)
    {
    }

    protected override void OnEndTransitionCallback(State toState)
    {
    }
}
