using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float travelTime;
    public Transform top;
    public Transform bottom;
    
    private Rigidbody _rb;
    private bool _isBottom = true;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void MoveElevator()
    {
        _rb.DOMove(_isBottom ? top.position : bottom.position, travelTime);

        _isBottom = !_isBottom;
    }
}
