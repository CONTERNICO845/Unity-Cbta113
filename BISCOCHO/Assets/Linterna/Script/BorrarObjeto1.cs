using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorrarObjeto1 : MonoBehaviour
{
    public float tiempo;
    private void Start()
    {
        Destroy(gameObject, tiempo);
    }
}