﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public float velRotacion;
    public float anguloX;
    public Transform pivote2;
    public Transform pivote3;
    public float rangoMovimiento;
    public float velMovimiento;

    float posicionMovimientoX;
    float posicionMovimientoZ;

    public Transform[] posiciones;
    public int indicePosicion;
    public Camera camara;

    public static Camara singleton;
    // Start is called before the first frame update
    void Awake()
    {
        singleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, posiciones[indicePosicion].position, 0.1f);
        if (Input.GetMouseButton(2))
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                posicionMovimientoX -= (Input.GetAxis("Mouse X") * Time.deltaTime * velMovimiento);
                posicionMovimientoX = Mathf.Clamp(posicionMovimientoX, -rangoMovimiento, rangoMovimiento);
                posicionMovimientoZ += (Input.GetAxis("Mouse Y") * Time.deltaTime * velMovimiento);
                posicionMovimientoZ = Mathf.Clamp(posicionMovimientoZ, -rangoMovimiento, rangoMovimiento);
                pivote3.localPosition = new Vector3(posicionMovimientoX, 0, posicionMovimientoZ);
            }
            else
            {
                transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * velRotacion);
                anguloX += ( -Input.GetAxis("Mouse Y") * Time.deltaTime * velRotacion);
                anguloX = Mathf.Clamp(anguloX, 160f, 220f);
                pivote2.localEulerAngles = Vector3.right * anguloX;
            }
        }
    }

    public void CambiarIndice(int i)
    {
        indicePosicion = i;
    }
}
