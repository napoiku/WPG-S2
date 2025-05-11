using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Plot : MonoBehaviour
{
    public bool isPlanted = false;
    public SpriteRenderer plant;
    public Sprite[] manggaStages, angsanaStages, mahoniStages, tanjungStages;
    int plantStage = 0;
    public float timeBtwStages = 5f;
    float timer;
    bool isScored = false;
    public Skor Skor;
    public bool IsPlanted => isPlanted;
    private int pilih;
    private int simpanPilih;
    [SerializeField] private GameObject pilihBenih;
    public tunas tunas;
    private float clock;

    public void Start() {
        tunas = GameObject.Find("GameManager").GetComponent<tunas>();
    }

    // Update is called once per frame
    public void Update()
    {
        clock -= Time.deltaTime;

        if (isPlanted)
        {
            timer -= Time.deltaTime;

            if (timer < 0 && (plantStage < manggaStages.Length-1 || plantStage < angsanaStages.Length-1 || plantStage < mahoniStages.Length-1 || plantStage < tanjungStages.Length-1))
            { //supaya fungsi UpdatePlant tidak terpanggil lagi jika telah mencapai fase 3
                timer = timeBtwStages;
                plantStage++;
                UpdatePlant();
            }
        }

        if(plantStage == 2 && isScored == false) {
            isScored = true;
            Skor.iFullGrow();
        }

        if(pilih != -1) {
            pilihBenih.SetActive(false);
        }
    }

    public void Plant()
    {
        if (pilih != -1 && tunas.CekBiji(pilih) > 0) {
            Debug.Log("Planted");
            tunas.KurangiBiji(pilih);
            simpanPilih = pilih; //menyimpan variabel pilih dari script pilihTana.cs supaya tidak berganti ketika menjalankan fungsi UpdatePlant
            isPlanted = true;
            plantStage = 0;
            UpdatePlant();
            timer = timeBtwStages;
            plant.gameObject.SetActive(true);
        } else if(pilih != -1 && tunas.CekBiji(pilih) == 0) {
            // benihHabis.SetActive(true);
            // clock = 5;
            // if(clock > 0) {
            //     benihHabis.SetActive(false)
            // }
        } else {
            pilihBenih.SetActive(true);
        }
    }
    
    public void UpdatePlant() {
        switch(simpanPilih) {
            case 0:
            plant.sprite = manggaStages[plantStage];
            break;
            case 1:
            plant.sprite = angsanaStages[plantStage];
            break;
            case 2:
            plant.sprite = mahoniStages[plantStage];
            break;
            case 3:
            plant.sprite = tanjungStages[plantStage];
            break;
        }
    }

    public void ambilPilih(int x) { //mengambil inputan user dari script pilihTanam.cs
        pilih = x;
    }
}