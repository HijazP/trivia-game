using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashRandom : MonoBehaviour
{
    public static TrashRandom instance;

    public GameObject[] trashes;
    private float startTime = 3f;
    private float randPost;
    private int randTrash;
    private float cdTime;
    private int timeInt;
    public Transform post;
    private bool isPlay = true;
    private bool playGame = false;
    private bool gameOver = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        cdTime = startTime;
    }

    void Update()
    {
        if (!playGame)
        {
            return;
        }

        if (!gameOver)
        {
            if (isPlay)
            {
                if (cdTime <= 0)
                {
                    randPost = Random.Range(-3f, 3f);
                    randTrash = Random.Range(0, trashes.Length);
                    post.position = new Vector3(randPost, transform.position.y, transform.position.z);
                    Instantiate(trashes[randTrash], post.position, post.rotation);
                    cdTime = Random.Range(1f, 2f);
                }
                else
                {
                    cdTime -= Time.deltaTime;
                }
            }
        }
    }

    public void ChangeStatus()
    {
        isPlay = !isPlay;
    }

    public void PlayGame()
    {
        playGame = true;
    }

    public void GameOver()
    {
        gameOver = true;
    }
}
