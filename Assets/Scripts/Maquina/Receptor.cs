using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptor : MonoBehaviour
{
    public Mauina maquina;
    public ParticleSystem particulas;
    public Receptaculo r;
    public GameObject particulasUso;

    private void OnTriggerStay(Collider other)
    {
        if (r == null && other.CompareTag("planta"))
        {
            MoverFlor mf = other.GetComponent<MoverFlor>();
            if(mf != null && !mf.ago.arrastrando)
            {
                other.transform.parent = transform;
                other.transform.localPosition = Vector3.zero;
                r = mf.r;
                particulas.Play();
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (r == null && other.CompareTag("planta"))
        {
            r = null;
        }
    }

    public void Usar()
    {
        Destroy(r.gameObject);
        Instantiate(particulasUso, transform.position + Vector3.up*2, transform.rotation);
        particulas.Stop();
    }
}
