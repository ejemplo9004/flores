using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptor : MonoBehaviour
{
    public Mauina maquina;
    public Receptaculo r;

    private void OnTriggerEnter(Collider other)
    {
        if (r == null && other.CompareTag("planta"))
        {
            if(other.GetComponent<Receptaculo>() != null)
            {
                other.transform.parent = transform;
                other.transform.localPosition = Vector3.zero;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (r==null && other.CompareTag("planta"))
        {
            r = other.GetComponent<Receptaculo>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (r == null && other.CompareTag("planta"))
        {
            r = null;
        }
    }
}
