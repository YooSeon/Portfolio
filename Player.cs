using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public static int Name; // 0 = Sheep , 1 = Duck, 2 = Peng
    public float speed = 3f;

    Animator anim;

    Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            tr.eulerAngles = new Vector3(0, 270, 0);
            tr.transform.position -= new Vector3(speed * Time.deltaTime,0,0);
            anim.SetBool("Walk", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            tr.eulerAngles = new Vector3(0, 90, 0);
            tr.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
    }


    
}
