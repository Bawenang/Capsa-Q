using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameView : MonoBehaviour
{
    [SerializeField] private CharacterInGame[] characters;
    [SerializeField] private CardController[] cardControllers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Populate(CharacterData player, CharacterData[] aiPlayer)
    {
        characters[0].Populate(player);
        for(int i = 1; i < characters.Length; i++) {
            characters[i].Populate(aiPlayer[i-1]);
        }
    }

    public void InitiatePlayer(Player player)
    {
        var character = characters[(int)player.Type];
        character.ChangePhoto(player.IdleSprite);
        character.ChangeName(player.CharName);
        
        var cardController = cardControllers[(int)player.Type];
        var cardDistance = cardController.isControllable ? 0.5f : 0.2f;
        var scaleFactor = cardController.isControllable ? 1.0f : 0.5f;
        cardController.Populate(player.Cards.ToArray(), cardDistance, scaleFactor);
    }
}
