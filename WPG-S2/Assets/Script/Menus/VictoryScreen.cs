using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VictoryScreen : MonoBehaviour
{
  
  public void Quitgame()
  {
    Time.timeScale = 1;
    SceneManager.LoadSceneAsync(0);
  }
  public void Retrygame()
  {
    Time.timeScale = 1;
    SceneManager.LoadSceneAsync(1);
  }
   
}
