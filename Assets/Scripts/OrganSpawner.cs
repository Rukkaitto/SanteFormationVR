using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganSpawner : MonoBehaviour
{
    public GameObject heart;
    public GameObject brain;
    private GameObject _lastInstantiated;

    public void InstantiateHeart()
    {
        if (_lastInstantiated)
        {
            Destroy(_lastInstantiated);
        }
        _lastInstantiated = Instantiate(heart, transform.position, Quaternion.identity, transform);
    }
    
    public void InstantiateBrain()
    {
        if (_lastInstantiated)
        {
            Destroy(_lastInstantiated);
        }
        _lastInstantiated = Instantiate(brain, transform.position, Quaternion.identity, transform);
    }

    public void ScaleOrganUp()
    {
        if (_lastInstantiated)
        {
            _lastInstantiated.GetComponent<Scalable>().ScaleUp();
        }
    }
    
    public void ScaleOrganDown()
    {
        if (_lastInstantiated)
        {
            _lastInstantiated.GetComponent<Scalable>().ScaleDown();
        }
    }
}
