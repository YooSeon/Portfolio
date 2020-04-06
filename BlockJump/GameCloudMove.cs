using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCloudMove : MonoBehaviour
{

    Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //-20
        tr.transform.position += new Vector3(-20.0f * Time.deltaTime, 0, 0);
    }


}
