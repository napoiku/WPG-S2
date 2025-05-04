using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Ysorter : MonoBehaviour
{
    public int sortingOrderBase = 5000; // angka besar agar bisa diatur dari atas ke bawah
    public float offset = 0f;           // kalau butuh offset khusus
    private SpriteRenderer Yrenderer;

    void Awake()
    {
        Yrenderer = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        Yrenderer.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset);
    }
}
