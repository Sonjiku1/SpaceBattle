
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidad = 10f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        gameObject.tag = "bala1";

        // Movimiento hacia arriba
        rb.linearVelocity = Vector2.up * velocidad;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
