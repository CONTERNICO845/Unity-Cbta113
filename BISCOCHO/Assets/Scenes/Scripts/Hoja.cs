using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Hoja : MonoBehaviour
{
    [SerializeField] private float cantidadPuntos;

    [SerializeField] private Puntuaje Puntuaje;

    public GameObject PickUptext;

    public bool ingresso = false;
    public int totalHojas;
    void Start()
    {
        PickUptext.SetActive(false);
    }

    void Update()
    {
    
        if (ingresso == true)
        {
            PickUptext.SetActive(true);

            if (ingresso && Input.GetKey(KeyCode.E))
            {
                totalHojas += 1;
                Puntuaje.SumarPuntos(cantidadPuntos);
                Destroy(gameObject);
                PickUptext.SetActive(false);
            }
            //if(totalHojas >= 8) {

                //ganar(); //Aqui se pondria la funcion para ganar al moneto de  juntar 8 hojass
            
            ///}

        }

 

        
    }
        private void OnTriggerEnter(Collider other)
        {
        
            if(other.gameObject.tag == "Player")
            {

            ingresso = true;

            }

        }


        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {

            PickUptext.SetActive(false);
            ingresso = false;

            }
        }

}
