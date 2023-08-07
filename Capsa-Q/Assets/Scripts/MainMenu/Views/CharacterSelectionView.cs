using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionView : MonoBehaviour
{
    [SerializeField] private Button beginButton;
    [SerializeField] private CharacterButton[] charButtons;

    private CharacterData[] characters = { };
    private CharacterData selectedChar = null;
    public delegate void OnBeginButton();
    public event OnBeginButton onBeginButton;
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
    }

    public void Populate(CharacterData[] characters) {
        this.characters = characters;
        for(int i = 0; i < charButtons.Length; i++) {
            charButtons[i].Populate(characters[i].GetSprite(CharacterData.SpriteState.Idle), 
                                    characters[i].charName, 
                                    i);
        }
    }

    private void BeginGame() {
        if(onBeginButton != null) onBeginButton();
    }

    private void CharSelected(int index) 
    {
        selectedChar = characters[index];
    }
}
