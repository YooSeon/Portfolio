using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LogoSize : MonoBehaviour
{

    public float speed;    

    public bool sizecheck = true;
    bool rotatDuck = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (sizecheck)
        {
            transform.localScale += Vector3.one * 40 * Time.deltaTime;
            if (transform.localScale.x > Vector3.one.x * 50)
            {
                transform.localScale = Vector3.one * 50;
                rotatDuck = true;
                sizecheck = false;
            }
        }

        if(rotatDuck)
        {
            transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
        }
    }
}
