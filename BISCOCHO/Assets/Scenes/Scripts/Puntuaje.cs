using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntuaje : MonoBehaviour
{
    public float puntos;
    private TextMeshProUGUI TextMesh;

    private void Start()
    {
        TextMesh = GetComponent<TextMeshProUGUI>();  
    }
    private void Update()
    {
        float fraction = puntos / 8.0f;
        TextMesh.text = $"{fraction:N0}/8";
    }

    public void SumarPuntos(float PuntosEntrada )
    {
        puntos += PuntosEntrada;
    }
}
