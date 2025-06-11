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
    [SerializeField] private GameObject quest;
    public StopMusic bgmController;
    public tunas total;
    [SerializeField] private GameObject lose;
    public blowerAttack blowerScript;
    private int lose1;


    void Update()
    {
        if (fullGrow == 6)
        {
            win.SetActive(true);
            hotbar.SetActive(false);
            quest.SetActive(false);
            bgmController.StopBGM();
            blowerScript.StopAttackAudio();
        }

        if (total.total <= 0 && lose1 == 0) //
        {
            lose.SetActive(true);
            hotbar.SetActive(false);
            quest.SetActive(false);
            bgmController.StopBGM();
            blowerScript.StopAttackAudio();
        }

        updateUI();
    }

    public void iFullGrow()
    {
        fullGrow += 1;
    }

    void updateUI()
    {
        fullGrowText.text = "Pohon Tumbuh Sempurna : " + fullGrow + "/6";
    }

    public void increase() {
        lose1 += 1;
    }
    
    public void decrease() {
        lose1 += 1;
    }

}
