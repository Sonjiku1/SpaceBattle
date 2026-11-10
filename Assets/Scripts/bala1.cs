using UnityEngine;

public class Bala : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float speed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }

        rb.gravityScale = 0f;
        rb.freezeRotation = true;

        // Disparar hacia arriba
        rb.linearVelocity = Vector2.up * speed;
    }

    void Update()
    {
        // Destruir únicamente cuando salga de la pantalla
        if (transform.position.y > 15f)
        {
            Destroy(gameObject);
        }
    }
}