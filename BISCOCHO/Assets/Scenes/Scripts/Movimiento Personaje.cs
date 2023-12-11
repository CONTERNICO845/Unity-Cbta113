using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public CharacterController controlador;
    public float velocidadCaminar = 5f;
    public float velocidadCorrer = 7.5f;
    public float gravedad = -9.8f;
    public Transform patas;
    public float distanciaDelSuelo;
    public LayerMask mascaraDelPiso;
    Vector3 velocidadAbajo;
    bool estaEnPiso;
    public float potenciaSalto = 8f;
    public float tiempoRecargaSalto = 1f;
    private float tiempoUltimoSalto;

    void Start()
    {
        tiempoUltimoSalto = -tiempoRecargaSalto;
    }

    void Update()
    {
        estaEnPiso = Physics.CheckSphere(patas.position, distanciaDelSuelo, mascaraDelPiso);

        if (estaEnPiso && velocidadAbajo.y < 0)
        {
            velocidadAbajo.y = -2f; // Asegurar un pequeño impulso al tocar el suelo
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * y;
        float velocidadActual = Input.GetKey(KeyCode.LeftShift) ? velocidadCorrer : velocidadCaminar;

        controlador.Move(move * velocidadActual * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && estaEnPiso && (Time.time - tiempoUltimoSalto > tiempoRecargaSalto))
        {
            velocidadAbajo.y = Mathf.Sqrt(potenciaSalto * -2 * gravedad);
            tiempoUltimoSalto = Time.time;
        }

        velocidadAbajo.y += gravedad * Time.deltaTime;

        controlador.Move(velocidadAbajo * Time.deltaTime);
    }
}
