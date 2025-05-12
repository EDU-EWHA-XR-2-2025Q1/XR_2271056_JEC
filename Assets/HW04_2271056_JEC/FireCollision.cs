using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PutTarget"))
        {
            PickManager.Instance.AddPut();  // ���� ���� + UI �ڵ� �ݿ�
            Destroy(gameObject);            // �߻�� ������ ����
        }
    }
}