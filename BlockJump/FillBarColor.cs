using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FillBarColor : MonoBehaviour
{

    Image img;

    // Start is called before the first frame update
    void Awake()
    {
        img = GetComponent<Image>();

        if (GameObject.Find("GameManager").GetComponent<Distroy>().Name == 1)
        {
            img.color = new Color(255 / (float)255, 234 / (float)255, 201 / (float)255);
        }
        else if (GameObject.Find("GameManager").GetComponent<Distroy>().Name == 2)
        {
            img.color = new Color(245 / (float)255, 235 / (float)255, 18 / (float)255);
        }
        else if (GameObject.Find("GameManager").GetComponent<Distroy>().Name == 3)
        {
            img.color = new Color(39 / (float)255,128 / (float)255, 242 / (float)255);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
