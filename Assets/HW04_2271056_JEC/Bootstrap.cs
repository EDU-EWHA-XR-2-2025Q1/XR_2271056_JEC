using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public GameObject pickManagerPrefab;
    private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            GameObject obj = Instantiate(pickManagerPrefab);
            DontDestroyOnLoad(obj);
            created = true;
        }
    }
}
