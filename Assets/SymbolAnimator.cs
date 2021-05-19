﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolAnimator : MonoBehaviour {

    public ShapeDrawSystem4 shapeDraw;
    public SpriteRenderer[] symbolRender;
    private float fade;
    
    void Awake () {
        shapeDraw.executeSymbol += OnExecuteSymbol;
    }

    void OnDestroy () {
        shapeDraw.executeSymbol -= OnExecuteSymbol;
    }

    void OnExecuteSymbol (string key) {
        foreach(SpriteRenderer sr in symbolRender) {
            sr.sprite = DrawingUtility.GetSymbolSprite(key, SymbolSpriteSize.Large);
        }
        fade = 2f;
    }
    
    void Update () {
        fade = Mathf.Max(fade - Time.deltaTime * 4f, 0f);
        foreach(SpriteRenderer sr in symbolRender) {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, Mathf.Min(1f, fade));
        }
    }
}
