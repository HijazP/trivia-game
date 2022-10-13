using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 5f;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D colli)
    {
        TrashMove trash = colli.GetComponent<TrashMove>();

        if (gameObject.tag == "Basket_Red" && colli.gameObject.CompareTag("Trash_Red"))
        {
            ScoreManager.instance.AddScore();
        }
        else if (gameObject.tag == "Basket_Green" && colli.gameObject.CompareTag("Trash_Green"))
        {
            ScoreManager.instance.AddScore();
        }
        else if (gameObject.tag == "Basket_Blue" && colli.gameObject.CompareTag("Trash_Blue"))
        {
            ScoreManager.instance.AddScore();
        }

        trash.DestroyTrash();
    }
}
