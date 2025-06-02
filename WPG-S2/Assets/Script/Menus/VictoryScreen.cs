using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VictoryScreen : MonoBehaviour
{
  public void NextLevel()
    {
        StartCoroutine(LoadLevel(2));
    }

    public void Quitgame()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void Retrygame()
    {
        StartCoroutine(LoadLevel(1));
    }

    IEnumerator LoadLevel(int index)
    {
        Time.timeScale = 1;
        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        while (!async.isDone)
        {
            yield return null;
        }
    }
   
}
