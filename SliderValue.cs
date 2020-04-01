using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderValue : MonoBehaviour
{
    Slider slider;
    CreatePlayer Jump;
    // Start is called before the first frame update

    void Start()
    {
        slider = GetComponent<Slider>();    
        Jump = GameObject.Find("gameManager").GetComponent<CreatePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = (float)Jump.JumpPower / Jump.maxJump;
    }
}
