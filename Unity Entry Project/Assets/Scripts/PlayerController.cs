using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 10f;
    private AudioSource audioSource; // Ses bileþenini tutacak deðiþken

    void Start()
    {
        // Eðer Rigidbody atanmamýþsa otomatik olarak almayý dener
        if (rb == null) rb = GetComponent<Rigidbody>();

        audioSource = GetComponent<AudioSource>();
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

    void Update()
    {
        // 'M' tuþuna basýldýðýnda sesi aç veya kapat
        if (Input.GetKeyDown(KeyCode.M))
        {
            // Eðer sessizdeyse aç, açýksa sessize al (Tersine çevir)
            audioSource.mute = !audioSource.mute;
        }
    }
}