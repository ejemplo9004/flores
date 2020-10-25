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
        fc = GetComponentInParent<FlowersController>();
        yield return new WaitForSeconds(esperaInicial);
        StartCoroutine(Esperando());
    }

    IEnumerator Esperando()
    {

        float tiempo;
        while (fc.viva)
        {
            yield return new WaitUntil(() => (!dePodar || !fc.viva));
            if (fc.viva)
            {
                tiempo = Random.Range(esperasEntreFlores.x, esperasEntreFlores.y);
                yield return new WaitForSeconds(tiempo);
                if (fc.flor != null)
                {
                    GameObject f = Instantiate(fc.flor) as GameObject;
                    f.transform.parent = posicionCrear;
                    f.transform.localPosition = Vector3.zero;
                    f.transform.localEulerAngles = Vector3.zero;
                    f.GetComponent<Receptaculo>().p = this;
                    dePodar = true;
                }
            }
        }
        animator.SetBool("viva", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
