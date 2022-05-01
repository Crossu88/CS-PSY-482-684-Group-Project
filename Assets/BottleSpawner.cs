using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleSpawner : MonoBehaviour
{
    public GameObject prefab;
    private GameObject _curGO;

    private void Start()
    {
        CreateBottles();
    }

    public void ResetPrefab()
    {
        Destroy(_curGO);
        CreateBottles();
        
    }

    private void CreateBottles()
    {
        _curGO = Instantiate(prefab, transform, false);
    }
}
