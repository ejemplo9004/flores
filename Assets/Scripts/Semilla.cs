using UnityEngine;

public class Semilla : MonoBehaviour
{
    public GameObject flor;
    public FlowersController fc;
    public Transform pivoteFlor;
    public GameObject lienzo;
     
    private void OnTriggerStay(Collider other)
    {
        if (fc != null)
        {
            return;
        }
        FlowersController fc2 = other.GetComponent<FlowersController>();
        if (fc2 != null)
        {
            fc = fc2;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (fc = other.GetComponent<FlowersController>())
        {
            fc = null;
        }
    }

    public void Sembrar()
    {
        if (fc != null && !fc.viva && !fc.active)
        {
            fc.Sembrar(flor);
        }
    }
    private void OnMouseDown()
    {
        if (flor==null)
        {
            GameObject li = Instantiate(lienzo) as GameObject;
            li.GetComponent<CreadorFlor>().semilla = this;
        }
    }
}
