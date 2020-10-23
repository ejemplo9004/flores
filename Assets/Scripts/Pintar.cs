using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pintar : MonoBehaviour
{
    Vector3 ultimaPosicion = Vector3.zero;
    public GameObject brocha;
    [Range(0.1f, 2f)]
    public float tamaño = 0.5f;
    public Camera camara;
    public GameObject vistaPrevia;
    public RenderTexture rt;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray rayo = camara.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(rayo,out hit))
            {
                if (hit.point != ultimaPosicion)
                {
                    ultimaPosicion = hit.point;
                    GameObject gi = Instantiate(brocha, hit.point, Quaternion.identity, transform) as GameObject;
                    gi.transform.localScale = Vector3.one * tamaño/10f;
                    gi.transform.Translate(Vector3.back * 0.001f);
                }
            }
        }
    }

    public void CambiarTamaño(float t)
    {
        tamaño = t;
        vistaPrevia.transform.localScale = t *Vector3.one;
    }

    public void BorrarLienzo()
    {
        MeshRenderer[] gos = gameObject.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < gos.Length; i++)
        {
            if(gos[i].gameObject != gameObject) Destroy(gos[i].gameObject);
        }
    }

    public void Guardar()
    {
        RenderTexture.active = rt;
        Texture2D t2d = new Texture2D(rt.width, rt.height);
        t2d.ReadPixels(new Rect(0, 0, rt.width, rt.height),0,0);
        t2d.Apply();
        PetaloControl.texturaFlotante = t2d;
    }
}
