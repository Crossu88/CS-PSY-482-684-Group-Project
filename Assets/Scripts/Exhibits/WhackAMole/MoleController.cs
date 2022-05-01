using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine.Events;

public class MoleController : MonoBehaviour
{
    private MoleManager moleManager;
    private bool hitable;
    private float highestImpulse;
    public float minImpulse, maxImpulse, minDuration, maxDuration, raiseDuration, lowerDuration;
    private void Start()
    {
        moleManager = GetComponentInParent<MoleManager>();
    }
    [Button]
    public void RaiseMole()
    {
        hitable = true;
        transform.DOLocalMoveY(1.017056f, raiseDuration);
    }
    [Button]
    public void LowerMole()
    {
        transform.DOLocalMoveY(0.8279f, lowerDuration);
        StartCoroutine(ResetMole(lowerDuration));
    }
    private IEnumerator ResetMole(float duration)
    {
        yield return new WaitForSeconds(duration);
        moleManager.ReturnMole(this);
        hitable = false;
        highestImpulse = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!hitable)
            return;
        float impulse = collision.impulse.magnitude;
        //if (impulse < highestImpulse)
        //    return;
        highestImpulse = impulse;
        StopAllCoroutines();
        Debug.Log("Hit Mole with Impluse: " + impulse);
        if (impulse > minImpulse)
        {
            impulse = Mathf.Clamp(impulse, minImpulse, maxImpulse);
            float duration = (1 - (impulse - minImpulse) / (maxImpulse - minImpulse)) * (maxDuration - minDuration) + minDuration;
            HitMole(duration);
            moleManager.MoleHit(this);
        }
    }
    public void HitMole(float duration)
    {
        transform.DOLocalMoveY(0.8279f, duration);
        StartCoroutine(ResetMole(duration));
    }
}
