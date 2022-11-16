using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class IntroMovie : MonoBehaviour
{
    public VideoClip[] clips;
    public VideoPlayer Vp;
    public SceneManager_ sm;
    public int clipNum;
    public RenderTexture rend;
    private bool _isStarted;

    void Start()
    {
        clipNum = 0;
        _isStarted = false;
        Vp.Play();
        rend.Release();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            clipNum++;
            Vp.clip = clips[clipNum];
            Vp.Play();
        }
        if (clipNum == 18 && !_isStarted)
        {
            _isStarted = true;
            Invoke("NextScene_", 4.0f);
        }
    }

    void NextScene_()
    {
        sm.NextScene();
    }
}
