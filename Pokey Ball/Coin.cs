using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    float rotSpeed;
    public UICtrl UI;

    Transform rb;

    // Start is called before the first frame update
    void Start()
    {
        rotSpeed = 1.5f;
        rb = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.Rotate(0,0,rotSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.instance.coin++;
            UI.viewCoin = true;
            Destroy(this.gameObject);
        }
    }
}
