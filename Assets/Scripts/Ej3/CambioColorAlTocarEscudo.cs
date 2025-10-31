using UnityEngine;

public class CambioColorAlTocarEscudo : MonoBehaviour
{
    [Header("Configuración")]
    [Tooltip("Color al que cambiar cuando un Tipo1 o Tipo2 toque este escudo")]
    [SerializeField] private Color nuevoColor = Color.yellow;

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colisiona es Tipo1 o Tipo2
        if (collision.collider.CompareTag("Tipo1") || collision.collider.CompareTag("Tipo2"))
        {
            CambiarColorDelObjeto(collision.gameObject);
        }
    }

    private void CambiarColorDelObjeto(GameObject objeto)
    {
        Renderer rendererComponent = objeto.GetComponent<Renderer>();
        
        if (rendererComponent != null)
        {
            rendererComponent.material.color = nuevoColor;
            Debug.Log($"[{gameObject.name}] Ha cambiado el color de {objeto.name}");
        }
        else
        {
            Debug.LogWarning($"[{gameObject.name}] El objeto {objeto.name} no tiene un Renderer!");
        }
    }
}
