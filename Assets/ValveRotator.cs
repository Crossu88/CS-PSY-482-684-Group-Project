using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveRotator : MonoBehaviour
{
    private Vector3 _startAngle;
    private ToggleMat _tm;
    private bool _isActive;
    private float _lastAng;
    

    private void Start()
    {
        _startAngle = transform.rotation.eulerAngles;
        _tm = GetComponent<ToggleMat>();
    }

    public void ChangeAngle(float angle, float delta)
    {
        transform.rotation = Quaternion.Euler(_startAngle + Vector3.up * angle);

        if (_tm == null) return;
        
        if (_lastAng < 90 && angle >= 90)
            _tm.ChangeMat();
        else if (_lastAng >= 90 && angle < 90)
            _tm.ChangeMat();

        _lastAng = angle;
    }
}
