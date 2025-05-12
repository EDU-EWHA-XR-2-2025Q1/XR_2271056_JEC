using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Scene01Initializer : MonoBehaviour
{
    public Transform spawnParent;
    public GameObject itemPrefab;
    public TextMeshProUGUI pickText;
    public TextMeshProUGUI putText;

    void Start()
    {
        if (PickManager.Instance != null)
        {
            PickManager.Instance.spawnParent = spawnParent;
            PickManager.Instance.itemPrefab = itemPrefab;
            PickManager.Instance.RegisterUI(pickText, putText);
            PickManager.Instance.TrySpawnItems();
        }
    }
}