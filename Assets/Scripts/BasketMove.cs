using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMove : MonoBehaviour
{
    public static BasketMove instance;

    private Rigidbody2D rb;
    private float speed = 5f;
    private Vector2 movement;
    private bool isPlay = true;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isPlay)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
        }
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

    public void ChangeStatus()
    {
        isPlay = !isPlay;
    }
}
