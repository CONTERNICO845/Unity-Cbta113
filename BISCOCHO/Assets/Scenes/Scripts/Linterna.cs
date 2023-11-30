using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    Light linterna;

    void Start()
    {
        // Obtener la referencia al componente Light
        linterna = GetComponent<Light>();
    }

    void Update()
    {
        // Cambiar el estado de la linterna al presionar la tecla "L"
        if (Input.GetKeyDown(KeyCode.F))
        {
            linterna.enabled = !linterna.enabled; // Cambiar el estado de encendido/apagado
        }
    }
}

