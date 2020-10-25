using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class Petalo : MonoBehaviour
{
    public SubPetalo petalo;

    private MeshRenderer miRenderer;
    private MeshFilter miMFilter;
    public Vector2 aleatoreidadRotacion;
    bool escalar = false;
    float escala = 0;
    private void Awake()
    {
        miRenderer = GetComponent<MeshRenderer>();
        miMFilter = GetComponent<MeshFilter>();
    }
    private void Start()
    {
        if (petalo!=null)
        {
            miMFilter.mesh = petalo.malla;
            miRenderer.material.SetTexture("_Fondo", petalo.textura1);
            miRenderer.material.SetTexture("_Fondo2", petalo.textura2);
            miRenderer.material.SetColor("_Color1", petalo.color1);
            miRenderer.material.SetColor("_Color2", petalo.color2);
            transform.Rotate(AletoRota(), 0, 0);
        }
        transform.localScale = Vector3.zero;
        Invoke("IniciarEscalado", Random.Range(0, 0.5f));
    }

    void IniciarEscalado()
    {
        escalar = true;
    }

    private void Update()
    {
        if (escalar && escala<1)
        {
            escala += Time.deltaTime*2;
            transform.localScale = Vector3.one * escala;
        }
    }

    public float AletoRota()
    {
        return Random.Range(aleatoreidadRotacion.x, aleatoreidadRotacion.y);
    }
}
