using UnityEngine;

public class Respuesta : MonoBehaviour
{
    public Notificador notificador;

    [Header("Objetivos para Tipo1")]
    [Tooltip("Escudo Tipo2 seleccionado")]
    public Transform escudoTipo2Seleccionado;
    
    [Header("Objetivos para Tipo2")]
    [Tooltip("Escudo Tipo1 seleccionado")]
    public Transform escudoTipo1Seleccionado;

    [Header("Movimiento")]
    [SerializeField] private float velocidad = 3f;

    private bool mover;
    private Transform destinoActual;

    private void OnOrdenMoverAEscudoTipo1()
    {
        if (gameObject.CompareTag("Tipo2"))
        {
            mover = true;
            destinoActual = escudoTipo1Seleccionado;
        }
    }

    private void OnOrdenMoverAEscudoTipo2()
    {
        if (gameObject.CompareTag("Tipo1"))
        {
            mover = true;
            destinoActual = escudoTipo2Seleccionado;
        }
    }

    private void Start()
    {
        if (notificador != null)
        {
            // Suscribirse a ambos eventos
            notificador.OnColisionConTipo1 += OnOrdenMoverAEscudoTipo2;
            notificador.OnColisionConTipo2 += OnOrdenMoverAEscudoTipo1;
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

        transform.position = Vector3.MoveTowards(
            transform.position,
            destinoActual.position,
            velocidad * Time.deltaTime
        );
    }
}