using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAtlasSetter : MonoBehaviour
{
    [SerializeField] private SpriteAtlas spriteAtlas;
    [SerializeField] private string spriteName;

    void Awake()
    {
        var sprite = spriteAtlas.GetSprite(spriteName);
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
