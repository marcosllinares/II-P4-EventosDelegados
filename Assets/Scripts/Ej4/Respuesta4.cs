using UnityEngine;

public class Respuesta4 : MonoBehaviour
{
    public Notificador4 notificador;

    [Header("Objetivo para Tipo1")]
    [Tooltip("Escudo Tipo1 donde se teletransportarán los Tipo1")]
    public Transform escudoTipo1Objetivo;
    
    [Header("Objetivo para Tipo2")]
    [Tooltip("Escudo Tipo2 hacia donde se orientarán los Tipo2")]
    public Transform escudoTipo2Objetivo;

    private void OnTeletransportarTipo1()
    {
        // Solo los Tipo1 responden a este evento
        if (gameObject.CompareTag("Tipo1"))
        {
            if (escudoTipo1Objetivo != null)
            {
                // Teletransportar (cambiar posición instantáneamente)
                transform.position = escudoTipo1Objetivo.position;
                Debug.Log($"[{gameObject.name}] Tipo1 se ha teletransportado al escudo Tipo1");
            }
            else
            {
                Debug.LogWarning($"[{gameObject.name}] No se ha asignado el escudo Tipo1 objetivo");
            }
        }
    }

    private void OnOrientarTipo2()
    {
        // Solo los Tipo2 responden a este evento
        if (gameObject.CompareTag("Tipo2"))
        {
            if (escudoTipo2Objetivo != null)
            {
                // Orientarse hacia el escudo (solo rotación, sin moverse)
                Vector3 direccion = escudoTipo2Objetivo.position - transform.position;
                direccion.y = 0; // Mantener la rotación solo en el plano horizontal
                
                if (direccion != Vector3.zero)
                {
                    transform.rotation = Quaternion.LookRotation(direccion);
                    Debug.Log($"[{gameObject.name}] Tipo2 se ha orientado hacia el escudo Tipo2");
                }
            }
            else
            {
                Debug.LogWarning($"[{gameObject.name}] No se ha asignado el escudo Tipo2 objetivo");
            }
        }
    }

    private void Start()
    {
        if (notificador != null)
        {
            // Suscribirse a ambos eventos
            notificador.OnColisionConEscudoTipo1 += OnTeletransportarTipo1;
            notificador.OnColisionConEscudoTipo2 += OnOrientarTipo2;
        }
        else
        {
            Debug.LogError($"[{gameObject.name}] No se ha asignado el Notificador4 en el Inspector!");
        }
    }

    private void OnDestroy()
    {
        if (notificador != null)
        {
            // Desuscribirse de ambos eventos
            notificador.OnColisionConEscudoTipo1 -= OnTeletransportarTipo1;
            notificador.OnColisionConEscudoTipo2 -= OnOrientarTipo2;
        }
    }
}