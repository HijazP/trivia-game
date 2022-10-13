using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 3f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.velocity = -transform.up * speed;
    }

    public void DestroyTrash()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D colli)
    {
        if (colli.gameObject.CompareTag("Batas"))
        {
            DestroyTrash();
        }
    }
}
