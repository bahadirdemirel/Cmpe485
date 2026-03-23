using UnityEngine;
using System.Collections;

public class TrapController : MonoBehaviour
{
    public float activeTime = 2.0f;     // Yukarýda bekleme süresi
    public float inactiveTime = 2.0f;   // Aþaðýda bekleme süresi
    public float moveDuration = 0.5f;   // Hareketin ne kadar süreceði (Yumuþaklýk)
    public float moveDistance = 1.5f;   // Yükselme miktarý

    private Vector3 startPosition;
    private Vector3 upPosition;

    void Start()
    {
        startPosition = transform.position;
        upPosition = startPosition + new Vector3(0, moveDistance, 0);
        StartCoroutine(TrapRoutine());
    }

    IEnumerator TrapRoutine()
    {
        while (true)
        {
            // 1. Yumuþakça Yukarý Çýk
            yield return StartCoroutine(MoveTrap(transform.position, upPosition));
            yield return new WaitForSeconds(activeTime);

            // 2. Yumuþakça Aþaðý Ýndir
            yield return StartCoroutine(MoveTrap(transform.position, startPosition));
            yield return new WaitForSeconds(inactiveTime);
        }
    }

    // Pozisyonlar arasý yumuþak geçiþ saðlayan yardýmcý Korutin
    IEnumerator MoveTrap(Vector3 start, Vector3 end)
    {
        float time = 0;
        while (time < moveDuration)
        {
            // Lerp ile iki nokta arasýný zamanla doldurur
            transform.position = Vector3.Lerp(start, end, time / moveDuration);
            time += Time.deltaTime;
            yield return null; // Bir sonraki kareye kadar bekle
        }
        transform.position = end; // Tam hedefe oturt
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().TriggerEndGame(false);
        }
    }
}