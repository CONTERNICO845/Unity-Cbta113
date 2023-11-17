using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Rigidbody rb;
    [Range(1, 10)]
    public float velocidad = 10;
    public float salto = 7;

    

    // Start is called before the first frame update
    void Start()
    {
         rb= GetComponent<Rigidbody>();
    }

    // FixedUpdate is called once per physics update
    void FixedUpdate()
    {
        float movimientoh = Input.GetAxis("Horizontal");
        float movimientov = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoh * velocidad, 0.0f, movimientov * velocidad);

        rb.AddForce(movimiento);

        if (Input.GetButton("Jump") && isSuelo()){
            rb.velocity += Vector3.up * salto;
        }
    }
    private bool isSuelo()
    {
        Collider[] colisiones = Physics.OverlapSphere(transform.position, 0.5f);
         
        foreach (Collider colsion in colisiones)
        {
            if(colsion.tag == "Suelo")
            {
                return true;
            }
        }
        return false;
    }
}
