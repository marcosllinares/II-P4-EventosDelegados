using UnityEngine;

public class GestorPuntuacion3 : MonoBehaviour
{
    public Notificador53 notificador;
    
    private int puntuacionTotal = 0;

    private void Start()
    {
        if (notificador != null)
        {
            notificador.OnEscudoRecogido += SumarPuntos;
            Debug.Log("[GestorPuntuacion5] Sistema de puntuación inicializado");
        }
        else
        {
            Debug.LogError("[GestorPuntuacion5] No se ha asignado el Notificador en el Inspector!");
        }
    }

    private void OnDestroy()
    {
        if (notificador != null)
        {
            notificador.OnEscudoRecogido -= SumarPuntos;
        }
    }

    private void SumarPuntos(int puntos)
    {
        puntuacionTotal += puntos;
        Debug.Log($"PUNTUACIÓN ACTUAL: {puntuacionTotal} puntos");
        if (puntuacionTotal > 100)
        {
            Debug.Log("¡Has superado los 100 puntos!");
        }
    }

    // Método público para consultar la puntuación (opcional)
    public int ObtenerPuntuacion()
    {
        return puntuacionTotal;
    }
}
