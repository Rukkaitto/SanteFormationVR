using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizzBuzz : MonoBehaviour
{
    public string answerLabel = "Sample Answer";
    private bool answer = false;
    private QuizzManager quizzManager;

    private void Start() {
        quizzManager = GameObject.Find("QuizzManager").GetComponent<QuizzManager>();
        ChangeColor(answer);
    }

    public void SetAnswer()
    {
        answer = !answer;
        ChangeColor(answer);
        quizzManager.SetAnswer(answerLabel, answer);
    }

    void ChangeColor(bool answer)
    {
        if(answer == true)
            GetComponentInChildren<Renderer>().material.color = Color.green;
        else
            GetComponentInChildren<Renderer>().material.color = Color.red;
        
    }
}
