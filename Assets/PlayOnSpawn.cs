using System.Collections;
using System.Collections.Generic;
using HurricaneVR.Framework.Core.Utils;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayOnSpawn : MonoBehaviour
{
    public List<AudioClip> clips;

    // Start is called before the first frame update
    void Start()
    {
        SFXPlayer.Instance.PlaySFX(clips[Random.Range(0, clips.Count)], transform.position);
    }
}
