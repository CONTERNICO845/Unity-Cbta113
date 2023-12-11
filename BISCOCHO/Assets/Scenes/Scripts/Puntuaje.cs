using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;

public class Puntuaje : MonoBehaviour
{
    public float puntos;
    private TextMeshProUGUI TextMesh;
    public GameObject Ganar;
    private void Start()
    {
        TextMesh = GetComponent<TextMeshProUGUI>();
        Ganar.SetActive(false);
    }
    private void Update()
    {
        TextMesh.text = puntos.ToString("0/8");
    }

    public void SumarPuntos(float PuntosEntrada )
    {
        puntos += PuntosEntrada;
        if (puntos >= 3)
        {
            SceneManager.LoadScene("Tets");
            Ganar.SetActive(true);
        }
    }

    
            
}
