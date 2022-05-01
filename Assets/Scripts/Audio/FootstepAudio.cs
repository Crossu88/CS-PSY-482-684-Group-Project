using HurricaneVR.Framework.Core.Player;
using Impact;
using Impact.Triggers;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepAudio : MonoBehaviour
{
    [Header("HVR Settings")]
    [SerializeField]
    private HVRPlayerController player;

    [Header("Footstep Settings")]
    public LayerMask interactableLayers;
    [SerializeField]
    private float footstepDistance = 2.25f;
    [SerializeField]
    private float groundedDistance = 0.5f;
    [SerializeField]
    [ReadOnly]
    private float distanceTravelled = 0f;
    private Vector3 previousPosition = Vector3.zero;

    [Header("Impact Ineraction System Settings")]
    [SerializeField]
    private ImpactTag footstepTag;

    private bool bIsGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckGrounded();

        distanceTravelled += Vector3.Distance(transform.position, previousPosition);

        if (distanceTravelled > footstepDistance && bIsGrounded)
        {
            distanceTravelled = 0f;
            PlayFootstep();
        }

        previousPosition = transform.position;
    }

    private void CheckGrounded()
    {
        bIsGrounded = Physics.Raycast(transform.position, Vector3.down, groundedDistance, interactableLayers);
    }

    [Button]
    private void PlayFootstep()
    {
        float velocity = 1f;//( Vector3.Distance(transform.position, previousPosition) * Time.deltaTime ) / player.MoveSpeed;


        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 10f, interactableLayers))
        {
            InteractionData data = new InteractionData
            {
                Velocity = Vector3.down * velocity,
                CompositionValue = 1,
                PriorityOverride = 100,
                ThisObject = this.gameObject
            };

            data.TagMask = footstepTag.GetTagMask();

            //print(hit.collider);

            ImpactRaycastTrigger.Trigger(data, hit, true);
        }
    }
}
