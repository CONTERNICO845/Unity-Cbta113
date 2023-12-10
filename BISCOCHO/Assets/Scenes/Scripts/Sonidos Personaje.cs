using UnityEngine;

public class SonidosPersonaje : MonoBehaviour
{
    [SerializeField] private AudioClip pasosClip;
    [SerializeField] private AudioClip saltoClip;
    [SerializeField] private AudioClip correrClip;

    private AudioSource pasosAudio;
    private AudioSource saltoAudio;
    private AudioSource correrAudio;

    private bool estaCaminando;
    private bool estaCorriendo;

    private float tiempoEsperaCaminar = 0.5f; // Medio segundo
    private float tiempoEsperaCorrer = 0.2f; // Un quinto de segundo

    private bool saltoAudioReproducido;

    void Start()
    {
        // Agregar tres AudioSource al objeto
        pasosAudio = gameObject.AddComponent<AudioSource>();
        saltoAudio = gameObject.AddComponent<AudioSource>();
        correrAudio = gameObject.AddComponent<AudioSource>();

        // Configurar las propiedades iniciales de los AudioSources
        pasosAudio.clip = pasosClip;
        saltoAudio.clip = saltoClip;
        correrAudio.clip = correrClip;

        // Configurar propiedades comunes
        ConfigureAudioSource(pasosAudio);
        ConfigureAudioSource(saltoAudio);
        ConfigureAudioSource(correrAudio);
    }

    void Update()
    {
        // Manejar la reproducción de sonidos según la entrada del jugador
        if ((Input.GetButton("Vertical") || Input.GetButton("Horizontal")) && !Input.GetKey(KeyCode.LeftShift))
        {
            if (!estaCaminando && !estaCorriendo)
            {
                PlayAudio(pasosAudio);
                estaCaminando = true;
            }
        }
        else
        {
            if (estaCaminando)
            {
                StopAudioWithDelay(pasosAudio, tiempoEsperaCaminar);
                estaCaminando = false;
            }
        }

        if (Input.GetButtonDown("Jump") && !saltoAudioReproducido)
        {
            PlayAudio(saltoAudio);
            saltoAudioReproducido = true;
        }

        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetButton("Vertical") || Input.GetButton("Horizontal")))
        {
            if (!estaCorriendo && !estaCaminando)
            {
                PlayAudio(correrAudio);
                estaCorriendo = true;
            }
        }
        else
        {
            if (estaCorriendo)
            {
                StopAudioWithDelay(correrAudio, tiempoEsperaCorrer);
                estaCorriendo = false;
            }
        }

        // Detener todos los sonidos cuando no hay entrada de movimiento
        if (!Input.anyKey)
        {
            StopAllAudio();
        }
    }

    private void PlayAudio(AudioSource audioSource)
    {
        if (!audioSource.isPlaying)
        {
            StopAllAudio();
            audioSource.Play();
        }
    }

    private void StopAudio(AudioSource audioSource)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    private void StopAudioWithDelay(AudioSource audioSource, float delay)
    {
        if (audioSource.isPlaying)
        {
            Invoke(nameof(StopAudio), delay);
        }
    }

    private void StopAllAudio()
    {
        StopAudio(pasosAudio);
        StopAudio(saltoAudio);
        StopAudio(correrAudio);
        saltoAudioReproducido = false; // Reiniciar el indicador de reproducción de salto
    }

    private void ConfigureAudioSource(AudioSource audioSource)
    {
        audioSource.loop = true;
        // Añadir cualquier otra configuración necesaria
    }
}
