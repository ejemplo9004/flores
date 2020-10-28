using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] elementos;
    public int indice;
    public UnityEngine.UI.Text txtNumero;

    private void Start()
    {
        Actualizar();
    }

    public void Siguiente()
    {
        indice++;
        indice = Mathf.RoundToInt(Mathf.Clamp(indice, 0, elementos.Length - 1));
        Actualizar();
    }
    public void Anterior()
    {
        indice--;
        indice = Mathf.RoundToInt(Mathf.Clamp(indice, 0, elementos.Length - 1));
        Actualizar();
    }

    void Actualizar()
    {
        txtNumero.text = (indice + 1) + "/" + elementos.Length;
        for (int i = 0; i < elementos.Length; i++)
        {
            elementos[i].SetActive(indice == i);
        }
    }
}
