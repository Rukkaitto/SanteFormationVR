using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Answer{
    public string answer;
    public bool value;

    public Answer(string m_answer, bool m_value){
        answer = m_answer;
        value = m_value;
    }
}

[System.Serializable]
public class Question{

    public string question;
    public Answer[] answers;

    public Question(string m_question, Answer[] m_answers){
        question = m_question;
        answers = m_answers;
    }

    public bool isCorrect()
    {
  
}


public class Quizz : MonoBehaviour {

    [SerializeField]
    private Question[] quizz;

    private void Start() {
        
    }

    private void Update() {
        
    }
    
}