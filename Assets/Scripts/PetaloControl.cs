using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class PetaloControl : MonoBehaviour
{
    public Mesh malla1;
    public Mesh malla2;
    [Range(0,1)]
    public float t;
    public Mesh meshFinal;

    private MeshRenderer miRenderer;
    private MeshFilter miMFilter;
    private Vector3[] v1;
    private Vector3[] v2;
    private Vector3[] vFinal;

    public static Texture2D texturaFlotante;

    public SubPetalo petalo = new SubPetalo();
    public GameObject petalosInstancias;
    public int numeropetalos;

    private void Awake()
    {
        miRenderer = GetComponent<MeshRenderer>();
        miMFilter = GetComponent<MeshFilter>();
        v1 = malla1.vertices;
        v2 = malla2.vertices;
        meshFinal = new Mesh();
        meshFinal.vertices = malla1.vertices;
        meshFinal.triangles = malla1.triangles;
        meshFinal.normals = malla1.normals;
        meshFinal.uv = malla1.uv;
        
        meshFinal.name = "Malla generada";
    }
    void Start()
    {
        miMFilter.mesh = meshFinal;
        ActualizarMalla();
    }

    [ContextMenu("Crear Petalos")]
    public void CrearPetalos()
    {
        GameObject G20 = new GameObject();

        for (int i = 0; i < numeropetalos; i++)
        {
            GameObject go = Instantiate(petalosInstancias, Vector3.zero, Quaternion.identity) as GameObject;
            go.GetComponent<Petalo>().petalo = petalo;
            go.transform.Rotate(Vector3.up * 360/numeropetalos * i);
            go.transform.parent = G20.transform;
        }
        G20.name = "Flor" + Random.Range(0, 100);
    }

    [ContextMenu("Actualizar")]
    public void Actualizar()
    {
        ActualizarMalla();
        petalo.malla = meshFinal;
        petalo.textura2 = texturaFlotante;
        petalo.AsignarMaterial (GetComponent<MeshRenderer>().material);

        petalo.Inicializar();
        GetComponent<MeshRenderer>().material = petalo.material;
    }

    public void CalcularVFinal()
    {
        v1 = malla1.vertices;
        v2 = malla2.vertices;
        vFinal = new Vector3[v1.Length];
        for (int i = 0; i < v1.Length; i++)
        {
            vFinal[i] = Vector3.Lerp(v1[i], v2[i], t);
        }
    }

    void ActualizarMalla()
    {
        CalcularVFinal();
        meshFinal.vertices = vFinal;
        meshFinal.RecalculateBounds();
        meshFinal.RecalculateNormals();
    }

    void FixedUpdate()
    {
        ActualizarMalla();
    }
}


[System.Serializable]
public class SubPetalo
{
    public Mesh malla;
    public Material material;
    public Texture2D textura1;
    public Texture2D textura2;
    public Color color1;
    public Color color2;

    public void AsignarMaterial(Material m)
    {
        material = new Material(m);
    }

    public void Inicializar()
    {
        material.SetTexture("_Fondo2", textura2);
    }

}