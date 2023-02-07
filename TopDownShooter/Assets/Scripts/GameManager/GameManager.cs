using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject winLevel;
    [SerializeField] private GameObject restartLevel;
    [SerializeField] AudioSource fonMusic;
    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        GlobalEventManager.OnPlayerKill.AddListener(GetRestartLevel);
        fonMusic.Play();
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GetWinLevel()
    {
        winLevel.SetActive(true);
    }
    public void GetRestartLevel()
    {
        restartLevel.SetActive(true);
    }
}
