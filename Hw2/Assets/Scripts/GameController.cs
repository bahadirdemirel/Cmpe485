using UnityEngine;

public class GameController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            FindObjectOfType<GameManager>().TriggerEndGame(true);
        }
    }
}