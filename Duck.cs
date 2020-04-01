using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Duck : MonoBehaviour
{
    public GameObject Oj;
    Animator anim;
    public Button one;
    public Button two;
    public Button three;

    AudioSource audio;
    GameObject sMgr;


    // Start is called before the first frame update
    void Start()
    {
        anim = Oj.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        sMgr = GameObject.Find("AudioMgr");
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).fullPathHash == Animator.StringToHash("Base Layer.jump"))
        {        
            if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
            {
                GameObject.Destroy(sMgr);
                SceneManager.LoadScene("GameScene");
            }
        }
    }

    public void ButtonOff()
    {
        one.interactable = false;
        two.interactable = false;
        three.interactable = false;
    }

    public void Soundon()
    {
        audio.PlayOneShot(audio.clip);
    }
}
