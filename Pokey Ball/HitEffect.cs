using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject hitEffect;
    public GameObject hitHole;

    public GameObject effect;
   
    GameObject TotalHithole;

    // Update is called once per frame

    private void Start()
    {

    }

    public void Update()
    {

           
        
    }

    public void OnEffect(float PosY , int type, Transform ray)
    {

        GameObject hole = hitHole;

        if (type == 1) // 홀, 이펙트 생성
        {
            Instantiate(hole, new Vector3(hole.transform.position.x, PosY, hole.transform.position.z),hole.transform.rotation,ray);

            Instantiate(effect, new Vector3(effect.transform.position.x, PosY, effect.transform.position.z),effect.transform.rotation);

        }
        else //이팩트만 생성
        {
            Instantiate(effect, new Vector3(effect.transform.position.x, PosY, effect.transform.position.z), effect.transform.rotation);
        }
    }


}
