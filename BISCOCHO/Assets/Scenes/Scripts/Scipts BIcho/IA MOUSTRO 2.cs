using UnityEngine;

public class IAMOUSTRO2 : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;

    public GameObject jugador;
    public bool atacando;

    // Nuevo: Tiempo de espera inicial antes de que la IA reaccione
    public float tiempoEsperaInicial = 0f;
    private bool esperaInicialCompleta = false;

    public float rangoAtaque = 1.5f; // Nuevo: Establecer un rango de ataque

    void Start()
    {
        ani = GetComponent<Animator>();
        jugador = GameObject.Find("SeguimientoPLayer");

        // Nuevo: Iniciar temporizador de espera inicial
        Invoke("CompletarEsperaInicial", tiempoEsperaInicial);
    }

    // Nuevo: M�todo para completar la espera inicial
    private void CompletarEsperaInicial()
    {
        esperaInicialCompleta = true;
    }

    public void Comportamiento_Enemigo()
    {
        if (!esperaInicialCompleta)
        {
            // Todav�a esperando, no realizar comportamiento
            return;
        }

        // Nuevo: Implementar rango de visi�n
        if (Vector3.Distance(transform.position, jugador.transform.position) > 500)
        {
            // Calcular la direcci�n hacia el jugador
            Vector3 directionToPlayer = (jugador.transform.position - transform.position).normalized;

            // Calcular el �ngulo entre la direcci�n actual del enemigo y la direcci�n al jugador
            float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

            // Solo reaccionar si el jugador est� dentro de un cierto �ngulo de visi�n
            if (angleToPlayer < 90f)
            {
                ani.SetBool("Run", false);
                // Incrementar el cron�metro en cada actualizaci�n
                cronometro += Time.deltaTime;

                if (cronometro >= 4)
                {
                    // Reiniciar el cron�metro y seleccionar una nueva rutina
                    cronometro = 0;
                    rutina = Random.Range(0, 3);  // Cambiado de Random.Range(0, 2) a Random.Range(0, 3)
                }

                switch (rutina)
                {
                    case 0:
                        // Detenerse
                        ani.SetBool("Walk", false);
                        break;

                    case 1:
                        // Rotar en una direcci�n aleatoria
                        grado = Random.Range(0, 360);
                        angulo = Quaternion.Euler(0, grado, 0);
                        rutina++;
                        break;

                    case 2:
                        // Moverse en la direcci�n establecida
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                        transform.Translate(Vector3.forward * 4 * Time.deltaTime);
                        ani.SetBool("Walk", true);
                        break;
                }
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, jugador.transform.position) > rangoAtaque && !atacando)
            {
                // Rotaci�n suave hacia el jugador
                var rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(jugador.transform.position - transform.position), 0.05f);
                transform.rotation = rotation;

                ani.SetBool("Walk", false);
                ani.SetBool("Run", true);

                // Usar una velocidad m�s baja al seguir al jugador
                transform.Translate(Vector3.forward * 6 * Time.deltaTime);

                ani.SetBool("Attack", false);
                atacando = false; // Importante restablecer atacando cuando el jugador est� fuera del rango de ataque
            }
            else if (Vector3.Distance(transform.position, jugador.transform.position) <= rangoAtaque)
            {
                ani.SetBool("Walk", false);
                ani.SetBool("Run", false);
                ani.SetBool("Attack", true);
                atacando = true;
            }
            else
            {
                ani.SetBool("Walk", false);
                ani.SetBool("Run", true);
                ani.SetBool("Attack", false);
                atacando = false;
            }
        }
    }

    public void Final_Ani()
    {
        ani.SetBool("Attack", false);
        atacando = false;
    }

    void Update()
    {
        Comportamiento_Enemigo();
    }
}
