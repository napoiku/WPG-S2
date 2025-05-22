using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Skor : MonoBehaviour
{
    int fullGrow = 0;
    public TMP_Text fullGrowText;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject hotbar;    

    void Update() {
        if(fullGrow == 6) {
            Time.timeScale = 0;
            win.SetActive(true);
            hotbar.SetActive(false);
        }
    }

    public void iFullGrow() {
        fullGrow += 1;
        updateUI();
    }

    void updateUI() {
        fullGrowText.text = "Pohon Tumbuh Sempurna : " + fullGrow;
    }


}
