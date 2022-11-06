using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuizButton : MonoBehaviour
{
    public static QuizButton instance;

    public GameObject[] nextButton;
    public GameObject answerButton;
    public GameObject retryButton;

    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(nextButton[0]);
    }

    public void Retry()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(retryButton);
    }

    public void Answer()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(answerButton);
    }

    public void Done()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(nextButton[1]);
    }
}
