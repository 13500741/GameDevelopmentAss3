using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{
    public static SoundMgr inst;
    public bool dontDestroy = true;
    [SerializeField]
    private AudioSource bgmSource;

    private void Awake()
    {
        if (dontDestroy)
        {
            if (inst == null)
                DontDestroyOnLoad(gameObject);
            else
            {
                Destroy(gameObject);
                return;
            }
        }
        inst = this;
    }
    void Start()
    {
    
    }
    public void BGMPlay()
    {
        bgmSource.Play();
    }

    public void BGMPlay(string _name, bool _isloop = true)
    {
        AudioClip clip = Resources.Load<AudioClip>("Sounds/" + _name);
        bgmSource.clip = clip;
        bgmSource.loop = _isloop;
        bgmSource.Play();
    }
  
    public void BGMStop()
    {
        bgmSource.Stop();
    }
}
