using UnityEngine;

public class Semilla : MonoBehaviour
{
    public GameObject flor;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        FlowersController fc = other.GetComponent<FlowersController>();
        if (fc != null)
        {
        print(other.name);
            if (!fc.viva && !fc.active)
            {
                fc.Sembrar(flor);
            }
        }
    }
}
