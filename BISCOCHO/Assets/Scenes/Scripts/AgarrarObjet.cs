using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarObjet : MonoBehaviour
{
    public Transform puntoAgarre;
    public GameObject objetoAgarrado;


    // Start is called before the first frame update
    void Start()
    {
     
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objetoAgarrado == null) // Si no se está agarrando ningún objeto
            {
                Collider[] colliders = Physics.OverlapSphere(puntoAgarre.position, 0.5f); // Detectar objetos cercanos al punto de agarre

                foreach (Collider collider in colliders)
                {
                    if (collider.CompareTag("Linterna")) // Verificar si el objeto detectado es la linterna
                    {
                        objetoAgarrado = collider.gameObject; // Guardar referencia al objeto agarrado
                        objetoAgarrado.transform.SetParent(puntoAgarre); // Establecer el punto de agarre como padre del objeto
                        objetoAgarrado.transform.localPosition = Vector3.zero; // Posicionar el objeto en el punto de agarre
                        objetoAgarrado.GetComponent<Rigidbody>().isKinematic = true; // Desactivar la física del objeto agarrado
                        break;
                    }
                }
            }
            else // Si ya se está agarrando un objeto
            {
                objetoAgarrado.transform.SetParent(null); // Liberar al objeto del punto de agarre
                objetoAgarrado.GetComponent<Rigidbody>().isKinematic = false; // Activar la física del objeto agarrado
                objetoAgarrado = null; // Reiniciar la referencia al objeto agarrado
            }
        }
    }

}
