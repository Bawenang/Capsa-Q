using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainmenuSceneController : MonoBehaviour
{
    [SerializeField] private MainHUD mainHUD;
    [SerializeField] private OpeningMenuView openingMenuView;
    [SerializeField] private CharacterSelectionView characterSelectionView;
    [SerializeField] private CharacterData[] characters;

    private void OnEnable() {
        openingMenuView.onPlayButton += SelectCharacter;
    }

    private void OnDisable()
    {
        openingMenuView.onPlayButton -= SelectCharacter;
    }

    void Awake()
    {
        openingMenuView.gameObject.SetActive(true);
        characterSelectionView.gameObject.SetActive(false);
        characterSelectionView.Populate(characters);
    }

    // Start is called before the first frame update
    void Start()
    {
        mainHUD.FadeIntoScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SelectCharacter() {
        mainHUD.FadeOutIn(ShowCharacterSelection);
    }

    private void ShowCharacterSelection() {
        openingMenuView.gameObject.SetActive(false);
        characterSelectionView.gameObject.SetActive(true);
    }
}
