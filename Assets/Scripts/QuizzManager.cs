using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizzManager : MonoBehaviour
{
    public Quizz quizz;
    public TextAsset data;
    int questionIndex = 0;
    Question currentQuestion;
    Question[] questions;

    public TMP_Text questionText;
    public GameObject canvas;
    Answer[] userAnswer;
    public GameObject button; 

    void Start()
    {
        LoadJSON();
        NextQuestion();
    }

    private void LoadJSON(){
        string json = data.ToString();
        quizz = JsonUtility.FromJson<Quizz>(json);

    }

    void NextQuestion()
    {
        currentQuestion = questions[questionIndex];
        Debug.LogError(currentQuestion.question);
        userAnswer = currentQuestion.answers;
        foreach(var ans in userAnswer)
        {
            Debug.Log(ans.answer);
        }

        questionText.text = currentQuestion.question;
        InstantiateButtons();
        questionIndex++;
    }

    public void SetAnswer(string answerLabel, bool answer)
    {
        foreach(var ans in userAnswer)
            if(ans.answer == answerLabel) 
                ans.value = answer; 
    }

    public void Validate()
    {
        questionText.text = "Bravo!";
        StartCoroutine(Countdown(3));
    }

    void InstantiateButtons()
    {
        float offset = 0;

        if(transform.childCount > 0)
        {
            foreach (Transform child in transform) {
                GameObject.Destroy(child.gameObject);
            }
        }

        foreach(var ans in userAnswer)
        {
            GameObject btn = Instantiate(button, transform.position + new Vector3(offset, 0, 0), Quaternion.identity);
            btn.GetComponentInChildren<QuizzBuzz>().answerLabel = ans.answer;
            btn.transform.parent = transform;
            offset += 0.2f;
        }
    }


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
