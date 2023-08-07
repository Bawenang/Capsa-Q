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
        AtlasSpriteStore.Instance.GetSprite(spriteName);
    }
}
