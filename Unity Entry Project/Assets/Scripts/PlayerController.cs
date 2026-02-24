using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 10f;

    void Start()
    {
        // Eðer Rigidbody atanmamýþsa otomatik olarak almayý dener
        if (rb == null) rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Yön tuþlarý veya WASD giriþlerini al (-1 ile 1 arasý deðer döner)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Hareket yönünü belirle
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Kübe hareket yönünde kuvvet uygula
        rb.AddForce(movement * speed);
    }
}