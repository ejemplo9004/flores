using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptaculo : MonoBehaviour
{
    public float tiempoNacer;
    public float tiempoFlorecer;
    public SubPetalo petalo;
    public int numeroPetalos;
    public Color color;
    public MeshRenderer malla;
    public GameObject petalosInstancias;
    public float aleatoreidad;

    IEnumerator Start()
    {
        malla.gameObject.SetActive(false);
        malla.material.color = color;
        yield return new WaitForSeconds(tiempoNacer);

        malla.gameObject.SetActive(true);
        yield return new WaitForSeconds(tiempoFlorecer);

        for (int i = 0; i < numeroPetalos; i++)
        {
            GameObject go = Instantiate(petalosInstancias, Vector3.zero, Quaternion.identity) as GameObject;
            Petalo p = go.GetComponent<Petalo>();
            p.petalo = petalo;
            p.aleatoreidadRotacion = new Vector2(-aleatoreidad, aleatoreidad);
            go.transform.Rotate(Vector3.up * 360 / numeroPetalos * i);
            go.transform.parent = transform;
        }
    }

}
