using UnityEngine;

public class ClawController : MonoBehaviour
{
    public bool sty = false;
    public static ClawController instance { get; set; }
    private void Start()
    {
        instance = this;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) )
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("Claw"))
            {
                LaunchBall();
            }
            sty = true;
        }
    }

    private void LaunchBall()
    {
        // Логика выпуска шарика
        // ...
    }
}
