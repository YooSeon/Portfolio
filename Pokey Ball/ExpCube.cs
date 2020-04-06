using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpCube : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject m_goPrefab = null;
    [SerializeField] float m_force = 0;
    [SerializeField] Vector3 m_offset = Vector3.zero;

    GameObject t_clone;

    public void Start()
    {
       
    }

    public void ExpCubeFx()
    {
        gameObject.SetActive(false);
        t_clone = Instantiate(m_goPrefab, transform.position, Quaternion.identity);
        Rigidbody[] t_rb = t_clone.GetComponentsInChildren<Rigidbody>();
        for (int i=0;i<t_rb.Length;i++)
        {
            t_rb[i].AddExplosionForce(m_force, transform.position + m_offset, 10f);
        }
        Invoke("DestoryCube", 1f);
    }

    void DestoryCube()
    {
        Destroy(t_clone);
        Destroy(this.gameObject);
    }
}
