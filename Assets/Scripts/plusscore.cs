using UnityEngine;

public class plusscore : MonoBehaviour
{
    public float impulseForce = 1f; // Величина импульса

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (ballRb != null)
            {
                ContactPoint2D contactPoint = collision.contacts[0];
                Vector2 direction = contactPoint.point - (Vector2)transform.position;

                // Применяем импульсное ускорение к шарику
                ballRb.AddForce(direction.normalized * impulseForce, ForceMode2D.Impulse);
            }

        }
        score.instance.PlusCurrentScore();

    }
}
