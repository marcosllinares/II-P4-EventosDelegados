using UnityEngine;

public class SphereAgent : MonoBehaviour
{
    [Header("Referencias")]
    [Tooltip("Solo para Tipo1: esfera VERDE objetivo predefinida")]
    public Transform objetivoTipo1;   // la verde seleccionada
    [Tooltip("Solo para Tipo2: referencia al cilindro")]
    public Transform cilindro;        // el cilindro de la escena

    [Header("Movimiento")]
    [SerializeField] private float velocidad = 3f;

    private bool mover;

    private void OnEnable()
    {
        GameEvents.CubeHitCylinder += OnOrdenMover;
    }

    private void OnDisable()
    {
        GameEvents.CubeHitCylinder -= OnOrdenMover;
    }

    private void OnOrdenMover()
    {
        mover = true;
    }

    private void Update()
    {
        if (!mover) return;

        Transform destino = null;

        // Determinar destino usando el tag del GameObject
        if (gameObject.CompareTag("Tipo1"))
            destino = objetivoTipo1;
        else if (gameObject.CompareTag("Tipo2"))
            destino = cilindro;
        else
        {
            // Si no tiene tag conocido, mostrar mensaje de error
            Debug.Log($"El objeto {gameObject.name} no tiene un tag válido (Tipo1/Tipo2) asignado");
        }

        if (destino != null)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                destino.position,
                velocidad * Time.deltaTime
            );
        }
    }
}