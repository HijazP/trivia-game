using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpScene : MonoBehaviour
{
    public Animator anim;

    public void Jump(int scene)
    {
        Time.timeScale = 1f;
        StartCoroutine(JumpDelay(scene));
    }

    IEnumerator JumpDelay(int scene)
    {
        Time.timeScale = 1f;
        anim.SetBool("fade", true);
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(scene);
        anim.SetBool("fade", false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
