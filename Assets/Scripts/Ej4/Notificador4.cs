using UnityEngine;

public class Notificador4 : MonoBehaviour
{
    // Delegados para los diferentes tipos de colisión
    public delegate void DelegadoColisionEscudoTipo1();
    public delegate void DelegadoColisionEscudoTipo2();
    
    // Eventos
    public event DelegadoColisionEscudoTipo1 OnColisionConEscudoTipo1;
    public event DelegadoColisionEscudoTipo2 OnColisionConEscudoTipo2;
    
    private void OnCollisionEnter(Collision collision)
    {
        // Si colisiona con un escudo Tipo1
        if (collision.collider.CompareTag("EscudoTipo1"))
        {
            OnColisionConEscudoTipo1?.Invoke();
            Debug.Log("[Notificador4] Colisión con EscudoTipo1 → Tipo1 se teletransportan");
        }
        // Si colisiona con un escudo Tipo2
        else if (collision.collider.CompareTag("EscudoTipo2"))
        {
            OnColisionConEscudoTipo2?.Invoke();
            Debug.Log("[Notificador4] Colisión con EscudoTipo2 → Tipo2 se orientan hacia él");
        }
    }
}