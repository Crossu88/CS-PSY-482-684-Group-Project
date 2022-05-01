using HurricaneVR.Framework.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIButtonClickAudio : MonoBehaviour
{
    public AudioClip clickAudio;
    public void playClickAudio()
    {
        SFXPlayer.Instance.PlaySFX(clickAudio, transform.position);
    }
}
