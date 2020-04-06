using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDis : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
