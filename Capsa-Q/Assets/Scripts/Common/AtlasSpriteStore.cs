using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class AtlasSpriteStore : MonoBehaviour
{
    public static AtlasSpriteStore Instance { 
        get {
            return instance;
        }
    }

    public static void DestroyInstance() {
        if (instance == null) return;
        DestroyImmediate(instance.gameObject);
        instance = null;
    }

    private static AtlasSpriteStore instance = null;
    [SerializeField] private List<SpriteAtlas> atlasList = new List<SpriteAtlas>();
    private Dictionary<string, Sprite> spriteDict = new Dictionary<string, Sprite>();

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

    public Sprite GetSprite(string key) 
    {
        Debug.Log("GetSprite " + key);
        if(spriteDict.ContainsKey(key)) {
            return spriteDict[key];
        } else {
            Sprite sprite = GetFromAtlasList(key);
            if(sprite != null) {
                spriteDict.Add(key, sprite);
                return sprite;
            } else {
                return null;
            }
        } 
    }

    public Sprite RetrieveSprite(string key) 
    {
        return spriteDict[key];
    }

    private Sprite GetFromAtlasList(string key) {
        for(int i = 0; i < atlasList.Count; i++) {
            Sprite sprite = atlasList[i].GetSprite(key);
            if(sprite != null) return sprite;
        }
        Debug.Log("GetFromAtlasList return null");

        return null;
    }
}
