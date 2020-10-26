using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharinganPosicion : MonoBehaviour
{
    public Transform victima;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = victima.position;
        transform.rotation = victima.rotation;
    }
}
