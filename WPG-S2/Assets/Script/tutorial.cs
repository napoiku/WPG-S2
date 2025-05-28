using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    [SerializeField] private GameObject popup1;
    [SerializeField] private GameObject popup2;
    [SerializeField] private GameObject popup3;
    [SerializeField] private GameObject popup4;
    private int popupnum;
    // Start is called before the first frame update
    void Start()
    {
        popup1.SetActive(true);
        popupnum = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClick() {
        switch(popupnum) {
            case 1: popup1.SetActive(false);
                    popup2.SetActive(true);
                    popupnum = 2;
            break;
            case 2: popup2.SetActive(false);
                    popup3.SetActive(true);
                    popupnum = 3;
            break;
            case 3: popup3.SetActive(false);
                    popup4.SetActive(true);
                    popupnum = 4;
            break;
            case 4: popup4.SetActive(false);
                    //popup5.SetActive(true);
                    popupnum = 5;
            break;
            default:
            break;
        }

    }
}
