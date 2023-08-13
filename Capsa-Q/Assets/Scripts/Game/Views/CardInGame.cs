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

    public bool IsControllable {
        get => isControllable;
        set => isControllable = value;
    }

    private SpriteRenderer spriteRenderer;
    private int cardValue;
    private bool isShowing;
    private bool isControllable;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Load(int cardValue, bool isShowing, bool isControllable)
    {
        this.cardValue = cardValue;
        IsShowing = isShowing;
        IsControllable = isControllable;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(isControllable && onTap != null) onTap(cardValue);
    }

    public override void OnRetrievedFromPool()
    {

    }
    public override void OnReturnedToPool()
    {

    }
}
