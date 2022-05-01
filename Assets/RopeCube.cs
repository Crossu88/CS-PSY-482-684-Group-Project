using System;
using System.Collections;
using System.Collections.Generic;
using Atlas.Puzzles;
using UnityEngine;

public class RopeCube : MonoBehaviour
{
    public RopePulleyMachine ropePulleyMachine;
    public ToggleMat toggleMat;
    private float _lastLength;

    private void Start()
    {
        toggleMat = GetComponent<ToggleMat>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        var lp = ropePulleyMachine.totalLengthPulled;
        
        transform.localPosition = Vector3.up * lp;
        transform.rotation = Quaternion.Euler(0, lp * 90, 0);
        
        if (_lastLength < 0 && lp >= 0)
            toggleMat.ChangeMat();
        else if (_lastLength >= 0 && lp < 0)
            toggleMat.ChangeMat();

        _lastLength = lp;
    }
}
