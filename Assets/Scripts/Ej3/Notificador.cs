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
        // Si colisiona con un humanoide Tipo1
        if (collision.collider.CompareTag("Tipo1"))
        {
            OnColisionConTipo2?.Invoke();
            Debug.Log("[Notificador] Colisión con Tipo1 → Tipo1 va hacia escudos Tipo2");
        }
        // Si colisiona con un humanoide Tipo2
        else if (collision.collider.CompareTag("Tipo2"))
        {
            OnColisionConTipo1?.Invoke();
            Debug.Log("[Notificador] Colisión con Tipo2 → Tipo1 va hacia escudo seleccionado Tipo1");
        }
    }
}