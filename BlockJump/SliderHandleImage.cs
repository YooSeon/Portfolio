using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderHandleImage : MonoBehaviour
{
    public Sprite Sheep;
    public Sprite Duck;
    public Sprite Peng;

    Image handleImage;


    // Start is called before the first frame update
    void Start()
    {

        handleImage = GetComponent<Image>();

        if (GameObject.Find("GameManager").GetComponent<Distroy>().Name == 1)
        {
            handleImage.sprite = Sheep;
        }
        else if (GameObject.Find("GameManager").GetComponent<Distroy>().Name == 2)
        {
            handleImage.sprite = Duck;
        }
        else if (GameObject.Find("GameManager").GetComponent<Distroy>().Name == 3)
        {
            handleImage.sprite = Peng;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
