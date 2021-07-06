using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizzManager : MonoBehaviour
{
    TextAsset json;
    //int questionIndex = 0;
    Question currentQuestion;
    //List<Question> questions = new List<Question>();
=======
>>>>>>> b6c1d3527da6984a56ac4680287245875a5de87f

[System.Serializable]
public class Answer{
    public string answer;
    public bool value;

<<<<<<< HEAD
    void Start()
    {
        /*Question q1 = new Question();
        q1.label = "Une question de test";
        Dictionary<string, bool> an1 = new Dictionary<string, bool>();
        an1.Add("Aaa", true);
        an1.Add("Bbbb", false);
        an1.Add("Cccc", true);
        an1.Add("Dddd", false);
        q1.answers = an1;
=======
    public Answer(string m_answer, bool m_value){
        answer = m_answer;
        value = m_value;
    }
}
>>>>>>> b6c1d3527da6984a56ac4680287245875a5de87f

[System.Serializable]
public class Question{

    public string question;
    public Answer[] answers;

<<<<<<< HEAD
        questions.Add(q1);    
        questions.Add(q2);    
        NextQuestion();*/
=======
    public Question(string m_question, Answer[] m_answers){
        question = m_question;
        answers = m_answers;
>>>>>>> b6c1d3527da6984a56ac4680287245875a5de87f
    }
}

[System.Serializable]
public class Quizz {

<<<<<<< HEAD
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
=======
    public Question[] questions;

    public Quizz(Question[] m_question){
        questions = m_question;
    }

}


public class QuizzManager : MonoBehaviour {
>>>>>>> b6c1d3527da6984a56ac4680287245875a5de87f

    [SerializeField]
    public Quizz quizz;
    private string json;

<<<<<<< HEAD
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
=======
    private void Start() {
        quizz = JsonUtility.FromJson<Quizz>(json);
    }
    
>>>>>>> b6c1d3527da6984a56ac4680287245875a5de87f
}
