using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class JumpBtnCtrl : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public bool isBtnDown = false;
    public float addJumpPower;


    CreatePlayer JumpPower;

    public void OnPointerDown(PointerEventData eventData)
    {
        isBtnDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isBtnDown = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        JumpPower = GameObject.Find("gameManager").GetComponent<CreatePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (isBtnDown)
        {
            JumpPower.JumpPower += (addJumpPower*Time.deltaTime);
            if(JumpPower.JumpPower >= JumpPower.maxJump)
            {
                JumpPower.JumpPower = JumpPower.maxJump;
            }       
        }
        else
        {
            JumpPower.JumpPower = 0f;
        }
    }
}
