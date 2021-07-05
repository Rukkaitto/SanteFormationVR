using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour {

    public void Reset(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}