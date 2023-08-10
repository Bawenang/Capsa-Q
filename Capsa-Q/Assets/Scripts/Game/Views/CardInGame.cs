using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SpriteRenderer))]
public class CardInGame : PooledObject, IPointerClickHandler
{
    private const int backface = -1;
    public delegate void OnTap(int value);
    public event OnTap onTap;

    public bool IsShowing {
        get => isShowing;
        set {
            isShowing = value;
            if(value) {
                spriteRenderer.sprite = CardSpriteStore.Instance.GetSprite(cardValue);
            } else {
                spriteRenderer.sprite = CardSpriteStore.Instance.GetSprite(backface);
            }
        }
    }

    private SpriteRenderer spriteRenderer;
    private int cardValue;
    private bool isShowing;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Load(int cardValue, bool isShowing)
    {
        this.cardValue = cardValue;
        IsShowing = isShowing;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(onTap != null) onTap(cardValue);
    }

    public override void OnRetrievedFromPool()
    {

    }
    public override void OnReturnedToPool()
    {

    }
}
