using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Animator animator;
    public int maxHealth = 1;
    int currentHealth;
    public float waitTime = 0.5f;
    Vector2 movement;
    Rigidbody2D rb;
    public GameObject deathAnimation;


    //public bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = rb.velocity.x;
        movement.y = rb.velocity.y;
        movement.Normalize();
        if (movement != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);

        }
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Instantiate(deathAnimation, rb.position, Quaternion.identity);
    }
}
