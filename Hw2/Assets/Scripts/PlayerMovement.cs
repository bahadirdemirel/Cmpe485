using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 150.0f; // Dönüþ hýzý
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Girdileri al
        float moveInput = Input.GetAxis("Vertical");   // W ve S (Ýleri-Geri)
        float rotationInput = Input.GetAxis("Horizontal"); // A ve D (Sað-Sol Dönüþ)

        // 1. DÖNÜÞ: Karakteri kendi ekseni (Y) etrafýnda döndür
        float rotation = rotationInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        // 2. HAREKET: Karakterin baktýðý yöne (forward) doðru hareket et
        // transform.forward karakterin baktýðý "yerel" ileri yönüdür.
        Vector3 moveDirection = transform.forward * moveInput * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + moveDirection);
    }
}