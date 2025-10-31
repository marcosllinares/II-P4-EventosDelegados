using UnityEngine;

public class Respuesta : MonoBehaviour
{
    public Notificador notificador;

    [Header("Objetivos para EscudoTipo1")]
    public Transform targetTipo2;
    
    [Header("Objetivos para EscudoTipo2")]
    public Transform targetTipo1;

    [Header("Movimiento")]
    [SerializeField] private float velocidad = 3f;

    private bool mover;
    private Transform destinoActual;

    private void OnOrdenMoverAEscudoTipo1()
    {
        if (gameObject.CompareTag("EscudoTipo1"))
        {
            mover = true;
            destinoActual = targetTipo1;
        }
    }

    private void OnOrdenMoverAEscudoTipo2()
    {
        if (gameObject.CompareTag("EscudoTipo2"))
        {
            mover = true;
            destinoActual = targetTipo2;
        }
    }

    private void Start()
    {
        if (notificador != null)
        {
            // Suscribirse a ambos eventos
            notificador.OnColisionConTipo1 += OnOrdenMoverAEscudoTipo1;
            notificador.OnColisionConTipo2 += OnOrdenMoverAEscudoTipo2;
        }
        else
        {
            Debug.LogError($"[{gameObject.name}] No se ha asignado el Notificador en el Inspector!");
        }
    }

    private void OnDestroy()
    {
        if (notificador != null)
        {
            // Desuscribirse de ambos eventos
            notificador.OnColisionConTipo1 -= OnOrdenMoverAEscudoTipo2;
            notificador.OnColisionConTipo2 -= OnOrdenMoverAEscudoTipo1;
        }
    }

    private void Update()
    {
        if (!mover || destinoActual == null) return;

        // Si es escudo Tipo1 moverse hacia el destino asignado
        // Si es escudo Tipo2 moverse alejando del destino asignado
        if (gameObject.CompareTag("EscudoTipo1"))
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                destinoActual.position,
                velocidad * Time.deltaTime
            );
        }
        else if (gameObject.CompareTag("EscudoTipo2"))
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                destinoActual.position,
                -velocidad * Time.deltaTime
            );
        }
    }
}