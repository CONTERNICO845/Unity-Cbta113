using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Camaracontroler : MonoBehaviour { 

    public GameObject jugador;

    private Vector3 offset; 

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - jugador.transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = jugador.transform.position + offset;
    }
}
