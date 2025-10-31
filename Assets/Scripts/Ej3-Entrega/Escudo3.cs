using UnityEngine;

public class Escudo3 : MonoBehaviour
{
    [Header("Configuración del Escudo")]
    [SerializeField] private int puntosAlRecoger = 5;
    
    [Tooltip("Tipo de escudo para el log")]
    [SerializeField] private string tipoEscudo = "Tipo1";

    private Notificador53 notificador;
    
    private GestorPuntuacion3 gestorPuntuacion;
    private bool yaRecogido = false;

    private bool yaDoblado = false;

    private void Start()
    {
        // Buscar el notificador en la escena
        notificador = FindFirstObjectByType<Notificador53>();
        gestorPuntuacion = FindFirstObjectByType<GestorPuntuacion3>();

        if (notificador == null)
        {
            Debug.LogError($"[{gameObject.name}] No se encontró Notificador53 en la escena!");
        }

        if (gestorPuntuacion == null)
        {
            Debug.LogError($"[{gameObject.name}] No se encontró GestorPuntuacion3 en la escena!");
        }

        // Configurar puntos según el tag
        if (gameObject.CompareTag("EscudoTipo1"))
        {
            puntosAlRecoger = 10;
            tipoEscudo = "Tipo1";
        }
        else if (gameObject.CompareTag("EscudoTipo2"))
        {
            puntosAlRecoger = 20;
            tipoEscudo = "Tipo2";
        }
    }

    private void Update()
    {
        int puntuacion = gestorPuntuacion.ObtenerPuntuacion();
        if (puntuacion >= 100 && !yaDoblado)
        {
            if (gameObject.CompareTag("EscudoTipo1"))
            {
                // duplica los puntos del escudo tipo 1
                puntosAlRecoger = 20;
            }
            else if (gameObject.CompareTag("EscudoTipo2"))
            {
                // aumenta el tamaño del escudo a 1.5
                gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }
            yaDoblado = true;
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
        
        // Debug.Log($"[{gameObject.name}] Escudo {tipoEscudo} destruido");

        // No lo destruye si estipo EscudoTipo2Especial o EscudoTipo1Especial
        if (!gameObject.CompareTag("EscudoTipo2Especial") && !gameObject.CompareTag("EscudoTipo1Especial"))
        {
            yaRecogido = true;

            if (notificador != null)
            {
                notificador.NotificarEscudoRecogido(puntosAlRecoger, tipoEscudo);
            }
            Destroy(gameObject);
        }
    }
}
