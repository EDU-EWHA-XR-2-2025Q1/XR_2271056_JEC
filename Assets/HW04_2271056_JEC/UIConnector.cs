using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIConnector : MonoBehaviour
{
    public TextMeshProUGUI pickText;
    public TextMeshProUGUI putText;

    void Start()
    {
        if (PickManager.Instance != null)
        {
            PickManager.Instance.RegisterUI(pickText, putText);
        }
    }

    void OnEnable()
    {
        if (PickManager.Instance != null)
        {
            PickManager.Instance.RegisterUI(pickText, putText);
        }
    }
}
