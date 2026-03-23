using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject winLossPanel; // "Restart" butonu olan panel
    private AudioSource bgMusic;

    void Start()
    {
        Time.timeScale = 1f; // Oyun her baþladýðýnda zamaný normal akýþýna döndürür
        if (winLossPanel != null) winLossPanel.SetActive(false);

        bgMusic = GetComponent<AudioSource>();
    }

    public void TriggerEndGame(bool victory)
    {
        Debug.Log(victory ? "KAZANDIN!" : "KAYBETTÝN!");
        winLossPanel.SetActive(true); // Paneli göster 
        Time.timeScale = 0f; // Oyunu dondur
    }

    public void RestartButton() // Butona bu fonksiyonu baðla 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ToggleMusic()
    {
        if (bgMusic.isPlaying)
            bgMusic.Pause();
        else
            bgMusic.Play();
    }
}