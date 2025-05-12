using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ActivateWhenTracked : MonoBehaviour
{
    public GameObject[] objectsToActivate;
    public GameObject[] objectsToDeactivate;

    void Start()
    {
        var observer = GetComponent<ObserverBehaviour>();
        if (observer)
        {
            observer.OnTargetStatusChanged += OnStatusChanged;
        }

        SetActiveAll(objectsToActivate, false);
        SetActiveAll(objectsToDeactivate, true);
    }

    void OnStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        bool isTracked = status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED;
        SetActiveAll(objectsToActivate, isTracked);
        SetActiveAll(objectsToDeactivate, !isTracked);
    }

    void SetActiveAll(GameObject[] list, bool active)
    {
        foreach (var obj in list)
        {
            if (obj != null) obj.SetActive(active);
        }
    }
}