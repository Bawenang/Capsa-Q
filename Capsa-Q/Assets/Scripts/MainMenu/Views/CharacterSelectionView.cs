using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionView : MonoBehaviour
{
    [SerializeField] private Button beginButton;
    [SerializeField] private CharacterButton[] charButtons;

    public delegate void OnBeginButton(CharacterData selectedChar);
    public event OnBeginButton onBeginButton;

    private CharacterData[] characters = { };
    private CharacterData selectedChar = null;

    void OnEnable()
    {
        for(int i = 0; i < charButtons.Length; i++) {
            charButtons[i].onSelected += CharSelected;
        }
    }

    void OnDisable()
    {
        for(int i = 0; i < charButtons.Length; i++) {
            charButtons[i].onSelected -= CharSelected;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        charButtons[0].Select();
        beginButton.onClick.AddListener(BeginGame);
    }

    public void Populate(CharacterData[] characters) 
    {
        this.characters = characters;
        for(int i = 0; i < charButtons.Length; i++) {
            charButtons[i].Populate(characters[i].GetSprite(SpriteState.Idle), 
                                    characters[i].charName, 
                                    i);
        }
    }

    private void BeginGame() 
    {
        if(onBeginButton != null) onBeginButton(selectedChar);
    }

    private void CharSelected(int index) 
    {
        selectedChar = characters[index];
    }
}
