using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverFlor : MonoBehaviour
{
    public GameObject flor;
    public Vector3 pSuelta = Vector3.one;
    public Vector3 pAgarrada;
    public void Inicializar(GameObject f)
    {
        flor = f;
    }

    public void PosicionarSuelta()
    {
        flor.transform.localPosition = pSuelta;
        transform.localEulerAngles = Vector3.zero;
    }
    public void PosicionarAgarrada()
    {
        flor.transform.localPosition = pAgarrada;
    }
}
