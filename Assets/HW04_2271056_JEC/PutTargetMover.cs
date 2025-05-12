using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PutTargetMover : MonoBehaviour
{
    public Transform center;  // 기준 중심점
    public float radius = 0.2f;  // 이동 범위 제한
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
            // 중심 기준으로 랜덤한 위치 계산
            Vector3 offset = new Vector3(
                Random.Range(-radius, radius),
                Random.Range(0.05f, 0.15f),
                Random.Range(0.2f, 0.4f) // Z는 항상 카메라 쪽으로
            );

            transform.localPosition = offset;

            yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));
        }
    }
}
