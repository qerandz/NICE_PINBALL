using UnityEngine;

public class Balls : MonoBehaviour
{
    public float maxSpeed = 15f; // Максимальная скорость шарика
    
    private bool isFrozen = true;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isFrozen)
            {
                Launch();
            }
        }
    }

    private void Launch()
    {
        float angle = Random.Range(0f, 360f);
        Vector2 direction = Quaternion.Euler(0f, 0f, angle) * Vector2.right;
        rb.simulated = true;
        rb.AddForce(direction, ForceMode2D.Impulse);
        isFrozen = false;
    }

    private void FixedUpdate()
    {
        // Проверка и ограничение скорости шарика
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Claw"))
        {
            isFrozen = true;
            rb.simulated = false;
        }
    }
}
