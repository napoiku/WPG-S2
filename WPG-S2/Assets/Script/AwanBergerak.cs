using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwanBergerak : MonoBehaviour
{
    public float radius = 5f;     // Jarak lingkaran dari pusat
    public float speed = 1f;      // Kecepatan rotasi
    public Vector3 center;        // Titik pusat lingkaran

    private float angle = 0f;

    void Update()
    {
        angle += speed * Time.deltaTime; // Tambah sudut sesuai waktu

        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        transform.position = new Vector3(center.x + x, center.y + y, transform.position.z);
    }
}