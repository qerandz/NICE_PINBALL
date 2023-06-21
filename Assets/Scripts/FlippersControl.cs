using UnityEngine;

public class FlippersControl : MonoBehaviour
{
    public float rotationAmount = 90.0f; // �������� �������� �� ��� Z
    public float rotationSpeed = 1.0f; // �������� ��������
    public bool isActive = true;

    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private bool isRotating = false;
    private bool isReturning = false;
    private float rotationTimer = 0.0f;
    private float returnTimer = 0.0f;

    private void Start()
    {
        initialRotation = transform.rotation;
        targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, initialRotation.eulerAngles.z + rotationAmount);
    }

    private void Update()
    {
        if (isRotating)
        {
            rotationTimer += Time.deltaTime * rotationSpeed;

            // ������� �������
            transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, rotationTimer);

            if (rotationTimer >= 1.0f)
            {
                // ���������� ��������
                isRotating = false;
                isReturning = true;
                returnTimer = 0.0f;
                
            }
        }
        else if (isReturning)
        {
            returnTimer += Time.deltaTime * rotationSpeed;

            // ������� ������� � �������� ���������
            transform.rotation = Quaternion.Lerp(targetRotation, initialRotation, returnTimer);

            if (returnTimer >= 1.0f)
            {
                // ���������� ��������
                isReturning = false;
                isActive = false;
            }
        }

        // ��������� ������� ����� ������ ����
        if (isActive == true && !isRotating && !isReturning)
        {
            // ������ ��������
            isRotating = true;
            rotationTimer = 0.0f;
        }
    }
}
