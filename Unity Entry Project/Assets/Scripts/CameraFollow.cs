using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Takip edilecek hedef (Senin PlayerCube nesnen)
    public Transform target;

    // Kameranýn kübe olan uzaklýðý (Ofset)
    public Vector3 offset = new Vector3(0, 5, -10);

    // LateUpdate, tüm hareketler hesaplandýktan sonra kamerayý günceller
    void LateUpdate()
    {
        if (target != null)
        {
            // Kamerayý küpün pozisyonuna ofset ekleyerek taþý
            transform.position = target.position + offset;

            // Kameranýn her zaman kübe bakmasýný saðla (Opsiyonel)
            transform.LookAt(target);
        }
    }
}