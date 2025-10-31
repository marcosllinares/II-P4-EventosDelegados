using UnityEngine;

public class Escudo5 : MonoBehaviour
{
    [Header("Configuración del Escudo")]
    [Tooltip("Puntos que otorga este escudo (Tipo1=5, Tipo2=10)")]
    [SerializeField] private int puntosAlRecoger = 5;
    
    [Tooltip("Tipo de escudo para el log")]
    [SerializeField] private string tipoEscudo = "Tipo1";
    
    private Notificador5 notificador;
    private bool yaRecogido = false;

    private void Start()
    {
        // Buscar el notificador en la escena
        notificador = FindFirstObjectByType<Notificador5>();
        
        if (notificador == null)
        {
            Debug.LogError($"[{gameObject.name}] No se encontró Notificador5 en la escena!");
        }
        
        // Configurar puntos según el tag
        if (gameObject.CompareTag("EscudoTipo1"))
        {
            puntosAlRecoger = 5;
            tipoEscudo = "Tipo1";
        }
        else if (gameObject.CompareTag("EscudoTipo2"))
        {
            puntosAlRecoger = 10;
            tipoEscudo = "Tipo2";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si el jugador (tag "Player") recoge el escudo
        if (!yaRecogido && other.CompareTag("Player"))
        {
            RecogerEscudo();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // También soportar colisiones normales (sin trigger)
        if (!yaRecogido && collision.collider.CompareTag("Player"))
        {
            RecogerEscudo();
        }
    }

    private void RecogerEscudo()
    {
        yaRecogido = true;
        
        if (notificador != null)
        {
            // Notificar al sistema que se recogió el escudo
            notificador.NotificarEscudoRecogido(puntosAlRecoger, tipoEscudo);
        }
        
        // Destruir el escudo después de ser recogido
        Debug.Log($"[{gameObject.name}] Escudo {tipoEscudo} destruido");
        Destroy(gameObject);
    }
}
