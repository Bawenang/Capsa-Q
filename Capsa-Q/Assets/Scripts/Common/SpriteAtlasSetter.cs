using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAtlasSetter : MonoBehaviour
{
    [SerializeField] private string spriteName;

    void Awake()
    {
        var sprite = AtlasSpriteStore.Instance.GetSprite(spriteName);
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
