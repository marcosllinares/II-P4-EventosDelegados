using UnityEngine;

public class Notificador5 : MonoBehaviour
{
    // Delegados para diferentes tipos de escudos recogidos
    public delegate void DelegadoEscudoRecogido(int puntos);
    
    // Evento que se dispara cuando se recoge un escudo
    public event DelegadoEscudoRecogido OnEscudoRecogido;
    
    // Método para notificar que se recogió un escudo
    public void NotificarEscudoRecogido(int puntos, string tipoEscudo)
    {
        OnEscudoRecogido?.Invoke(puntos);
        Debug.Log($"[Notificador5] Escudo {tipoEscudo} recogido → +{puntos} puntos");
    }
}
