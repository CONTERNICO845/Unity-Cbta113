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
            
                manejarSonidoDeCorrer();
           
          
        }
        else
        {
          DetenerSonidoPasos();

        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;
        controlador.Move(move * velocidad * Time.deltaTime);
       

        if (Input.GetButtonDown("Jump") && EstaEnPiso && (Time.time - tiempoUltimoSalto > tiempoRecargaSalto))
        {
            Debug.Log("Salto detectado");
            velocidadAbajo.y = Mathf.Sqrt(saltos * -2 * gravedad);
            tiempoUltimoSalto = Time.time;
            sonidosalto.Play();
            manejarSonidoDeCorrer();
        }


        velocidadAbajo.y += gravedad * Time.deltaTime;

        controlador.Move(move * velocidad * Time.deltaTime + velocidadAbajo * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {

            controlador.Move(move * correr * Time.deltaTime);


        }
        //Sonido de pasos
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
            if (Hactivo == false)
            {
                Vactivo = true;
                pasos.Play();
                
            }

        }
        //Desactivar sonido de pasos si el jugador esta quieto
        if (Input.GetButtonUp("Horizontal"))
        {
            Hactivo = false;
            if (Vactivo == false)
            {
                pasos.Stop();
            }

        }
        if (Input.GetButtonUp("Vertical"))
        {
            Vactivo = false;
            if (Hactivo == false)
            {
                pasos.Stop();
            }

        }
        if (Input.GetButton("Horizontal") && Input.GetButtonDown("Jump"))
        {
            pasos.Stop();
            sonidosalto.Play();
           
        }
        if (Input.GetButton("Vertical") && Input.GetButtonDown("Jump"))
        {
            pasos.Stop();
            sonidosalto.Play();
          
          
        }
        if (Input.GetButtonDown("Horizontal") && Input.GetKey(KeyCode.LeftShift))
        {
            pasos.Stop();
            corrersound.Play();

        }

        if (Input.GetButtonDown("Vertical") && Input.GetKey(KeyCode.LeftShift))
        {
            pasos.Stop();
            corrersound.Play();

        }
      if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            corrersound.Stop();
        }



    }
    void manejarSonidoDeCorrer()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)&&!corrersound.isPlaying)
        {
            Debug.Log("Comenzando a correr");
            pasos.Stop();
            corrersound.Play();

        }
        if (!pasos.isPlaying && (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) && !Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Reproduciendo sonido de pasos");
            pasos.Play();
            corrersound.Stop();
        }
    }
    void DetenerSonidoPasos()
    {
        Debug.Log("Deteniendo sonidos de pasos");
        pasos.Stop();
       
    }
}
