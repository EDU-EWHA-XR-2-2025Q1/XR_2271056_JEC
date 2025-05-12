using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PutTargetMover : MonoBehaviour
{
    public Transform center;  // ���� �߽���
    public float radius = 0.2f;  // �̵� ���� ����
    public float minInterval = 0.5f;
    public float maxInterval = 1f;

    private void Start()
    {
        StartCoroutine(MoveRandomly());
    }

    IEnumerator MoveRandomly()
    {
        while (true)
        {
            // �߽� �������� ������ ��ġ ���
            Vector3 offset = new Vector3(
                Random.Range(-radius, radius),
                Random.Range(0.05f, 0.15f),
                Random.Range(0.2f, 0.4f) // Z�� �׻� ī�޶� ������
            );

            transform.localPosition = offset;

            yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));
        }
    }
}
