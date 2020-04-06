using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCol : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.instance.currentPlayerState = PlayerState._GAMEOVER;
        }
    }

}
