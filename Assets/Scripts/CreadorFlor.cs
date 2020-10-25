using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreadorFlor : MonoBehaviour
{
    public Mesh[] mallas;
    public MeshFilter previaPetalo;
    public Texture2D[] patrones;
    public RawImage imPreviaPatron;
    public SubPetalo petalo = new SubPetalo();

    public Color color1 = Color.white;
    public Image imColor1;
    public Color color2 = Color.white;
    public Image imColor2;
    public Color color3 = Color.white;
    public Image imColor3;

    public RenderTexture rt;

    public int numeroPetalos;
    public Text txtNumeroPetalos;

    public float aleatoreidad;

    public GameObject prReceptaculo;

    public Semilla semilla;

    float h = 0.5f;
    float s = 0;
    float v = 1;

    float h2 = 0.5f;
    float s2 = 0;
    float v2 = 1;

    float h3 = 0.5f;
    float s3 = 0;
    float v3 = 1;
    void Start()
    {

    }

    public void CambiarMalla(float c)
    {
        previaPetalo.mesh = mallas[Mathf.RoundToInt(c)];
        petalo.malla = mallas[Mathf.RoundToInt(c)];
    }
    public void CambiarPatron(float c)
    {
        imPreviaPatron.texture = patrones[Mathf.RoundToInt(c)];
        petalo.textura1 = patrones[Mathf.RoundToInt(c)]; 
    }

    public void CambiarHColor1(float c)
    {
        h = c;
        ActualizarC1();
    }
    public void CambiarSColor1(float c)
    {
        s = c;
        ActualizarC1();
    }
    public void CambiarVColor1(float c)
    {
        v = c;
        ActualizarC1();
    }
    void ActualizarC1()
    {
        color1 = Color.HSVToRGB(h, s, v);
        petalo.color1 = color1;
        imColor1.color = color1;
    }


    public void GenerarManchas()
    {
        RenderTexture.active = rt;
        Texture2D t2d = new Texture2D(rt.width, rt.height);
        t2d.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        t2d.Apply();
        petalo.textura2 = t2d;
    }


    public void CambiarHColor2(float c)
    {
        h2 = c;
        ActualizarC2();
    }
    public void CambiarSColor2(float c)
    {
        s2 = c;
        ActualizarC2();
    }
    public void CambiarVColor2(float c)
    {
        v2 = c;
        ActualizarC2();
    }
    void ActualizarC2()
    {
        color2 = Color.HSVToRGB(h2, s2, v2);
        petalo.color2 = color2;
        imColor2.color = color2;
    }

    public void NumeroPetalos(float c)
    {
        numeroPetalos = Mathf.RoundToInt(c);
        txtNumeroPetalos.text = numeroPetalos.ToString();
    }

    public void CambiarHColor3(float c)
    {
        h3 = c;
        ActualizarC3();
    }
    public void CambiarSColor3(float c)
    {
        s3 = c;
        ActualizarC3();
    }
    public void CambiarVColor3(float c)
    {
        v3 = c;
        ActualizarC3();
    }
    void ActualizarC3()
    {
        color3 = Color.HSVToRGB(h3, s3, v3);
        imColor3.color = color3;
    }

    public void CambiarAleatoreidad(float c)
    {
        aleatoreidad = c;
    }
    public void Finalizar()
    {
        GameObject rcp = Instantiate(prReceptaculo, Vector3.zero, Quaternion.identity) as GameObject;
        Receptaculo rece = rcp.GetComponent<Receptaculo>();
        rece.petalo = petalo;
        rece.numeroPetalos = numeroPetalos;
        rece.color = color3;
        rece.aleatoreidad = aleatoreidad;
        semilla.flor = rcp;
        rcp.transform.parent = semilla.pivoteFlor;
        rcp.transform.localPosition = Vector3.zero;
        rcp.transform.localEulerAngles = Vector3.zero;
        Destroy(gameObject);
    }
}
