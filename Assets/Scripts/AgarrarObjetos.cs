using UnityEngine;
using UnityEngine.Events;

public class AgarrarObjetos : MonoBehaviour
{
    public LayerMask capas;
    public Vector3 posicionInicial;
    public Camera camara;
    public bool arrastrando;
    public UnityEvent accionSoltar;
    private void Start()
    {
        posicionInicial = transform.position;
    }

    private void Update()
    {
        if (arrastrando)
        {
            RaycastHit hit;
            Ray rayo = camara.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayo,out hit,1000f,capas))
            {
                transform.position = hit.point;
            }
            if (Input.GetMouseButtonUp(0))
            {
                arrastrando = false;
                accionSoltar.Invoke();
            }
        }
    }

    private void OnMouseDown()
    {
        arrastrando = true;
    }

    public void ReiniciarPosicion()
    {
        transform.position = posicionInicial;
    }
}
