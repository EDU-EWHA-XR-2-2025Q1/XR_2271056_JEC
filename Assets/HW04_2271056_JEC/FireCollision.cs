using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PutTarget"))
        {
            PickManager.Instance.AddPut();  // 점수 증가 + UI 자동 반영
            Destroy(gameObject);            // 발사된 아이템 제거
        }
    }
}