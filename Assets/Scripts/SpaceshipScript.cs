
using UnityEngine;
using System.Collections;
public class Spaceship : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody2D rb;
    private float movimientoX;

    [SerializeField]
    private float cooldownSeconds;
    bool CanShoot = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Posición inicial del jugador
        transform.position = new Vector3(0f, -7f, 0f);


        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(gameObject, transform.position, Quaternion.identity);


        }

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

        if (Input.GetKey("space") && CanShoot)
        {
            Debug.Log("SIUUU");
            CanShoot = false;
            StartCoroutine(EnableShoot());
        }
    }

    void FixedUpdate()
    {
        // Mover el Rigidbody2D horizontalmente
        rb.linearVelocity = new Vector2(
            movimientoX * speed,
            0f
        );
    }


    IEnumerator EnableShoot()
    {
        yield return new WaitForSeconds(cooldownSeconds);
        Debug.Log("YA DISPARA");
        CanShoot = true;
    }


 
}


