using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public CharacterController controlador;
    public float velocidad = 15f;
    public float gravedad = -10f;
    public Transform patas;
    public float DistanciaDelSuelo;
    public LayerMask MascaraDelPiso;
    Vector3 velocidadAbajo;
    bool EstaEnPiso;
    public float saltos = 2f;
    public float tiempoRecargaSalto = 2f; // Tiempo de recarga entre saltos
    private float tiempoUltimoSalto;

    void Start()
    {
        tiempoUltimoSalto = -tiempoRecargaSalto; // Inicializa el tiempo del último salto para permitir el primer salto
    }

    // Update is called once per frame
    void Update()
    {
        EstaEnPiso = Physics.CheckSphere(patas.position, DistanciaDelSuelo, MascaraDelPiso);

        if (EstaEnPiso && velocidadAbajo.y < 0)
        {
            velocidadAbajo.y = -2;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;
        controlador.Move(move * velocidad * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && EstaEnPiso && (Time.time - tiempoUltimoSalto > tiempoRecargaSalto))
        {
            velocidadAbajo.y = Mathf.Sqrt(saltos * -2 * gravedad);
            tiempoUltimoSalto = Time.time;
        }

        velocidadAbajo.y += gravedad * Time.deltaTime;

        controlador.Move(move * velocidad * Time.deltaTime + velocidadAbajo * Time.deltaTime);
    }
}
