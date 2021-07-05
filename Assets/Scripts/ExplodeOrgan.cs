using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplodeOrgan : MonoBehaviour
{
    private Transform _currentOrgan;
    private bool _isExploded = false;

    void Start()
    {
        _currentOrgan =  GameObject.Find("CurrentOrgan").transform.GetChild(0);
    }

    public void Explode()
    {
        
        if (!_isExploded)
        {
            Debug.Log("Nombre d_objets 3D " + _currentOrgan.childCount);

            _currentOrgan.GetComponent<SphereCollider>().enabled = false;
            _currentOrgan.GetComponent<OVRGrabbable>().enabled = false;

            Vector3 exploded = UnityEngine.Random.insideUnitSphere;
            Debug.Log(exploded);

            foreach (Transform obj3d in _currentOrgan)
            {
                Debug.Log(obj3d.gameObject.name);

                obj3d.gameObject.AddComponent<SphereCollider>();
                Debug.Log("SphereCollider ajoute !");

                obj3d.gameObject.AddComponent<OVRGrabbable>();
                Debug.Log("OVRGrabbable ajoute !");

                obj3d.gameObject.AddComponent<Rigidbody>().isKinematic = true;
                Debug.Log("Rigidbody ajoute !");

                transform.position = exploded;

                //float angle = Vector3.Angle(organCenter, obj3d.localPosition);
                //Vector3 target = Quaternion.Euler(angle, 0, 0) * Vector3.forward;
                //obj3d.position += target;

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
