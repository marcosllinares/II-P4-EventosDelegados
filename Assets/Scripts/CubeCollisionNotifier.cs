using UnityEngine;

public class CubeCollisionNotifier : MonoBehaviour
{
    [SerializeField] private string cilindroTag = "Cilindro";
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(cilindroTag))
        {
            GameEvents.RaiseCubeHitCylinder();
            Debug.Log("[CubeCollisionNotifier] Colisión con Cilindro → evento lanzado");
        }
    }
}