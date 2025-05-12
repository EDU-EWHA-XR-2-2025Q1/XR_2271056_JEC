using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickManager : MonoBehaviour
{
    public static PickManager Instance;

    public GameObject itemPrefab;
    public Transform spawnParent;

    public TextMeshProUGUI pickText;
    public TextMeshProUGUI putText;

    public int pickCount = 0;
    public int putCount = 0;
    public int totalItemCount = 10;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    private int CountExistingItems()
    {
        int count = 0;
        foreach (Transform child in spawnParent)
        {
            if (child.CompareTag("Item"))
            {
                count++;
            }
        }
        return count;
    }

    public void TrySpawnItems()
    {
        if (spawnParent == null || itemPrefab == null)
        {
            Debug.LogWarning("SpawnParent or ItemPrefab is null!");
            return;
        }

        int existing = 0;
        foreach (Transform child in spawnParent)
        {
            Debug.Log($"[TrySpawnItems] Checking child: {child.name} / Tag: {child.tag} / isItem: {child.CompareTag("Item")}");
            if (child.CompareTag("Item"))
            {
                existing++;
            }
        }


        int remaining = totalItemCount - pickCount - putCount;
        int needToSpawn = remaining - existing;

        Debug.Log($"[TrySpawnItems] Remaining: {remaining}, Existing: {existing}, Need: {needToSpawn}");

        if (needToSpawn > 0)
        {
            for (int i = 0; i < needToSpawn; i++)
            {
                Vector3 pos = spawnParent.position + new Vector3(Random.Range(-0.1f, 0.1f), 0.02f, Random.Range(-0.1f, 0.1f));
                GameObject item = Instantiate(itemPrefab, pos, Quaternion.identity, spawnParent);
                item.tag = "Item";
            }
        }
    }


    public void AddPick()
    {
        pickCount++;
        UpdateUI();
    }

    public void UsePick()
    {
        if (pickCount > 0)
        {
            pickCount--;
            UpdateUI();
        }
    }

    public void AddPut()
    {
        putCount++;
        UpdateUI();
    }

    public void RegisterUI(TextMeshProUGUI pick, TextMeshProUGUI put)
    {
        pickText = pick;
        putText = put;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (pickText != null) pickText.text = pickCount.ToString();
        if (putText != null) putText.text = putCount.ToString();
    }
}
