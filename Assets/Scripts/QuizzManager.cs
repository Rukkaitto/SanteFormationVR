using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class QuizzManager : MonoBehaviour
{
    [HideInInspector]
    public Quizz quizz;

    public TextAsset data;
    int questionIndex = 0;
    Question currentQuestion;
    Question[] questions;

    public TMP_Text questionText;
    public TMP_Text answerText;
    public GameObject canvas;
    public Answer[] userAnswers;
    public GameObject button; 
    public float score;

    private Vector3 initPosition;

    private void Awake() {
        quizz = JsonUtility.FromJson<Quizz>(data.ToString());
    }

    void Start()
    {
        initPosition = transform.position;
        questions = quizz.getAllQuestions();
        NextQuestion();
    }

    void NextQuestion()
    {

        //destroy buttons
        if(transform.childCount > 0)
        {
            foreach (Transform child in transform) {
                GameObject.Destroy(child.gameObject);
            }
        }

        //get new question and set local variables
        if(questionIndex < questions.Length)
        {
            SetQuestion();
        }
        else
        {
            SetEnding();
        }
    }

    void SetQuestion(){
        currentQuestion = questions[questionIndex];

        //create user answers array
        userAnswers = new Answer[currentQuestion.answers.Length];
        int j = 0;
        foreach(Answer ans in currentQuestion.answers)
        {
            Answer newAns = new Answer(ans.answer, false);
            userAnswers[j] = newAns;
            j++;
        }

        //set text
        questionText.text = currentQuestion.question;

        int i = 1;
        answerText.text = "";
        foreach(var ans in userAnswers)
        {
            ans.value = false;
            answerText.text += i.ToString() + " - " + ans.answer + "\n";
            i++;
        }

        InstantiateButtons();
        questionIndex++;
    }

    void SetEnding()
    {
        if(score >= questions.Length/2)
        {
            questionText.text = "Bravo, vous avez réussi le QCM!";
        }
        else
        {
            questionText.text = "Dommage, vous avez raté le QCM!";

        }

        answerText.text  = "Vous avez un score de " + score + "/" + questions.Length;
    }

    public void SetAnswer(string answerLabel, bool answer)
    {
        foreach(var ans in userAnswers)
            if(ans.answer == answerLabel) 
                ans.value = answer; 
    }

    //tells if user has correct answer or not
    public void Validate()
    {
        string tt = "User: ";
        foreach(var ans in userAnswers)
        {
            tt += ans.value+" ";
        }

        tt += "\nGood: ";

        foreach(var ans in currentQuestion.answers)
        {
            tt += ans.value+" ";
        }
        Debug.Log(tt);


        questionText.text = "";
        if(AreAnswersValid() == true)
        {
            answerText.text = "Bravo!";
            score++;
        }
        else
        {
            answerText.text = "T'es nul!";
        }

        StartCoroutine(Countdown(3));
    }

    
    bool AreAnswersValid()
    {
        foreach(Answer a in currentQuestion.answers)
            foreach(Answer ua in userAnswers)
                if(a.answer == ua.answer)
                    if(a.value != ua.value)
                        return false;

        
        return true;
    }

    void InstantiateButtons()
    {
        
        transform.position = initPosition;
        float offset = 0;
        int i = 1;

        //instantiate buttons for each answer
        foreach(var ans in userAnswers)
        {
            GameObject btn = Instantiate(button, transform.position + new Vector3(offset, 0, 0), Quaternion.identity *  Quaternion.Euler (80f, 0f, 0f));
            btn.GetComponentInChildren<QuizzBuzz>().answerLabel = ans.answer;
            btn.GetComponentInChildren<QuizzBuzz>().number = i;
            btn.transform.parent = transform;
            transform.position = transform.position + new Vector3((offset*-1)/i, 0, 0);
            Vector3 rot = btn.transform.rotation.eulerAngles;
            rot = new Vector3(rot.x+180,rot.y,rot.z);
            btn.transform.rotation = Quaternion.Euler(rot);
            
            i++;
            offset += 0.25f;
        }
    }



    //countdown to next question
    private IEnumerator Countdown(float duration)
    {
        float normalizedTime = 0;
        while(normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
        NextQuestion();
    }
}
