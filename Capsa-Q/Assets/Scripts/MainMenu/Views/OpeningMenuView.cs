using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningMenuView : MonoBehaviour
{
    [SerializeField] private Button playButton;

    void Awake() 
    {
        playButton.onClick.AddListener(OnPlayButton);

    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPlayButton() 
    {
        
    }
}
