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
