using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    Vector2 movement;
    public Animator animator;
    public GameObject SpawnPoint;

    // Update is called once per frame
    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        if (movement != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);

        }
        animator.SetFloat("Speed", movement.sqrMagnitude);
        if (Input.GetButtonDown("SpawnUnit"))
        {
            SpawnPoint.GetComponent<MoleSpawn>().doSpawn = true;
        }
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
