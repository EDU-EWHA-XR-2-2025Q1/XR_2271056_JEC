using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemClickHandler : MonoBehaviour
{
    void OnMouseDown()
    {
        if (PickManager.Instance != null)
        {
            PickManager.Instance.AddPick();  
            Destroy(gameObject);
        }
    }
}