using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverFlor : MonoBehaviour
{
    public GameObject flor;
    public Vector3 pSuelta = Vector3.one;
    public Vector3 pAgarrada;
    public Receptaculo r;

    public AgarrarObjetos ago;
    public void Inicializar(GameObject f)
    {
        flor = f;
        r = f.GetComponent<Receptaculo>();
    }

    public void PosicionarSuelta()
    {
        if (flor == null)
        {
            return;
        }
        flor.transform.localPosition = pSuelta;
        flor.transform.localEulerAngles = Vector3.zero;
    }
    public void PosicionarAgarrada()
    {
        if (flor == null)
        {
            return;
        }
        flor.transform.localPosition = pAgarrada;
    }


}
