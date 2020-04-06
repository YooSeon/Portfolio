using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamemgr : MonoBehaviour
{
    public float skyboxspeed;

    float time;

    Button btn;
    LogoSize logosize;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        logosize = GameObject.Find("Logo").GetComponent<LogoSize>();
        btn = GameObject.Find("StartButton").GetComponent<Button>();
        audio = GameObject.Find("StartButton").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * skyboxspeed);

        if(!logosize.sizecheck)
        {
            btn.interactable = true;
        }

        if(btn.interactable)
        {
            if (time < 0.5f)
            {
                btn.GetComponent<Image>().color = new Color(1, 1, 1, 1 - time);
            }
            else
            {
                btn.GetComponent<Image>().color = new Color(1, 1, 1, time);
                if (time > 1f)
                {
                    time = 0;
                }
            }

            time += Time.deltaTime * 0.5f;
        }

        if(audio.isPlaying)
        {
            if(audio.time >= audio.clip.length - 0.05f)
            {
               SceneManager.LoadScene("SelectScene");
            }
        }
    }


    public void SceneChang()
    {
        audio.Play();  
    }
}
