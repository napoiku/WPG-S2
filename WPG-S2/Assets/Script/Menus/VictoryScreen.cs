using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VictoryScreen : MonoBehaviour
{
  
  public void Quitgame()
  {
    SceneManager.LoadSceneAsync(0);
  }
  public void Retrygame()
  {
    SceneManager.LoadSceneAsync(1);
  }
   
}
