using System.Collections; // Necesario para usar Corrutinas (IEnumerator)
using UnityEngine;

public class PowerUpReaparecible : MonoBehaviour
{
    [Header("Configuración")]
    public float incrementoVelocidad = 500f;
    public float tiempoReaparicion = 2f; // Tiempo en segundos para volver a aparecer

    // Referencias a los componentes de la propia píldora
    private MeshRenderer malla;
    private Collider colisionador;

    void Start()
    {
        // Guardamos las referencias del modelo visual y la colisión
        malla = GetComponent<MeshRenderer>();
        colisionador = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent<Jugador>(out var jugador))
            {
                // 1. Le damos la velocidad al jugador
                jugador.aumentoVelocidad(incrementoVelocidad);

                // 2. Iniciamos el contador para ocultar y reaparecer la píldora
                StartCoroutine(RutinaReaparicion());
            }
        }
    }

    // Corrutina que gestiona el tiempo de espera
    private IEnumerator RutinaReaparicion()
    {
        // Ocultamos la píldora y desactivamos su colisión
        OcultarPildora(false);

        // Esperamos X segundos (no congela el juego)
        yield return new WaitForSeconds(tiempoReaparicion);

        // Volvemos a mostrarla y activar la colisión
        OcultarPildora(true);
    }

    private void OcultarPildora(bool estado)
    {
        malla.enabled = estado;       // Hace invisible/visible la cápsula
        colisionador.enabled = estado; // Desactiva/activa que se pueda tocar
    }
}