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
        yield return new WaitForSeconds(tiempoDesactivar/2f);
        for (int i = 0; i < objetosDesactivar.Length; i++)
        {
            objetosDesactivar[i].SetActive(false);
        }
        GameObject[] floresVivas = GameObject.FindGameObjectsWithTag("planta");
        for (int i = 0; i < floresVivas.Length; i++)
        {
            if (floresVivas[i].transform.parent == null)
            {
                floresVivas[i].SetActive(false);
            }
        }
        yield return new WaitForSeconds(tiempoDesactivar/2f);
        animator.enabled = false;
    }

    public void Iniciar()
    {
        iniciar = true;
    }
}
