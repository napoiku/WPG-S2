using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
// using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class plantHealth : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(float demage)
    {
        healthAmount -= demage;
        healthBar.fillAmount = healthAmount / 100f;
    }
}
