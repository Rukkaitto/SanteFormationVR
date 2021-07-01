using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalable : MonoBehaviour
{
    public float scaleSpeed = 5f;

    public void ScaleUp()
    {
        transform.localScale = transform.localScale + (Vector3.one * scaleSpeed);
    }
    
    public void ScaleDown()
    {
        transform.localScale = transform.localScale - (Vector3.one * scaleSpeed);
    }
}
