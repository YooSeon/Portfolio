using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{



    [SerializeField]
    float shakeAnt = 0;
    float maxShake = 0;

    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("Bar").GetComponent<Test>().Shake)
        {
            if (shakeAnt >= maxShake)
            {
                shakeAnt = maxShake;
            }
            shakeAnt += (GameObject.Find("Bar").GetComponent<Test>().pressedPosition / maxShake) * Time.deltaTime;

            Vector3 newPos = Random.insideUnitSphere * (Time.deltaTime * shakeAnt);
            newPos.y = GameObject.Find("PlayerPos").transform.position.y;
            newPos.z = GameObject.Find("PlayerPos").transform.position.z;
            GameObject.Find("PlayerPos").transform.position = newPos;
        }
        else shakeAnt = 0f;


        if (GameManager.instance.OverPower)
        {
            GetComponent<Rigidbody>().mass = 0.1f;
            GetComponent<TrailRenderer>().startColor = Color.red;
            GetComponent<TrailRenderer>().endColor = Color.red;
            maxShake = 10f;

        }
        else
        {
            GetComponent<Rigidbody>().mass = 1f;
            GetComponent<TrailRenderer>().startColor = Color.white;
            GetComponent<TrailRenderer>().endColor = Color.white;
            maxShake = 5f;
        }


    }

    public void shakeMe()
    {
        StartCoroutine("ShakeNow");
    }

    IEnumerator ShakeNow()
    {
        Vector3 originalPos = GameObject.Find("PlayerPos").transform.position;

        yield return new WaitForSeconds(0.75f);

        GameObject.Find("PlayerPos").transform.position = originalPos;
    }
}
