using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Fail : MonoBehaviour
{
    GameObject Amgr;
    AudioSource audio;

    bool SoundOn = false;

    private void Start()
    {
        Amgr = GameObject.Find("AudioMgr");
        audio = GetComponent<AudioSource>();
        GameObject.Destroy(Amgr);
    }

    private void Update()
    {
        if(!SoundOn)
        {
            audio.PlayOneShot(audio.clip);
            SoundOn = true;
        }
    }

    public void SceneChang()
    {
        SceneManager.LoadScene("StartScene");
    }
}
