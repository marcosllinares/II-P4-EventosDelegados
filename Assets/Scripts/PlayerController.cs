using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;      // velocidad de movimiento

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // A/D o flechas
        float v = Input.GetAxis("Vertical");   // W/S o flechas
        Vector3 input = new Vector3(h, 0, v);

        // Movimiento básico WASD usando Transform.Translate
        Vector3 movement = input * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }
}