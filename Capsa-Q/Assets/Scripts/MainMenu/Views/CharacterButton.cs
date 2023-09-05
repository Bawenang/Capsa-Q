using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private Image photoImage;
    [SerializeField] private TMPro.TextMeshProUGUI nameText;
    private int index = -1;

    public delegate void OnSelected(int index);
    public event OnSelected onSelected;

    public void Populate(Sprite photo, string name, int index) 
    {
        this.photoImage.sprite = photo;
        this.nameText.text = name;
        this.index = index;
    }

    public void Select() 
    {
        toggle.isOn = true;
    }
    private void Awake() 
    {
        toggle.onValueChanged.AddListener(ValueChanged);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ValueChanged(bool isOn) 
    {
        if(isOn && onSelected != null) onSelected(this.index);
    }
}
