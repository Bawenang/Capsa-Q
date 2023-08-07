using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    public static CharacterData selectedCharacter;
    [SerializeField] private CharacterData mockCharacter;
    [SerializeField] private CharacterData[] allCharacters;
    [SerializeField] private MainGameView mainGameView;
    // Start is called before the first frame update
    void Start()
    {
        var selectedCharacter = (GameSceneController.selectedCharacter == null) ? 
                    mockCharacter : GameSceneController.selectedCharacter;
        var aiPlayers = CreateAICharacterData(selectedCharacter);
        mainGameView.Populate(selectedCharacter, aiPlayers);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private CharacterData[] CreateAICharacterData(CharacterData exceptPlayer) 
    {
        List<CharacterData> charList = new List<CharacterData>(allCharacters);
        charList.RemoveAll(character => character.charName == exceptPlayer.charName);
        return Shuffle(charList);
    }

    private static CharacterData[] Shuffle(List<CharacterData> charList)
    {
        System.Random r = new System.Random();
        
        for (int n = charList.Count - 1; n > 0; --n)
        {
            int k = r.Next(n + 1);

            CharacterData temp = charList[n];
            charList[n] = charList[k];
            charList[k] = temp;
        }

        return charList.ToArray();
    }
}
