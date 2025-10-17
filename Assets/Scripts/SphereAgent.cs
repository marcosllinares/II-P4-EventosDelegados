using UnityEngine;

public enum Grupo { Tipo1, Tipo2 }

public class SphereAgent : MonoBehaviour
{
    [Header("Configuración de grupo")]
    public Grupo grupo = Grupo.Tipo1;

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

        if (grupo == Grupo.Tipo1)
            destino = objetivoTipo1;
        else // Grupo.Tipo2
            destino = cilindro;

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