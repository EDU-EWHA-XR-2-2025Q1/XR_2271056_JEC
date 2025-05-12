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
        // 1. ���� ��ǥ �� ��ũ�� ��ǥ
        Vector3 screenPos = arCamera.WorldToScreenPoint(target3D.position);

        // 2. ��ũ�� ��ǥ �� UI ���� ��ǥ
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect,
            screenPos,
            null,
            out Vector2 localPoint
        );

        // 3. UI ��ġ ����
        crosshairUI.anchoredPosition = localPoint;
    }
}