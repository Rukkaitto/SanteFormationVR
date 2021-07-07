using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplodeOrgan : MonoBehaviour
{
    private GameObject _currentOrgan;
    private bool _isExploded = false;
    public float spreadFactor = 0.0001f;

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

                Vector3 randomInSphere = UnityEngine.Random.insideUnitSphere * 2f;
                Debug.Log(UnityEngine.Random.insideUnitSphere);
                Vector3 dest = model.transform.position + new Vector3(randomInSphere.x, randomInSphere.y, randomInSphere.z);

                StartCoroutine("Lerp", new object[3]{ model, dest, 10f});

                MeshCollider collider = model.AddComponent<MeshCollider>();
                collider.convex = true;

                Rigidbody rigidbody = model.AddComponent<Rigidbody>();
                rigidbody.isKinematic = true;


                OVRGrabbable grap = model.AddComponent<OVRGrabbable>();
                grap.enabled = true;
                grap.CustomGrabCollider(collider);

                Debug.Log("Transformation modifiee !");
            }

            }

        _isExploded = true;
    }

    IEnumerator Lerp(object[] parms)
    {
        GameObject model = (GameObject) parms[0];
        Vector3 destination = (Vector3) parms[1];
        float speed = (float) parms[2];

        model.transform.position = Vector3.Lerp(model.transform.position, destination, Time.deltaTime * speed);
        Debug.Log("Bouge !");
        yield return null;
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
