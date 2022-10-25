using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRendererNumbers : SpriteNumbers<SpriteRenderer>
{
    [SerializeField]
    private string _SortingLayerName = "Default";

    [SerializeField]
    private int _SortingOrder = 0;

    public void ChangeSortingLayerName(string sortingLayerName)
    {
        _SortingLayerName = sortingLayerName;

        InitializeComponents();
    }

    public void ChangeSortingOrder(int sortingOrder)
    {
        _SortingOrder = sortingOrder;

        InitializeComponents();
    }

    protected override void InitializeComponent(SpriteRenderer component)
    {
        component.sortingLayerName = _SortingLayerName;
        component.sortingOrder = _SortingOrder;
    }

    protected override void UpdateComponent(SpriteRenderer component, Sprite sprite, Color color)
    {
        component.sprite = sprite;
        component.color = color;
    }
}
