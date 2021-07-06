using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Question
{
    public string label;
    public Dictionary<string, bool> answers;

    public bool isCorrect(Dictionary<string, bool> userAnswers)
    {
        bool ret = true;
        foreach(var a in answers)
            foreach(var uA in userAnswers)
            {
                if(uA.Key == a.Key)
                {
                    Debug.Log(uA.Value + " " + a.Value);

                    if(uA.Value != a.Value)
                        ret = false;    
                }
                    


            }
                
        
        return ret;
    }
}