using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerQuiz : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizman;
    public void Answer(){
        if(isCorrect){
            Debug.Log("Betul");
            quizman.correct();
        }
        else{
            Debug.Log("Salah");
            quizman.wrong();
        }
    }
}
