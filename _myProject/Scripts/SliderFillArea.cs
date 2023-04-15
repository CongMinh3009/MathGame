using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderFillArea : MonoBehaviour
{
    public RectTransform Rect;

    private void OnEnable()
    {
        Rect.anchoredPosition = Vector2.zero;
    }
}
