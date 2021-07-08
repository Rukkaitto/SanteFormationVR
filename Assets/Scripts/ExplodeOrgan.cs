using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplodeOrgan : MonoBehaviour
{
    private bool _isExploded = false;
    public float spreadFactor = 0.3f;

    void Start()
    {

    }

    public void Explode()
    {
        
        if (!_isExploded)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<SphereCollider>().enabled = false;
            gameObject.GetComponent<OVRGrabbable>().enabled = false;

            transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

            foreach (Transform obj3d in transform)
            {
                GameObject model = obj3d.GetChild(0).gameObject;

                Vector3 randomInSphere = Vector3.ClampMagnitude(UnityEngine.Random.insideUnitSphere * 5f, spreadFactor);

                obj3d.position += randomInSphere;

                MeshCollider collider = model.GetComponent<MeshCollider>();

                Rigidbody rigidbody = model.GetComponent<Rigidbody>();
                rigidbody.isKinematic = true;

                OVRGrabbable grap = model.AddComponent<OVRGrabbable>();
                grap.enabled = true;
                grap.CustomGrabCollider(collider);

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
        Debug.Log("Reset Scene !" + SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
