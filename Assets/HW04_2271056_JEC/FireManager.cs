using UnityEngine;
using UnityEngine.UI;

public class FireManager : MonoBehaviour
{
    public GameObject fireItemPrefab;
    public Transform arCamera;
    public float forceAmount = 5f;
    public Button fireButton;
    public PickManager pickManager;

    void Start()
    {
        if (pickManager == null && PickManager.Instance != null)
        {
            pickManager = PickManager.Instance;
        }

        UpdateFireButtonState();
    }

    void Update()
    {
        UpdateFireButtonState();
    }

    void UpdateFireButtonState()
    {
        if (fireButton != null && pickManager != null)
        {
            fireButton.interactable = pickManager.pickCount > 0;
        }
    }

    public void Fire()
    {
        if (pickManager.pickCount <= 0)
        {
            Debug.Log("Pick 수량 부족. 발사 불가");
            return;
        }

        // Pick 감소
        pickManager.UsePick();

        // 발사 위치: 카메라 앞쪽 약간 떨어진 지점
        Vector3 firePos = arCamera.position + arCamera.forward * 0.1f;
        Vector3 fireDir = arCamera.forward; // 기본 방향

        // 카메라 정면으로 Ray 쏘기
        Ray ray = new Ray(arCamera.position, arCamera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            Debug.Log($"Raycast hit: {hit.collider.name}");

            if (hit.collider.CompareTag("PutTarget"))
            {
                // 바구니 맞춘 경우
                fireDir = (hit.point - firePos).normalized;
            }
        }

        // 아이템 생성 및 발사
        GameObject item = Instantiate(fireItemPrefab, firePos, Quaternion.identity);
        Rigidbody rb = item.GetComponent<Rigidbody>();
        rb.AddForce(fireDir * forceAmount, ForceMode.Impulse);
    }
}
