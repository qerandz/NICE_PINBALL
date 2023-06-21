using UnityEngine;

public class FlippersControl : MonoBehaviour
{
    public float rotationAmount = 90.0f; // Величина поворота по оси Z
    public float rotationSpeed = 1.0f; // Скорость поворота
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

            // Поворот объекта
            transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, rotationTimer);

            if (rotationTimer >= 1.0f)
            {
                // Завершение поворота
                isRotating = false;
                isReturning = true;
                returnTimer = 0.0f;
                
            }
        }
        else if (isReturning)
        {
            returnTimer += Time.deltaTime * rotationSpeed;

            // Возврат объекта в исходное положение
            transform.rotation = Quaternion.Lerp(targetRotation, initialRotation, returnTimer);

            if (returnTimer >= 1.0f)
            {
                // Завершение возврата
                isReturning = false;
                isActive = false;
            }
        }

        // Обработка нажатия левой кнопки мыши
        if (isActive == true && !isRotating && !isReturning)
        {
            // Запуск поворота
            isRotating = true;
            rotationTimer = 0.0f;
        }
    }
}
