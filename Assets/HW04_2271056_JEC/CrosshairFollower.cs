using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairFollower : MonoBehaviour
{
    public Transform target3D;               // PutTarget
    public Camera arCamera;                  // ARCamera
    public RectTransform crosshairUI;        // Crosshair (RectTransform)
    public RectTransform canvasRect;         // Canvas

    void Update()
    {
        // 1. 월드 좌표 → 스크린 좌표
        Vector3 screenPos = arCamera.WorldToScreenPoint(target3D.position);

        // 2. 스크린 좌표 → UI 로컬 좌표
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect,
            screenPos,
            null,
            out Vector2 localPoint
        );

        // 3. UI 위치 갱신
        crosshairUI.anchoredPosition = localPoint;
    }
}