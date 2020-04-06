using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCtrl : MonoBehaviour
{

    Rigidbody rb;
    public Material mat;
    public MeshRenderer Mr;
    AudioSource audio;

    public bool fall = false;
    public bool timeAttack = false;
    bool SoundOn = false;


    //public float waitTime;
    public float disTime = 0.0f;

    private void Awake()
    {

        Mr = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
        audio = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        Drop();
    }

    public void Drop()
    {
        if (fall)
        {

            disTime += (0.4f/ GameObject.Find("gameManager").GetComponent<CreateCube>().missingTime) * Time.deltaTime;

            if(disTime >= 0.5f && !SoundOn)
            {

                audio.PlayOneShot(audio.clip);
                SoundOn = true;
                
            }

            if(disTime >= 0.8f)
            {
                Destroy(this.gameObject);
                disTime = 1;
            }
            Mr.material.SetFloat("_DissolveAmount", disTime);
        }
    }
}
