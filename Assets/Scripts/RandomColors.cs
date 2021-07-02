using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColors : MonoBehaviour
{
    public Material baseMaterial;
    void Start()
    {
        foreach (Transform child in transform)
        {
            GameObject model = child.GetChild(0).gameObject;
            Renderer modelRenderer = model.GetComponent<Renderer>();
            modelRenderer.material = baseMaterial;
            float randomHue = Random.Range(0.0f, 1.0f);
            modelRenderer.material.color = Color.HSVToRGB(randomHue, 0.5f, 1.0f);
        }
    }

    void Update()
    {
        
    }
}
