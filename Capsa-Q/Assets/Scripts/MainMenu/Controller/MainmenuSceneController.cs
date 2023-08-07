using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainmenuSceneController : MonoBehaviour
{
    [SerializeField] private MainHUD mainHUD;
    [SerializeField] private OpeningMenuView openingMenuView;

    // Start is called before the first frame update
    void Start()
    {
        mainHUD.FadeIntoScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
