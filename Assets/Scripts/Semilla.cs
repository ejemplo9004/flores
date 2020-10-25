using UnityEngine;

public class Semilla : MonoBehaviour
{
    public GameObject flor;
    public FlowersController fc;
     
    private void OnTriggerEnter(Collider other)
    {
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
}
