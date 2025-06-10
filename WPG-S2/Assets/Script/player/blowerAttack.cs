using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blowerAttack : MonoBehaviour
{
    public Renderer attackArea; // digunakan untuk mengontrol visibilitas area serangan
    Collider2D mycollider; // untuk mendeklarasi mycollider dan untuk mendeteksi benturan dengan objek lain
    public Animator animator;
    public AudioSource audioPlayer;
    public AudioClip introClip;
    public AudioClip loopClip;

    private Coroutine playAudioCoroutine;
    private bool isAttacking = false;

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
            if (playAudioCoroutine != null)
            {
                StopCoroutine(playAudioCoroutine);
            }

            isAttacking = true;
            playAudioCoroutine = StartCoroutine(PlayIntroThenLoop());
            //fsfsfs
            attackArea.enabled = true; // aktifkan visual area serangan
            mycollider.enabled = true; // aktifkan collider area serangan
            animator.SetTrigger("Attack");

        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isAttacking = false; // Set flag menjadi false agar loop tidak dijalankan

            if (playAudioCoroutine != null)
                StopCoroutine(playAudioCoroutine);

            attackArea.enabled = false; // nonaktifkan visual area serangan
            mycollider.enabled = false; // nonaktifkan collider area serangan
            audioPlayer.Stop();
        }
    }

    IEnumerator PlayIntroThenLoop()
    {
        audioPlayer.clip = introClip;
        audioPlayer.loop = false;
        audioPlayer.volume = 0.8f;
        audioPlayer.Play();

        float timer = 0f;
        while (timer < introClip.length)
        {
            if (!isAttacking)
                yield break; // Hentikan coroutine jika tombol dilepas

            timer += Time.deltaTime;
            yield return null;
        }

        // Jika tombol masih ditekan setelah intro selesai
        if (isAttacking)
        {
            audioPlayer.clip = loopClip;
            audioPlayer.loop = true;
            audioPlayer.volume = 0.4f;
            audioPlayer.Play();
        }
    }
    
    public void StopAttackAudio()
    {
        isAttacking = false;

        if (playAudioCoroutine != null)
        {
            StopCoroutine(playAudioCoroutine);
            playAudioCoroutine = null;
        }

        audioPlayer.Stop();
        attackArea.enabled = false;
        mycollider.enabled = false;
    }
}
