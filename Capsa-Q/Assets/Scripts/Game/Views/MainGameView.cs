using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameView : MonoBehaviour
{
    [SerializeField] private CharacterInGame[] characters;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Populate(CharacterData player, CharacterData[] aiPlayer)
    {
        characters[0].Populate(player);
        for(int i = 1; i < characters.Length; i++) {
            characters[i].Populate(aiPlayer[i-1]);
        }
    }

}
