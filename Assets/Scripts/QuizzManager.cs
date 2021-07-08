using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class QuizzManager : MonoBehaviour
{
    [HideInInspector]
    public Quizz quizz;

    public TextAsset data;
    public Transform modelPlaceholder;
    public TMP_Text questionText;
    public TMP_Text answerText;
    public GameObject button; 

    private Answer[] userAnswers;
    private int questionIndex = 0;
    private Question currentQuestion;
    private Question[] questions;
    private Vector3 initPosition;
    private GameObject instantiatedGO;

    public AudioSource audioLePerse;

    public float score;
    [Header("Texts")]
    public string text_end_win = "Bravo, vous avez réussi le QCM!";
    public string text_end_lose = "Dommage, vous avez raté le QCM!";
    public string text_end_score = "Vous avez un score de ";
    public string text_question_win = "Bonne réponse!";
    public string text_question_lose = "Mauvaise réponse...";

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

        
        InstantiateModel(currentQuestion.model);
        InstantiateButtons();
        questionIndex++;
    }

    void SetEnding()
    {
        //destroy buttons
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
        
        if(score >= questions.Length/2)
        {
            questionText.text = text_end_win;
        }
        else
        {
            questionText.text = text_end_lose;

        }

        answerText.text  = text_end_score + score + "/" + questions.Length;
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
        questionText.text = "";
        if(AreAnswersValid() == true)
        {
            answerText.text = text_question_win;
            score++;
            audioLePerse.Play();
        }
        else
        {
            answerText.text = text_question_lose;
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

    void InstantiateModel(string modelName)
    {
        //destroy existing model
        if(instantiatedGO)
            Destroy(instantiatedGO);
        
        if(modelName != "")
        {
            instantiatedGO = Instantiate(Resources.Load("Models/"+modelName, typeof(GameObject)), modelPlaceholder.position + new Vector3(0, 1f, 0), Quaternion.identity) as GameObject;
            instantiatedGO.transform.parent = modelPlaceholder;
        }
    }

    void InstantiateButtons()
    {
        //destroy buttons
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
        

        transform.position = initPosition;
        Vector3 offset = new Vector3(0,0,0);
        int i = 1;
        Transform canvas = GameObject.Find("Canvas").transform;
        //instantiate buttons for each answer
        foreach(var ans in userAnswers)
        {
            GameObject btn = Instantiate(button, transform.position + offset, Quaternion.identity *  transform.rotation);
            btn.GetComponentInChildren<QuizzBuzz>().answerLabel = ans.answer;
            btn.GetComponentInChildren<QuizzBuzz>().number = i;

            btn.transform.parent = transform;
            transform.position = transform.position + (-offset)/i;

            //get correct rotation of button
            Vector3 rot = btn.transform.rotation.eulerAngles;
            rot = new Vector3(rot.x+180,rot.y,rot.z);
            btn.transform.rotation = Quaternion.Euler(rot);
            
            i++;
            offset += new Vector3(0.25f,0,0);
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

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
