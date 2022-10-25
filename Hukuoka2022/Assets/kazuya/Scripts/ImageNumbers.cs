using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageNumbers : SpriteNumbers<Image>
{
    [SerializeField]
    private bool _RaycastTarget = false;

    public void ChangeRaycastTarget(bool raycastTarget)
    {
        _RaycastTarget = raycastTarget;

        InitializeComponents();
    }

    protected override void InitializeComponent(Image component)
    {
        component.raycastTarget = _RaycastTarget;
    }

    protected override void UpdateComponent(Image component, Sprite sprite, Color color)
    {
        component.sprite = sprite;
        component.color = color;

        // ピクセルパーフェクトにするため、画像のサイズを調整します
        component.SetNativeSize();
    }
}
