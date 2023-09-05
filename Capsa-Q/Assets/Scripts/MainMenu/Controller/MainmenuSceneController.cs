using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainmenuSceneController : MonoBehaviour
{
    [SerializeField] private MainHUD mainHUD;
    [SerializeField] private OpeningMenuView openingMenuView;
    [SerializeField] private CharacterSelectionView characterSelectionView;
    [SerializeField] private CharacterData[] characters;

    private void OnEnable() 
    {
        openingMenuView.onPlayButton += SelectCharacter;
        characterSelectionView.onBeginButton += BeginGame;
    }

    private void OnDisable()
    {
        openingMenuView.onPlayButton -= SelectCharacter;
        characterSelectionView.onBeginButton -= BeginGame;
    }

    void Awake()
    {
        characterSelectionView.Populate(characters);
    }

    // Start is called before the first frame update
    void Start()
    {
        openingMenuView.gameObject.SetActive(true);
        characterSelectionView.gameObject.SetActive(false);
        mainHUD.FadeIntoScene();
    }

    private void SelectCharacter() 
    {
        mainHUD.FadeOutIn(ShowCharacterSelection);
    }

    private void ShowCharacterSelection() 
    {
        openingMenuView.gameObject.SetActive(false);
        characterSelectionView.gameObject.SetActive(true);
    }

    private void BeginGame(CharacterData selectedChar)
    {
        GameSceneController.selectedCharacter = selectedChar;
        mainHUD.FadeOutOfScene(LoadGameScene);
    }

    private void LoadGameScene() 
    {
        SceneManager.LoadScene(1);
    }
}
