using UnityEngine;

public class PauseButton : MonoBehaviour
{
    private bool isPause = false;

    [SerializeField]
    private GameObject pausePanel;
    public void Pause()
    {
        if (isPause)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
            isPause = false;
        }
        else
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
            isPause = true;
        }
    }
}