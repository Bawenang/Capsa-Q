using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    public static CharacterData selectedCharacter;
    [SerializeField] private CharacterData mockCharacter;
    [SerializeField] private CharacterData[] allCharacters;
    [SerializeField] private MainGameView mainGameView;
    [SerializeField] private GameStateController stateController;

    void OnEnable()
    {
        stateController.onInitiatePlayer += InitiatePlayer;
    }

    void OnDisable()
    {
        stateController.onInitiatePlayer -= InitiatePlayer;
    }

    // Start is called before the first frame update
    void Start()
    {
        var selectedCharacter = (GameSceneController.selectedCharacter == null) ? 
                    mockCharacter : GameSceneController.selectedCharacter;
        stateController.selectedCharacter = selectedCharacter;
        stateController.allCharacters = allCharacters;

        stateController.StartManually();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitiatePlayer(Player player)
    {
        mainGameView.InitiatePlayer(player);
    }
}
