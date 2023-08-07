using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainmenuSceneController : MonoBehaviour
{
    [SerializeField] private MainHUD mainHUD;
    [SerializeField] private OpeningMenuView openingMenuView;

    private void OnEnable() {
        openingMenuView.onPlayButton += SelectCharacter;
    }

    private void OnDisable()
    {
        openingMenuView.onPlayButton -= SelectCharacter;
    }

    void Awake()
    {
        
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
        mainHUD.FadeIntoScene();
    }
}
