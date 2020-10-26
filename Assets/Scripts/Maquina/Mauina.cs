using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mauina : MonoBehaviour
{
    public Receptor r1;
    public Receptor r2;
    public AudioSource sonido;

    public Button btnFucionar;
    [Space]
    [Header("Creador")]
    [Space]
    public Mesh malla1;
    public Mesh malla2;
    [Range(0, 1)]
    public float t = 0.5f;
    public Mesh meshFinal;
    private Vector3[] v1;
    private Vector3[] v2;
    private Vector3[] vFinal;
    public SubPetalo petalo;
    public Texture2D t2DBase;
    public Texture2D t2Dmanchas;
    public GameObject prReceptaculo;
    public Transform pivotenNuevaFlor;
    public GameObject movedor;

    void FixedUpdate()
    {
        btnFucionar.interactable = r1.r != null && r2.r != null;
    }

    /////////////////// Creación de la tercera Flor
    
    public void IniciarFusionNuclear()
    {
        if (r1.r==null || r2.r==null)
        {
            return;
        }
        sonido.Play();
        Preparativos();
        CrearMalla();
        CrearTexturas();
        OrganizarPetalo();
        Finalizar();
    }
    void Preparativos()
    {
        malla1 = r1.r.petalo.malla;
        malla2 = r2.r.petalo.malla;
        v1 = malla1.vertices;
        v2 = malla2.vertices;
        meshFinal = new Mesh();
        meshFinal.vertices = malla1.vertices;
        meshFinal.triangles = malla1.triangles;
        meshFinal.normals = malla1.normals;
        meshFinal.uv = malla1.uv;
        meshFinal.name = "Malla generada";
    }

    public void CrearMalla()
    {
        v1 = malla1.vertices;
        v2 = malla2.vertices;
        vFinal = new Vector3[v1.Length];
        for (int i = 0; i < v1.Length; i++)
        {
            vFinal[i] = Vector3.Lerp(v1[i], v2[i], t);
        }
        meshFinal.vertices = vFinal;
        meshFinal.RecalculateBounds();
        meshFinal.RecalculateNormals();
    }

    public void CrearTexturas()
    {
        t2DBase = new Texture2D(r1.r.petalo.textura1.width, r1.r.petalo.textura1.height);
        t2Dmanchas = new Texture2D(r1.r.petalo.textura1.width, r1.r.petalo.textura1.height);
        for (int i = 0; i < t2DBase.width; i++)
        {
            for (int j = 0; j < t2DBase.height; j++)
            {
                Color c = Color.Lerp(
                    r1.r.petalo.textura1.GetPixel(i, j),
                    r2.r.petalo.textura1.GetPixel(i, j),
                    t);
                t2DBase.SetPixel(i, j, c);
                Color c2 = Color.Lerp(
                    r1.r.petalo.textura2.GetPixel(i, j),
                    r2.r.petalo.textura2.GetPixel(i, j),
                    t);
                t2Dmanchas.SetPixel(i, j, c2);
            }
        }
        t2DBase.Apply();
        t2Dmanchas.Apply();
    }

    public void OrganizarPetalo()
    {
        petalo = new SubPetalo();
        petalo.malla = meshFinal;
        petalo.textura1 = t2DBase;
        petalo.textura2 = t2Dmanchas;
        petalo.color1 = Color.Lerp(r1.r.petalo.color1, r2.r.petalo.color1, t);
        petalo.color2 = Color.Lerp(r1.r.petalo.color2, r2.r.petalo.color2, t);
        //petalo.AsignarMaterial(GetComponent<MeshRenderer>().material);
        //petalo.Inicializar();
        //GetComponent<MeshRenderer>().material = petalo.material;
    }


    public void Finalizar()
    {
        GameObject rcp = Instantiate(prReceptaculo, Vector3.zero, Quaternion.identity) as GameObject;
        Receptaculo rece = rcp.GetComponent<Receptaculo>();
        rece.petalo = petalo;
        rece.numeroPetalos = Mathf.RoundToInt((r1.r.numeroPetalos+r2.r.numeroPetalos)/2);
        rece.color = Color.Lerp(r1.r.color, r2.r.color, t);
        rece.aleatoreidad = (r1.r.aleatoreidad + r2.r.aleatoreidad)/2f;
        
        rcp.transform.parent = pivotenNuevaFlor;
        rcp.transform.localPosition = Vector3.zero;
        rcp.transform.localEulerAngles = Vector3.zero;
        PseudoEncocar(rcp.transform);
        r1.Usar();
        r2.Usar();
    }
    public void PseudoEncocar(Transform flor)
    {
        GameObject g = Instantiate(movedor, transform) as GameObject;
        g.transform.position = pivotenNuevaFlor.position;
        flor.parent = g.transform;
        flor.localPosition = Vector3.one;
        flor.GetComponent<Receptaculo>().autoDesactivar = true;
        Destroy(flor.GetComponent<Rigidbody>());
        flor.GetComponent<Collider>().enabled = false;
        g.GetComponent<MoverFlor>().Inicializar(flor.gameObject);
    }
}
