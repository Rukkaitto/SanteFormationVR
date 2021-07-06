using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplodeOrgan : MonoBehaviour
{
    private Transform _currentOrgan;
    private bool _isExploded = false;
    public float spreadFactor = 0.3f;

    void Start()
    {

    }

    public void Explode()
    {
        
        if (!_isExploded)
        {

            _currentOrgan.GetComponent<SphereCollider>().enabled = false;
            _currentOrgan.GetComponent<OVRGrabbable>().enabled = false;
            
            foreach (Transform obj3d in transform)
            {
                GameObject model = obj3d.GetChild(0).gameObject;

                Vector3 randomVector = Vector3.ClampMagnitude(UnityEngine.Random.insideUnitSphere * 100, spreadFactor);
                model.transform.position += new Vector3(randomVector.x, randomVector.y, randomVector.z);

                model.gameObject.AddComponent<SphereCollider>();

                model.gameObject.AddComponent<OVRGrabbable>();

                model.gameObject.AddComponent<Rigidbody>().isKinematic = true;

                Debug.Log("Transformation modifiee !");
            }

            }

        _isExploded = true;
    }

    public void Join()
    {
        _isExploded = false;
    }

    public void Restart()
    {
        Debug.Log("Reset Scene !");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
