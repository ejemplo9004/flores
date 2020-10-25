using UnityEngine;
using UnityEngine.Events;

public class AgarrarObjetos : MonoBehaviour
{
    private float posicionY;
    Vector3 compensar;
    bool agarrando;
    public Camera CamaraPrincipal;
    [Space]
    [SerializeField]
    public UnityEvent comienzoDeAgarre;
    [SerializeField]
    public UnityEvent finDeAgarre;
    private void Start()
    {
        posicionY = CamaraPrincipal.WorldToScreenPoint(transform.position).z;
    }
    private void Update()
    {
        if (agarrando)
        {
            Vector3 posicion = new Vector3(Input.mousePosition.x, Input.mousePosition.y, posicionY);
            transform.position = CamaraPrincipal.ScreenToWorldPoint(posicion + new Vector3(compensar.x, compensar.y));
        }
    }

    private void OnMouseDown()
    {
        if (!agarrando)
        {
            ComienzoDeAgarre();
        }
    }
    private void OnMouseUp()
    {
        FinDeAgarre();
    }
    public void ComienzoDeAgarre()
    {
        comienzoDeAgarre.Invoke();
        agarrando = true;
        compensar = CamaraPrincipal.WorldToScreenPoint(transform.position) - Input.mousePosition;
    }

    public void FinDeAgarre()
    {
        finDeAgarre.Invoke();
        agarrando = false;
    }
}
