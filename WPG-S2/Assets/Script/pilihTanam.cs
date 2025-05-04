using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pilihTanam : MonoBehaviour
{
    private int pilih = -1;
    public Hotbar hotbar;
    public Plot plot;

    // Update is called once per frame
    void Update() {
        cek();
        hotbar.rubahOutline(pilih); //mengirim ke script hotbar
    }

    void cek() { //cek inputan user
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            pilih = 0;
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            pilih = 1;
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            pilih = 2;
        } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
            pilih = 3;
        }
        plot.ambilPilih(pilih); //mengirim ke script plot
    }
}