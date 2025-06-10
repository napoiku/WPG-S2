using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PlayOpeningVideo : MonoBehaviour
{
     public VideoClip videoClip;
    public string nextSceneName = "SampleScene";
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.clip = videoClip;

        videoPlayer.loopPointReached += EndReached;
        videoPlayer.Play();
    }

    void EndReached(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            videoPlayer.Stop();
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
