using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSize : MonoBehaviour
{
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 0.5f)
        {
            GetComponent<Image>().color = new Color(1, 1, 1, 1 - time);
        }
        else
        {
            GetComponent<Image>().color = new Color(1, 1, 1,time);
            if(time >1f)
            {
                time = 0;
            }
        }

        time += Time.deltaTime * 0.5f;

    }
}
