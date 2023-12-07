using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAMOUSTRO2 : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;

    public GameObject target;

    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Link");
    }

    public void Comportamiento_Enemigo()
    {
        if(Vector3.Distance(transform.position, target.transform.position) > 5) {
            ani.SetBool("Run", false);
            // Incrementar el cronómetro en cada actualización
            cronometro += Time.deltaTime;

        if (cronometro >= 4)
        {
            // Reiniciar el cronómetro y seleccionar una nueva rutina
            cronometro = 0;
            rutina = Random.Range(0, 2);  // Cambiado de Random.Range(0, 2) a Random.Range(0, 3)
        }

        switch (rutina)
        {
            case 0:
                // Detenerse
                ani.SetBool("Walk", false);
                break;

            case 1:
                // Rotar en una dirección aleatoria
                grado = Random.Range(0, 360);
                angulo = Quaternion.Euler(0, grado, 0);
                rutina++;
                break;

            case 2:
                // Moverse en la dirección establecida
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                ani.SetBool("Walk", true);
                break;

            default:
                break;
        }
        }
        else
        {
            var LookPos = target.transform.position - transform.position;
            LookPos.y = 0;
            var rotation = Quaternion.LookRotation(LookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
            ani.SetBool("Walk", false );
            ani.SetBool("Run", true);
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        }
    }
    void Update()
    {
        Comportamiento_Enemigo ();
    }
}
