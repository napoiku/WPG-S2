using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Plot : MonoBehaviour
{
    public bool isPlanted = false;
    public SpriteRenderer plant;
    public Sprite[] manggaStages, angsanaStages;
    int plantStage = 0;
    public float timeBtwStages = 5f;
    float timer;
    bool isScored = false;
    public Skor Skor;
    public bool IsPlanted => isPlanted;
    private int pilih;
    private int simpanPilih;


    // Update is called once per frame
    public void Update()
    {
        if (isPlanted)
        {
            timer -= Time.deltaTime;

            if (timer < 0 && (plantStage < manggaStages.Length-1 || plantStage < angsanaStages.Length-1))
            {
                timer = timeBtwStages;
                plantStage++;
                UpdatePlant();
            }
        }

        if(plantStage == 2 && isScored == false) {
            isScored = true;
            Skor.iFullGrow();
        }
    }

    public void Plant()
    {
        if (pilih != -1) {
        Debug.Log("Planted");
        simpanPilih = pilih; //menyimpan variabel pilih dari script pilihTana.cs supaya tidak berganti ketika menjalankan fungsi UpdatePlant
        isPlanted = true;
        plantStage = 0;
        UpdatePlant();
        timer = timeBtwStages;
        plant.gameObject.SetActive(true);
        }
        else {
            //memanggil UI "kamu belum memilih tanaman
        }
    }
    
    public void UpdatePlant()
    {
        if (simpanPilih == 0) { //pengkondisian jenis pohon mana yang ditanam sesuai inputan pemain
            plant.sprite = manggaStages[plantStage] ;
        } else if (simpanPilih == 1) {
            plant.sprite = angsanaStages[plantStage] ;
        }
    }

    public void ambilPilih(int x) { //mengambil inputan user dari script pilihTanam.cs
        pilih = x;
    }
}