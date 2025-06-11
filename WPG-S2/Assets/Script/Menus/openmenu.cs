using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class openmenu : MonoBehaviour
{
    [SerializeField] GameObject GameMenu;
    [SerializeField] GameObject Hotbar;
    [SerializeField] GameObject Tutorial;
    private bool isPaused = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
        GameMenu.SetActive(!GameMenu.activeSelf);
        Hotbar.SetActive(!Hotbar.activeSelf);
        Tutorial.SetActive(!Tutorial.activeSelf);
        TogglePause();

        }

    }

    public void MainMenu()
    {
    TogglePause();
    SceneManager.LoadSceneAsync(0);
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void resume(){
        TogglePause();
    }


}