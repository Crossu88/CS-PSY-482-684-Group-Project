using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrankAudio : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioSource audioSource;
    public float velocityStartThreshold = 1f;
    public float velocityStopThreshold = 0.5f;
    [SerializeField]
    private float expectedVelocity = 0.5f;
    [SerializeField]
    private float minimumPitch = 0.5f;
    [SerializeField]
    private float audioFadeInTime = 1f;
    [SerializeField]
    private float audioFadeOutTime = 1f;
    [SerializeField]
    [Range(0f, 1f)]
    private float audioMaxVolume = 1f;
    private bool bIsPlaying = false;

    [SerializeField]
    private Transform velocityTracker;
    private Vector3 lastPosition = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private Vector3 lastVelocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        lastPosition = velocityTracker.position;
    }

    void FixedUpdate()
    {
        velocity = velocityTracker.position - lastPosition;

        if (velocity.magnitude / Time.deltaTime > velocityStartThreshold && !bIsPlaying)
        {
            //audioSource.Play();
            StopAllCoroutines();
            StartCoroutine(FadeInAudio());
        }
        else if (velocity.magnitude / Time.deltaTime < velocityStopThreshold && bIsPlaying)
        {
            //audioSource.Stop();
            StopAllCoroutines();
            StartCoroutine(FadeOutAudio());
        }

        CalculatePitch();

        lastVelocity = velocity;
        lastPosition = velocityTracker.position;
    }

    private void CalculatePitch()
    {
        audioSource.pitch = Mathf.Max(minimumPitch, (velocity.magnitude / Time.deltaTime) / expectedVelocity);
    }

    private IEnumerator FadeInAudio()
    {
        bIsPlaying = true;

        audioSource.Stop();
        audioSource.volume = 0f;

        audioSource.Play();

        while (audioSource.volume < audioMaxVolume)
        {
            audioSource.volume += audioMaxVolume * Time.deltaTime * (1 / audioFadeInTime);
            yield return null;
        }

        audioSource.volume = audioMaxVolume;
    }

    private IEnumerator FadeOutAudio()
    {
        bIsPlaying = false;

        audioSource.volume = audioMaxVolume;

        while (audioSource.volume > 0f)
        {
            audioSource.volume -= audioMaxVolume * Time.deltaTime * (1 / audioFadeInTime);
            yield return null;
        }

        audioSource.volume = 0f;
        audioSource.Stop();
    }
}
