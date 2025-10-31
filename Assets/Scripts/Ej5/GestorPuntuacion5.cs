using UnityEngine;

public class GestorPuntuacion5 : MonoBehaviour
{
    public Notificador5 notificador;
    
    private int puntuacionTotal = 0;

    private void Start()
    {
        if (notificador != null)
        {
            // Suscribirse al evento de escudo recogido
            notificador.OnEscudoRecogido += SumarPuntos;
            Debug.Log("[GestorPuntuacion5] Sistema de puntuación inicializado");
        }
        else
        {
            Debug.LogError("[GestorPuntuacion5] No se ha asignado el Notificador5 en el Inspector!");
        }
    }

    private void OnDestroy()
    {
        if (notificador != null)
        {
            // Desuscribirse del evento
            notificador.OnEscudoRecogido -= SumarPuntos;
        }
    }

    private void SumarPuntos(int puntos)
    {
        puntuacionTotal += puntos;
        Debug.Log($"★★★ PUNTUACIÓN ACTUAL: {puntuacionTotal} puntos ★★★");
    }

    // Método público para consultar la puntuación (opcional)
    public int ObtenerPuntuacion()
    {
        return puntuacionTotal;
    }
}
