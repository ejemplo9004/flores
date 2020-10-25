using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planta : MonoBehaviour
{
    public float esperaInicial;
    public Vector2 esperasEntreFlores;
    public FlowersController fc;
    public Animator animator;
    public bool dePodar;
    public Transform posicionCrear;
    
    IEnumerator Start()
    {
        yield return new WaitForSeconds(esperaInicial);
        StartCoroutine(Esperando());
    }

    IEnumerator Esperando()
    {

        float tiempo;
        while (fc.viva)
        {
            yield return new WaitUntil(() => !dePodar);
            tiempo = Random.Range(esperasEntreFlores.x, esperasEntreFlores.y);
            yield return new WaitForSeconds(tiempo);
            GameObject f = Instantiate(fc.flor) as GameObject;
            f.transform.parent = posicionCrear;
            f.transform.localPosition = Vector3.zero;
            f.transform.localEulerAngles = Vector3.zero;
            dePodar = true;
        }
        animator.SetBool("viva", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
