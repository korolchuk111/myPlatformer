using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public bool isPause;
    public GameObject pausePanel;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
            //відкриється по настисканню на esc також
        {
            if (isPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            
        }
        
    }
    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        isPause = false;
    }
    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        isPause = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameMenu");
    }
}