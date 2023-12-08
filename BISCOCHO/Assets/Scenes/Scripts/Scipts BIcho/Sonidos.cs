using UnityEngine;

public class Sonidos : MonoBehaviour
{
    public GameObject jugador;
    [SerializeField] private AudioClip Heart;
    [SerializeField] private AudioClip Heart2;
    [SerializeField] private AudioClip Voces;
    [SerializeField] private AudioClip Correr;

    private AudioSource audioSourceHeart;
    private AudioSource audioSourceHeart2;
    private AudioSource audioSourceVoces;
    private AudioSource audioSourceCorrer;

    private float distanciaParaVolumenBajo = 50f;
    private float distanciaParaVolumenAltoHeart = 50f;  // Cambiado a 50f
    private float distanciaParaVolumenAltoOtros = 30f;   // Cambiado a 30f

    private void Start()
    {
        // Agregar cuatro AudioSource al objeto
        audioSourceHeart = gameObject.AddComponent<AudioSource>();
        audioSourceHeart2 = gameObject.AddComponent<AudioSource>();
        audioSourceVoces = gameObject.AddComponent<AudioSource>();
        audioSourceCorrer = gameObject.AddComponent<AudioSource>();

        // Configurar las propiedades iniciales de los AudioSources
        audioSourceHeart.clip = Heart;
        audioSourceHeart2.clip = Heart2;
        audioSourceVoces.clip = Voces;
        audioSourceCorrer.clip = Correr;

        audioSourceHeart.loop = true;
        audioSourceHeart2.loop = true;
        audioSourceVoces.loop = true;
        audioSourceCorrer.loop = true;
    }

    private void Update()
    {
        // Obtener la distancia al jugador
        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.transform.position);

        // Ajustar el volumen y reproducción según la distancia
        AjustarVolumenYReproduccionHeart(distanciaAlJugador);
        AjustarVolumenYReproduccionOtros(distanciaAlJugador);
    }

    private void AjustarVolumenYReproduccionHeart(float distancia)
    {
        float factorVolumen = Mathf.Clamp01((distanciaParaVolumenBajo - distancia) / (distanciaParaVolumenBajo - distanciaParaVolumenAltoHeart));

        audioSourceHeart.volume = factorVolumen;

        if (distancia <= distanciaParaVolumenAltoHeart)
        {
            if (!audioSourceHeart.isPlaying)
            {
                audioSourceHeart.Play();
            }
        }
        else
        {
            audioSourceHeart.Stop();
        }
    }

    private void AjustarVolumenYReproduccionOtros(float distancia)
    {
        float factorVolumen = Mathf.Clamp01((distanciaParaVolumenBajo - distancia) / (distanciaParaVolumenBajo - distanciaParaVolumenAltoOtros));

        audioSourceHeart2.volume = factorVolumen;
        audioSourceVoces.volume = factorVolumen;
        audioSourceCorrer.volume = factorVolumen;

        if (distancia <= distanciaParaVolumenAltoOtros)
        {
            if (!audioSourceHeart2.isPlaying)
            {
                audioSourceHeart2.Play();
            }

            if (!audioSourceVoces.isPlaying)
            {
                audioSourceVoces.Play();
            }

            if (!audioSourceCorrer.isPlaying)
            {
                audioSourceCorrer.Play();
            }
        }
        else
        {
            audioSourceHeart2.Stop();
            audioSourceVoces.Stop();
            audioSourceCorrer.Stop();
        }
    }
}
