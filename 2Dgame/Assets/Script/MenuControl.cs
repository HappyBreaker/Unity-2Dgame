using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public AudioSource BGM;
    public AudioClip Sound;
    
    public void StartGame()
    {
        BGM.PlayOneShot(Sound,2);
        Invoke("DelayStartGame", 1.5f);
    }

    public void BackToMenu()
    {
        BGM.PlayOneShot(Sound, 2);
        Invoke("DelayMenuGame", 0.5f);
    }

    public void QuitGame()
    {
        BGM.PlayOneShot(Sound, 2);
        Invoke("DelayQuitGame", 0.5f);
    }

    #region [DelayGame]
    private void DelayStartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void DelayMenuGame()
    {
        SceneManager.LoadScene(0);
    }

    private void DelayQuitGame()
    {
        Application.Quit();
    }
    #endregion

}
