using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameView : MonoBehaviour
{
    [SerializeField] private CharacterInGame[] characters;
    [SerializeField] private CardController[] cardControllers;
    [SerializeField] private CardController playedCardController;
    [SerializeField] private GameObject playerButtonContainer;
    [SerializeField] private Button playSetButton;
    [SerializeField] private Button passButton;
    [SerializeField] private GameObject passTextContainer;

    public delegate void OnSelectedCardSet(CardSet cardSet);
    public event OnSelectedCardSet onSelectedCardSet;

    public delegate void OnPlayCardSet(CardSet cardSet);
    public event OnPlayCardSet onPlayCardSet;

    public delegate void OnPassTurn();
    public event OnPassTurn onPassTurn;

    private CardSet playedSet;

    void Awake()
    {
        playSetButton.onClick.AddListener(OnPlaySetButton);
        passButton.onClick.AddListener(OnPassButton);
        ShowPassText(false);
        ActivatePlaySetButton(false);
        ActivatePassButton(false);
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
        var cardController = cardControllers[(int)player.Type];
        character.ChangePhoto(player.IdleSprite);
        character.ChangeName(player.CharName);
        cardController.onSelectCards += SelectedCards;
        cardController.Populate(player.Cards.ToArray());
        cardController.isInputActive = false;
    }

    public void ActivatePlayer(PlayerType playerType, bool isPlayerTurn)
    {
        var character = characters[(int)playerType];
        var cardController = cardControllers[(int)playerType];

        character.IsMyTurn = isPlayerTurn;
        cardController.isInputActive = isPlayerTurn;
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

    public void UpdateCards(PlayerType playerType, CardElement[] cards)
    {
        var cardController = cardControllers[(int)playerType];
        cardController.Populate(cards);
    }

    public void ActivateCardInput(bool isInputActive, PlayerType playerType)
    {
        var cardController = cardControllers[(int)playerType];
        cardController.isInputActive = isInputActive;
    }

    public void PlaySet(CardSet playSet)
    {
        playedCardController.Populate(playSet.Cards);
    }

    public void PassTurn()
    {
        ShowPassText(true);
    }

    public void ShowButtons(bool isShown)
    {
        playerButtonContainer.SetActive(isShown);
    }

    public void ActivatePlaySetButton(bool isActive)
    {
        playSetButton.gameObject.SetActive(isActive);
    }

    public void ActivatePassButton(bool isActive)
    {
        passButton.gameObject.SetActive(isActive);
    }

    public void ShowPassText(bool isShown)
    {
        passTextContainer.SetActive(isShown);
    }    

    private IEnumerator ChangePhotoAfter(CharacterInGame character, Sprite sprite, float duration) {
        yield return new WaitForSeconds(duration);
        character.ChangePhoto(sprite);
    }

    private void SelectedCards(CardElement[] cards)
    {
        playedSet = CardSetFactory.Create(cards);
        if(onSelectedCardSet != null) onSelectedCardSet(playedSet);
    }

    private void OnPlaySetButton()
    {
        if(onPlayCardSet != null) onPlayCardSet(playedSet);
    }

    private void OnPassButton()
    {
        if(onPassTurn != null) onPassTurn();
    }
}
