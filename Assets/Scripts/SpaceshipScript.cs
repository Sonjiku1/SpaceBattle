

using UnityEngine;
using System.Collections;

public class Spaceship : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody2D rb;
    private float movimientoX;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float cooldownSeconds = 0.3f;

    bool CanShoot = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Posición inicial del jugador
        transform.position = new Vector3(0f, -7f, 0f);
    }

    void Update()
    {
        // Detectar movimiento horizontal
        movimientoX = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            movimientoX = 1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movimientoX = -1f;
        }

        // Disparar mientras se presiona espacio
        if (Input.GetKey(KeyCode.Space) && CanShoot)
        {
            CanShoot = false;

            // Crear la bala
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            StartCoroutine(EnableShoot());
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(
            movimientoX * speed,
            0f
        );
    }

    IEnumerator EnableShoot()
    {
        yield return new WaitForSeconds(cooldownSeconds);

        CanShoot = true;
    }
}

