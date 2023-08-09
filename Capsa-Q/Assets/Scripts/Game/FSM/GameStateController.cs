using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;

public class GameStateController : FSM.StateController
{
    public delegate void OnInitiatePlayer(Player player);
    public event OnInitiatePlayer onInitiatePlayer;
    
    private GameRepository repository;
    public CharacterData selectedCharacter;
    public CharacterData[] allCharacters;
    protected override void OnActivateState(State state)
    {
        if(state is GamePreparationState) {
            var props = new GamePreparationState.Properties();
            props.selectedCharacter = selectedCharacter;
            props.allCharacters = allCharacters;
            props.onPopulateGame = OnPopulateGame;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPopulateGame(GameRepository repository)
    {
        this.repository = repository;

        if(onInitiatePlayer != null) {
            onInitiatePlayer(repository.GetPlayer(PlayerType.Player1));
            onInitiatePlayer(repository.GetPlayer(PlayerType.Player2));
            onInitiatePlayer(repository.GetPlayer(PlayerType.Player3));
            onInitiatePlayer(repository.GetPlayer(PlayerType.Player4));
        }
    }
}
