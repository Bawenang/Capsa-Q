using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningMenuView : MonoBehaviour
{
    [SerializeField] private Button playButton;

    public delegate void OnPlayButton();
    public event OnPlayButton onPlayButton;

    void Awake() 
    {
        playButton.onClick.AddListener(OnPlay);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPlay() 
    {
        if(onPlayButton != null) onPlayButton();
    }
}
