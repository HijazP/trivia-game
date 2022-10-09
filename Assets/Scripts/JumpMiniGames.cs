using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpMiniGames : MonoBehaviour
{
    public int scene;

    void OnTriggerEnter2D(Collider2D colli)
    {
        if (colli.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(scene);
        }
    }
}
