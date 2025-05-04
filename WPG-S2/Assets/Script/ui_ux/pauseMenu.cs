using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
   public GameObject PausePanel;
   public static bool isPaused = false;

   public void Pause()
   {
    PausePanel.SetActive(true);
    Time.timeScale = 0;
    isPaused = true;
   }

   public void Countinue()
   {
    PausePanel.SetActive(false);
    Time.timeScale = 1;
    isPaused = false;
   }

   public void Exit()
   {
    Time.timeScale = 1;
    isPaused = false;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
}
