using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCloud : MonoBehaviour
{
    Transform tr;

    public float x;
    public float y;
    public float z;


    // Start is called before the first frame update
    void Start()
    {

        tr = GetComponent<Transform>();

        x = tr.position.x;
        y = tr.position.y;
        z = tr.position.z;
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    void OnBecameInvisible() //화면밖으로 나가 보이지 않게 되면 호출이 된다.
    {
        // Destroy(this.gameObject); //객체를 삭제한다.

        float newX = tr.position.x;


        tr.position = new Vector3(x - newX ,y,z);
    }
}
