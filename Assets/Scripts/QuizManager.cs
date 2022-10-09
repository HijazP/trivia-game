using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentquestion;
    public Text QuestionTxt;
    
    public GameObject QuizPanel;
    public GameObject FinishPanel;
    public GameObject tombolnext;
    
    public Text ScoreTxt;
    int totalquestions = 0;
    public int score = 0; 

    private void Start(){
        totalquestions = QnA.Count;
        FinishPanel.SetActive(false);
        generateQuestion();
    }

    void generateQuestion(){
        if(QnA.Count > 0){
            currentquestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentquestion].Question;
            setAnswer(); 
        }
        else{
            Debug.Log("Pertanyaan Habis"); 
            gameover();
        }

    }

    void setAnswer(){
        for(int i =0; i < options.Length; i++){
            options[i].GetComponent<AnswerQuiz>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text=QnA[currentquestion].Answers[i];


            if(QnA[currentquestion].CorrectAnswer == i+1){
                options[i].GetComponent<AnswerQuiz>().isCorrect = true;
            } 
        }
    } 

    public void correct(){
        score += 10;
        QnA.RemoveAt(currentquestion);
        generateQuestion();
    }

    public void wrong(){
        QnA.RemoveAt(currentquestion);
        generateQuestion(); 
    }

    public void retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void gameover(){
        QuizPanel.SetActive(false);
        FinishPanel.SetActive(true);
        ScoreTxt.text = score + "/100";
        if (score < 70) tombolnext.SetActive(false); 
        else tombolnext.SetActive(true); 
    }



    public void keluarminigame(){
        SceneManager.LoadScene(3);
    }  
    
}
