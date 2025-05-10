using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blowerAttack : MonoBehaviour
{
    public Renderer attackArea; // digunakan untuk mengontrol visibilitas area serangan
    Collider2D mycollider; // untuk mendeklarasi mycollider dan untuk mendeteksi benturan dengan objek lain

    // Start is called before the first frame update
    void Start()
    {
        attackArea.enabled = false; // menonaktifkan visual area serangan
        mycollider = GetComponent<Collider2D>(); // mengambil componen collider2D dari gameobject
        mycollider.enabled = false; // menonaktifkan collider 
    }

    // Update is called once per frame
    void Update()
    {
        // if(pauseMenu.isPaused) return;
        if (Input.GetKeyDown(KeyCode.Mouse0)) // jika klik kiri mouse ditekan
        {
            attackArea.enabled = true; // aktifkan visual area serangan
            mycollider.enabled = true; // aktifkan collider area serangan
        } 

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            attackArea.enabled = false; // nonaktifkan visual area serangan
            mycollider.enabled = false; // nonaktifkan collider area serangan
        } 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
