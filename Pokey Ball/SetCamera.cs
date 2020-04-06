using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCamera : MonoBehaviour
{
    // Start is called before the first frame update
    Transform target;
    Transform tr;
    Transform OldPos;

    float setCamY;

    float disCamX;
    float disCamY;
    float disCamz;

    
    Vector3 targetPosition;

    float x;
    float y;
    float z;

    bool CamPos = true;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        setCamY = tr.position.y - target.position.y;
        OldPos = tr;

    }

    private void FixedUpdate()
    {

        if (!GameObject.Find("Bar").GetComponent<Test>().Shake)
        {
            //Vector3 vector3 = new Vector3(-1.63f, target.position.y + setCamY, 5.99f);
            //transform.position = new Vector3(vector3.x,target.position.y + setCamY,vector3.z);

            Vector3 vector3 = new Vector3(-1.63f, 4.86f, 5.99f);
            targetPosition = new Vector3(vector3.x, target.position.y + setCamY, vector3.z);
            tr.position = Vector3.Lerp(tr.position, targetPosition, 10f * Time.deltaTime);
            CamPos = true;
        }
        else
        {
            if (CamPos)
            {
                if (!GameManager.instance.OverPower)
                {
                    x = transform.position.x - 0.274f;
                    y = transform.position.y + 0.4f;
                    z = transform.position.z + 1.15f;
                }
                else
                {
                    x = transform.position.x - 2.86f;
                    y = transform.position.y + 6.61f;
                    z = transform.position.z + 11.09f;
                }
            }
            CamPos = false;

            transform.position = Vector3.Lerp(transform.position, new Vector3(x,y,z), 1.5f * Time.deltaTime);
        }
    }

}
// -1.636   , 4.86  , 5.99
// -1.91    , 5.26  , 7.14