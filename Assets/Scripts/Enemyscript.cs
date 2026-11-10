
using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int vida = 3;

    private SpriteRenderer spriteRenderer;
    private Color colorOriginal;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        colorOriginal = spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprobar si recibe un impacto de bala
        if (collision.CompareTag("Bullet"))
        {
            vida--;

            Debug.Log("La nave enemiga ha recibido un impacto. Vida: " + vida);


            // Destruir la bala
            Destroy(collision.gameObject);

            // Cambiar el color de la nave
            StartCoroutine(CambiarColor());

            // Destruir enemigo si se queda sin vida
            if (vida <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private string FlashColor()
    {
        throw new NotImplementedException();
    }

    IEnumerator CambiarColor()
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.2f);

        if (spriteRenderer != null)
        {
            spriteRenderer.color = colorOriginal;
        }
    }
}
