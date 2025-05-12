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
            Debug.Log("Pick ���� ����. �߻� �Ұ�");
            return;
        }

        // Pick ����
        pickManager.UsePick();

        // �߻� ��ġ: ī�޶� ���� �ణ ������ ����
        Vector3 firePos = arCamera.position + arCamera.forward * 0.1f;
        Vector3 fireDir = arCamera.forward; // �⺻ ����

        // ī�޶� �������� Ray ���
        Ray ray = new Ray(arCamera.position, arCamera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            Debug.Log($"Raycast hit: {hit.collider.name}");

            if (hit.collider.CompareTag("PutTarget"))
            {
                // �ٱ��� ���� ���
                fireDir = (hit.point - firePos).normalized;
            }
        }

        // ������ ���� �� �߻�
        GameObject item = Instantiate(fireItemPrefab, firePos, Quaternion.identity);
        Rigidbody rb = item.GetComponent<Rigidbody>();
        rb.AddForce(fireDir * forceAmount, ForceMode.Impulse);
    }
}
