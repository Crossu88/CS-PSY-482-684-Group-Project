using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCrankHandle : MonoBehaviour
{
    private Quaternion constRotation;
    // Start is called before the first frame update
    void Start()
    {
        constRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = constRotation;
    }
}
