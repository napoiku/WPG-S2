using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class plantHealth : MonoBehaviour
{
    public Slider healthBar; // Ganti dari Image ke Slider
    public float healthAmount = 100f;
    public Plot plot;

    void Start()
    {
        // Pastikan value slider di-set saat awal
        healthBar.maxValue = 100f;
        healthBar.value = healthAmount;
    }

    void Update()
    {
        if (healthAmount <= 0)
        {
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            plot.dead();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (plot != null && plot.IsPlanted && plot.GetStage() < 2) // hanya bisa diserang jika stage < 2
            {
                TakeDamage(20f);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100); // Pastikan tidak negatif
        healthBar.value = healthAmount;
    }
}

