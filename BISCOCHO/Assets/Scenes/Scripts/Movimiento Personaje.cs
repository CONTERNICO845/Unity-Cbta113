using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float correr = 9f;
    public CharacterController controlador;
    public float velocidad = 6f;
    public float gravedad = -20f;
    public Transform patas;
    public float DistanciaDelSuelo;
    public LayerMask MascaraDelPiso;
    public AudioSource pasos;
    private bool Hactivo;
    private bool Vactivo;
    public AudioSource corrersound;
    public AudioSource sonidosalto;
    Vector3 velocidadAbajo;
    bool EstaEnPiso;
    public float saltos = 2f;
    public float tiempoRecargaSalto = 1f;
    private float tiempoUltimoSalto;

    void Start()
    {
        tiempoUltimoSalto = -tiempoRecargaSalto; // Inicializa el tiempo del último salto para permitir el primer salto
    }

    // Update is called once per frame
    void Update()
    {
        EstaEnPiso = Physics.CheckSphere(patas.position, DistanciaDelSuelo, MascaraDelPiso);

        if (EstaEnPiso && velocidadAbajo.y <= 0)
        {
            velocidadAbajo.y = -2;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;
        controlador.Move(move * velocidad * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && EstaEnPiso && (Time.time - tiempoUltimoSalto > tiempoRecargaSalto))
        {
            if(sonidosalto != null && !sonidosalto.isPlaying)
            {
                sonidosalto.Play();
            }
            velocidadAbajo.y = Mathf.Sqrt(saltos * -2 * gravedad);
            tiempoUltimoSalto = Time.time;
        }

        velocidadAbajo.y += gravedad * Time.deltaTime;

        controlador.Move(move * velocidad * Time.deltaTime + velocidadAbajo * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {

            controlador.Move(move * correr * Time.deltaTime);

        }
        if (Input.GetButtonDown("Horizontal"))
        {
            if (Vactivo == false)
            {
                Hactivo = true;
                pasos.Play();
            }
          
        }
        if (Input.GetButtonDown("Vertical"))
        {
            if (Hactivo == false) {
                Vactivo = true;
                pasos.Play();
            }
           
        }
        if (Input.GetButtonUp("Horizontal"))
        {
            Hactivo = false;
            if(Vactivo==false)
            {
                pasos.Stop();
            }
           
        }
        if (Input.GetButtonUp("Vertical"))
        {
            Vactivo = false;
            if(Hactivo==false)
            {
                pasos.Stop();
            }
            
        }
       
    }
}