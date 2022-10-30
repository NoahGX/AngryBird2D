using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AngryBird bird = collision.collider.GetComponent<Enemy>();
        if (bird ! = null)
        {
            Destroy(gameObject);
            return;
        }

        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            return;
        }

        if (collision.contacts[0].normal.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
