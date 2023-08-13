using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameView : MonoBehaviour
{
    [SerializeField] private CharacterInGame[] characters;
    [SerializeField] private CardController[] cardControllers;

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

    public void ActivatePlayer(PlayerType playerType, bool isPlayerTurn)
    {
        var character = characters[(int)playerType];
        character.IsMyTurn = isPlayerTurn;
    }

    public void ChangePhoto(PlayerType playerType, Sprite sprite)
    {
        var character = characters[(int)playerType];
        character.ChangePhoto(sprite);
    }

    public void ChangePhotoTemporarily(PlayerType playerType, Sprite sprite, float duration)
    {
        var character = characters[(int)playerType];
        var currentPhoto = character.GetCurrentPhotoSprite();
        character.ChangePhoto(sprite);
        StartCoroutine(ChangePhotoAfter(character, sprite, duration));
    }

    public void PlaySet(CardSet playSet)
    {

    }

    public void PassTurn()
    {

    }

    private IEnumerator ChangePhotoAfter(CharacterInGame character, Sprite sprite, float duration) {
        yield return new WaitForSeconds(duration);
        character.ChangePhoto(sprite);
    }
}
