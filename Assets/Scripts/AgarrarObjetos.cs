using UnityEngine;
using UnityEngine.Events;

public class AgarrarObjetos : MonoBehaviour
{
    public LayerMask capas;
    public Vector3 posicionInicial;
    public Camera camara;
    public bool arrastrando;
    public UnityEvent accionSoltar;
    public UnityEvent accionAgarrar;
    public Animator animator;
    private void Start()
    {
        posicionInicial = transform.position;
        if (camara == null)
        {
            camara = Camara.singleton.camara;
        }
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
                if (animator!= null) animator.SetBool("activo", false);
            }
        }
    }

    private void OnMouseDown()
    {
        arrastrando = true;
        if (animator != null) animator.SetBool("activo", true);
        accionAgarrar.Invoke();
    }

    public void ReiniciarPosicion()
    {
        transform.position = posicionInicial;
    }
}
