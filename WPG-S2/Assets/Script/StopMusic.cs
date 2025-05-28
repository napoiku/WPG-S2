using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource bgmSource1;
    public AudioSource bgmSource2;

    void Start()
    {
        bgmSource1.Play();
        bgmSource2.Play();
    }

    public void StopBGM()
    {
        bgmSource1.Stop();
        bgmSource2.Stop();
    }
}
