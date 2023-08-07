using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionView : MonoBehaviour
{
    [SerializeField] private Button beginButton;
    [SerializeField] private CharacterButton[] charButtons;

    private int selectedCharId = 0;

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

    void Awake()
    {

        for(int i = 0; i < charButtons.Length; i++) {
            charButtons[i].Populate(null, "NAME", i);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        charButtons[0].Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BeginGame() {
        if(onBeginButton != null) onBeginButton();
    }

    private void CharSelected(int index) 
    {
        Debug.Log(">>>>> Selected index = " + index);
        selectedCharId = index;
    }
}
