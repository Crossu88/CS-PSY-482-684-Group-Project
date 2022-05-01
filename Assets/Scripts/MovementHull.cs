using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHull : MonoBehaviour
{
    //[Header("Hull Settings")]
    private Vector3 lastPos;

    [Header("Debug")]

    [SerializeField]
    private Transform characterTransform;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    void FixedUpdate()
    {
        if (characterTransform)
            characterTransform.position += transform.position - lastPos;

        lastPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other is CharacterController)
            characterTransform = other.transform.parent;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other is CharacterController)
            characterTransform = null;
    }
}
