using UnityEngine;
using System.Collections; // Coroutine için gerekli 

public class GuardPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2.0f;
    public float waitTime = 1.0f;

    void Start()
    {
        // Devriye hareketini Coroutine ile baþlatýyoruz 
        StartCoroutine(PatrolRoutine());
    }

    IEnumerator PatrolRoutine()
    {
        Transform target = pointB;

        while (true)
        {
            // Hedefe doðru hareket et 
            while (Vector3.Distance(transform.position, target.position) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                yield return null; // Bir sonraki kareye kadar bekle
            }

            // Hedefe ulaþýnca bekle 
            yield return new WaitForSeconds(waitTime);

            // Hedef deðiþtir
            target = (target == pointA) ? pointB : pointA;
        }
    }

    // Oyuncu muhafýza çok yaklaþýrsa veya deðerse ölür [cite: 24, 28]
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Muhafýz seni yakaladý!");
            // GameManager üzerinden oyun sonu ekranýný tetikle [cite: 44, 45]
            FindObjectOfType<GameManager>().TriggerEndGame(false);
        }
    }
}