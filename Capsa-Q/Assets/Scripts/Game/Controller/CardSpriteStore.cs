using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpriteStore : MonoBehaviour
{
    public static CardSpriteStore Instance { 
        get {
            return instance;
        }
    }

    public static void DestroyInstance() 
    {
        if (instance == null) return;
        DestroyImmediate(instance.gameObject);
        instance = null;
    }

    private static CardSpriteStore instance = null;
    [SerializeField] private CardNameList cardNameList;
    private Dictionary<int, Sprite> spriteDict = new Dictionary<int, Sprite>();
    private Sprite backfaceSprite;

    void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else if (instance != this) {
            DestroyImmediate(this.gameObject);
        }
    }

    void OnDestroy()
    {
        if (instance == this) {
            instance = null;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < cardNameList.cardNames.Length; i++) {
            spriteDict.Add(i, cardNameList.GetSprite(i));
        }
        backfaceSprite = cardNameList.GetSprite(-1);
    }

    public Sprite GetSprite(int value)
    {
        if(spriteDict.ContainsKey(value)) {
            return spriteDict[value];
        } else {
            return backfaceSprite;
        }
    }
}
