using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizzManager : MonoBehaviour
{
    TextAsset json;
    //int questionIndex = 0;
    Question currentQuestion;
    List<Question> questions = new List<Question>();

    public TMP_Text questionText;
    public GameObject canvas;
    Dictionary<string, bool> userAnswer;
    public GameObject button; 

    void Start()
    {
        Answer ans1 = new Answer("Une rep", true);
        Answer ans2 = new Answer("Un truc", false);
        Answer ans2 = new Answer("Une autre réponse", false);
        Question q1 = new Question("Une question de test", );
        q1.label = "Une question de test";


        q2.answers = an2;

        questions.Add(q1);    
        questions.Add(q2);    
        NextQuestion();
    }

    void NextQuestion()
    {
        

        /*currentQuestion = questions[questionIndex];
        userAnswer = currentQuestion.answers;
        List<string> keys = new List<string>(userAnswer.Keys);
        foreach(string key in keys)
        {
            userAnswer[key] = false;
        }
  
        questionText.text = currentQuestion.label;
        InstantiateButtons();
        questionIndex++;*/
    }

    public void SetAnswer(string answerLabel, bool answer)
    {
        // foreach(var ans in userAnswer)
        //     if(ans.Key == answerLabel) 
        //         userAnswer[ans.Key] = answer; 
    }

    public void Validate()
    {
        // if(currentQuestion.isCorrect(userAnswer) == true)
        // {
        //     questionText.text = "Bravo!";
        // }
        // else
        // {
        //     questionText.text = "T'es nul!!";
        // }

        // StartCoroutine(Countdown(3));
    }

    void InstantiateButtons()
    {
        //  foreach (Transform child in transform) {
        //     GameObject.Destroy(child.gameObject);
        // }
        // //int canvasLength = canvas.x;
        // float testx = 0;
        // foreach(var ans in userAnswer)
        // {
        //     GameObject btn = Instantiate(button, transform.position + new Vector3(testx, 0, 0), Quaternion.identity);
        //     btn.GetComponentInChildren<QuizzBuzz>().answerLabel = ans.Key;
        //     btn.transform.parent = transform;

        //     testx += 0.2f;
        // }
    }


    // private IEnumerator Countdown(float duration)
    // {
    //     float normalizedTime = 0;
    //     while(normalizedTime <= 1f)
    //     {
    //         normalizedTime += Time.deltaTime / duration;
    //         yield return null;
    //     }
    //     NextQuestion();
    // }
}
