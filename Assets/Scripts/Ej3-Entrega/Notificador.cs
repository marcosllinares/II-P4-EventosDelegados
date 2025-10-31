using UnityEngine;

public class Notificador : MonoBehaviour
{
    // Delegados para los diferentes tipos de colisión
    public delegate void DelegadoColisionTipo1();
    public delegate void DelegadoColisionTipo2();
    
    // Eventos
    public event DelegadoColisionTipo1 OnColisionConTipo1;
    public event DelegadoColisionTipo2 OnColisionConTipo2;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("EscudoTipo1Especial"))
        {
            OnColisionConTipo2?.Invoke();
            Debug.Log("[Notificador] Colisión con Tipo1 → Tipo1 va hacia su personaje tipo");
        }
        else if (collision.collider.CompareTag("EscudoTipo2Especial"))
        {
            OnColisionConTipo1?.Invoke();
            Debug.Log("[Notificador] Colisión con Tipo2 → Tipo2 se aleja de su personaje tipo");
        }
    }
}
