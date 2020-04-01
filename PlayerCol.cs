using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCol : MonoBehaviour
{
    public bool clear = false;
    AudioSource audio;
    

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (clear || Input.GetKeyDown("a"))
        {
            if (GameObject.Find("GameManager").GetComponent<Distroy>().level < GameObject.Find("GameManager").GetComponent<LevelCtrl>().listLevelData.Count)
            {
                GameObject.Find("GameManager").GetComponent<Distroy>().level++;
                SceneManager.LoadScene("GameScene" + GameObject.Find("GameManager").GetComponent<Distroy>().level);
            }
            else
            {
                SceneManager.LoadScene("GameClear");
            }

        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        audio.Play();
        if (collision.gameObject.tag == "Block")
        {
            GameObject.Find("gameManager").GetComponent<CreatePlayer>().isJump = false;

            collision.gameObject.GetComponent<CubeCtrl>().fall = true;

        }
        if (collision.gameObject.tag == "Final")
        {
            clear = true;
        }
    }
}

