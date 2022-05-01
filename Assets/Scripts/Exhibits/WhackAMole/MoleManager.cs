using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class MoleManager : MonoBehaviour
{
    public float frequency;
    private float currentTime;
    private bool playing;
    public float moleActiveTime = 1f;
    private int numMolesHit;

    private List<MoleController> moles;
    private List<MoleController> activeMoles;

    private void Start()
    {
        activeMoles = new List<MoleController>();
        moles = new List<MoleController>(GetComponentsInChildren<MoleController>());
    }
    private void Update()
    {
        if (playing)
        {
            currentTime += Time.deltaTime;
            if(currentTime > frequency)
            {
                currentTime = 0;
                ActivateRandomMole();
            }
        }
    }
    [Button]
    public void StartPlaying()
    {
        playing = true;
    }
    [Button]
    public void StopPlaying()
    {
        playing = false;
        currentTime = 0;
        foreach (MoleController mole in moles)
        {
            mole.LowerMole();
        }
    }
    private void ActivateRandomMole()
    {
        if (moles.Count < 1)
            return;
        int randomInt = Random.Range(0, moles.Count);
        activeMoles.Add(moles[randomInt]);
        moles[randomInt].RaiseMole();
        StopCoroutine(LowerMole(moles[randomInt]));
        StartCoroutine(LowerMole(moles[randomInt]));
        moles.RemoveAt(randomInt);
    }
    private IEnumerator LowerMole(MoleController mole)
    {
        yield return new WaitForSeconds(moleActiveTime);
        mole.LowerMole();
    }
    public void MoleHit(MoleController mole)
    {
        //StopCoroutine(LowerMole(mole));
    }
    public void ReturnMole(MoleController mole)
    {
        activeMoles.Remove(mole);
        moles.Add(mole);
    }
}
