using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplodeOrgan : MonoBehaviour
{
    private Scene scene;
    private List<GameObject> rootGameObjects;
    private GameObject currentOrgan;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        Debug.Log("La sc�ne active est '" + scene.name + "'.");

        rootGameObjects = new List<GameObject>();
        scene.GetRootGameObjects(rootGameObjects);

        foreach(GameObject globalObj in rootGameObjects)
        {
            if(globalObj.name.Contains("Current Organ"))
            {
                Debug.Log("Current Organ trouv� !");
                currentOrgan = globalObj;
                break;
            }
        }

    }

    public void Explode()
    {
        Debug.Log("Explosion !");
        foreach (Component obj3d in currentOrgan.GetComponents<UnityEngine.Object>())
        {
            obj3d.transform.localPosition.Set(new System.Random().Next(100), new System.Random().Next(100), new System.Random().Next(100));
            Debug.Log("Transformation modifi�e !");
        }
    }

    public void Join()
    {

    }
}
