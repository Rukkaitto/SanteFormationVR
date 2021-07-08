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

    public string getName(){
        return answer;
    }

    public bool getValue(){
        return value;
    }

}

[System.Serializable]
public class Question{

    public string question;
    public Answer[] answers;
    public string model;


    public Question(string m_question, Answer[] m_answers){
        question = m_question;
        answers = m_answers;
    }

    public string getName(){
        return question;
    }

    public Answer[] GetAllAnswers(){
        return answers;
    }

    public Answer GetAnswer(int index){
        return answers[index];
    }

}

[System.Serializable]
public class Quizz {

    public Question[] questions;

    public Quizz(Question[] m_question){
        questions = m_question;
    }

    public Question[] getAllQuestions(){
        return questions;
    }

    public Question GetQuestion(int index){
        return questions[index];
    }
    
}