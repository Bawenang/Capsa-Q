using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;

public class GameStateController : FSM.StateController
{
    private GameRepository repository;
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
        }
    }

    protected override void OnActivateTransition(Transition transition)
    {
    }

    protected override void OnEndStateCallback(Transition withTransition)
    {
    }

    protected override void OnEndTransitionCallback(State toState)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        repository = new GameRepository();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
