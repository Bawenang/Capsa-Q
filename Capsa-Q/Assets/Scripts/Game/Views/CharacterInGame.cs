using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInGame : MonoBehaviour
{
    private Color idleColor = Color.white;
    private Color playingColor = new Color(238f/255f, 156f/255f, 51f/255f);

    [SerializeField] private Image photoImage;
    [SerializeField] private Image frameImage;
    [SerializeField] private TMPro.TextMeshProUGUI nameText;
    // Start is called before the first frame update

    private bool IsMyTurn { 
        get { return isMyTurn; }
        set { 
            frameImage.color = value ? playingColor : idleColor; 
            isMyTurn = value; 
        }
    }
    private bool isMyTurn = false;
    private Sprite[] sprites;

    void Start()
    {
        IsMyTurn = false;
    }

    public void Populate(CharacterData character)
    {
        var allSpriteStates = Enum.GetValues(typeof(SpriteState)).Cast<SpriteState>().ToArray();
        var spriteList = new List<Sprite>();
        foreach(SpriteState state in allSpriteStates) {
            spriteList.Add(character.GetSprite(state));
        }
        sprites = spriteList.ToArray();
        photoImage.sprite = sprites[(int)SpriteState.Idle];
        nameText.text = character.charName;
    }

    public void ChangePhoto(Sprite sprite)
    {
        photoImage.sprite = sprite;
    }

    public void ChangeName(string name)
    {
        nameText.text = name;
    }
}
