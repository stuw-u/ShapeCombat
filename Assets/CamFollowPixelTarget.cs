﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPixelTarget : MonoBehaviour {

    new public Camera camera;
    public Vector2 unitTarget;
    public float height = 20f;
    public UnityEngine.U2D.PixelPerfectCamera pixelPerfectCamera;

    [Header("Target Mode")]
    public bool targetMode;
    public Transform target;

    private Vector2 anchorPoint;
    private Vector2 anchorUnitTarget;

    void Update () {
        if(!targetMode) {
            if(Input.GetMouseButtonDown(2)) {
                anchorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
                anchorUnitTarget = unitTarget;
            }
            if(Input.GetMouseButton(2)) {
                Vector2 diff = anchorPoint - new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                unitTarget = anchorUnitTarget + diff * (1 / (16f * pixelPerfectCamera.pixelRatio));
            }
        } else {
            unitTarget = new Vector2(target.transform.position.x, target.transform.position.y + target.transform.position.z * 0.5f - height);
        }

        transform.position = new Vector3(Mathf.FloorToInt(unitTarget.x * 16) / 16f, height, (Mathf.FloorToInt(unitTarget.y * 16f) / 8f));
    }
}
