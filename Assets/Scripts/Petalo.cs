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
            miRenderer.material = petalo.material;
        }
    }
}
