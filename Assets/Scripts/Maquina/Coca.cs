using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coca : MonoBehaviour
{
    public static Coca singleton;
    public float rangoX = 3;
    public float rangoZ = 6;
    public GameObject movedor;

    private void Awake()
    {
        singleton = this;
    }

    public void Encocar(Transform flor)
    {
        GameObject g = Instantiate(movedor, transform) as GameObject;
        g.transform.localPosition = new Vector3(Random.Range(-rangoX, rangoX), 1, Random.Range(-rangoZ, rangoZ));
        flor.parent = g.transform;
        flor.localPosition = Vector3.one;
        flor.GetComponent<Receptaculo>().enabled = false;
        Destroy(flor.GetComponent<Rigidbody>());
        flor.GetComponent<Collider>().enabled = false;
        g.GetComponent<MoverFlor>().Inicializar(flor.gameObject);
    }
}
