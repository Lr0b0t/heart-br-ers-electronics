using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

using UnityEngine.Events;

[ExecuteInEditMode]
public class SpriteOutline : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Color color = Color.white;

    private SpriteRenderer spriteRenderer;
    public int i = 0;
    private bool pointerDown;
    private float pointerDownTimer;

    [SerializeField]
    private float requiredHoldTime;

    public UnityEvent onLongClick;

    [SerializeField]
    private Image fillImage;
    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        Debug.Log("OnPointerUp");
        Debug.Log("Sprite Clicked");
        Debug.Log("point");
        spriteRenderer = GetComponent<SpriteRenderer>();

        UpdateOutline(true);
        i = 1;
    }

    void OnEnable()

    {
    }
    void Update()
    {
        if (i == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Ubrat");
                i = 0;
            }
        }
        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredHoldTime)
            {
                if (onLongClick != null)
                    onLongClick.Invoke();
                    Debug.Log("hold");

                Reset();
            }
        }
    }
    void OnMouseDown()
    {
        
    
    }
    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
    }

    void OnDisable()
    {
        UpdateOutline(false);
    }


    void UpdateOutline(bool outline)
    {
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        spriteRenderer.GetPropertyBlock(mpb);
        mpb.SetFloat("_Outline", outline ? 1f : 0);
        mpb.SetColor("_OutlineColor", color);
        spriteRenderer.SetPropertyBlock(mpb);
    }


}