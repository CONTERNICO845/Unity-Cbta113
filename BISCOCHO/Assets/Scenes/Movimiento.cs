using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SearchService;

public class Movimiento : MonoBehaviour {
    public float force = 90909;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("vertical");
        
        Vector3 vector = new Vector3(h, 0.5f, v);

        rb.AddForce(vector*force*Time.deltaTime);
    }
}
