using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashRandom : MonoBehaviour
{
    public GameObject[] trashes;
    private float startTime = 3f;
    private float randPost;
    private int randTrash;
    private float cdTime;
    private int timeInt;
    public Transform post;

    void Start()
    {
        cdTime = startTime;
    }

    void Update()
    {
        if (cdTime <= 0)
        {
            randPost = Random.Range(-8f, 8f);
            randTrash = Random.Range(0, trashes.Length);
            post.position = new Vector3(randPost, transform.position.y, transform.position.z);
            Instantiate(trashes[randTrash], post.position, post.rotation);
            cdTime = Random.Range(0f, 2f);
        }
        else
        {
            cdTime -= Time.deltaTime;
        }
    }
}
