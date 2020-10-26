using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrquestaFinal : MonoBehaviour
{
    public bool iniciar = false;
    public float tiempoDesactivar;
    public Animator animator;
    public GameObject[] objetosDesactivar;


    IEnumerator Start()
    {
        yield return new WaitUntil(() => iniciar);
        animator.enabled = true;
        yield return new WaitForSeconds(tiempoDesactivar);
        animator.enabled = false;
        for (int i = 0; i < objetosDesactivar.Length; i++)
        {
            objetosDesactivar[i].SetActive(false);
        }
    }

    public void Iniciar()
    {
        iniciar = true;
    }
}
