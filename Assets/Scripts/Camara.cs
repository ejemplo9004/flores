using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public float velRotacion;
    public float anguloX;
    public Transform pivote2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * velRotacion);
            anguloX += ( -Input.GetAxis("Mouse Y") * Time.deltaTime * velRotacion);
            anguloX = Mathf.Clamp(anguloX, 160f, 220f);
            pivote2.localEulerAngles = Vector3.right * anguloX;
        }
    }
}
