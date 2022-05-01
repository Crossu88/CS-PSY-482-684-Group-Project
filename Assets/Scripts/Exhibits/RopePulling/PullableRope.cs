using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Atlas.Puzzles
{
    [Serializable]
    public class RopePullEvent : UnityEvent<float> { }

    public class PullableRope : MonoBehaviour
    {
        [Header("Rope Settings")]

        public bool bUpsideDown = false;

        [Range(0f, 10f)]
        public float pullRange;

        [Header("Misc")]

        public HVRGrabbable grabbable;

        public float totalLengthPulled { private set; get; }

        public RopePullEvent onRopePulled = new RopePullEvent();

        private Vector3 lastControllerPos;
        private HVRHandGrabber handGrabber;

        void Start()
        {
            grabbable ??= GetComponent<HVRGrabbable>();
        }

        void FixedUpdate()
        {
            if (grabbable && grabbable.IsHandGrabbed)
            {
                Transform handTransform = grabbable.HandGrabbers[0].TrackedController.transform;

                if (handGrabber == null || handGrabber != grabbable.HandGrabbers[0])
                {
                    handGrabber = grabbable.HandGrabbers[0];
                    lastControllerPos = handTransform.position;
                }

                if (lastControllerPos != Vector3.zero)
                {
                    MoveRope(Vector3.Scale((handTransform.position - lastControllerPos), new Vector3(0f, 1f, 0f)));
                }
                else
                    lastControllerPos = handTransform.position;
            }
            else
                lastControllerPos = Vector3.zero;
        }

        public void MoveRope(Vector3 moveVector)
        {
            if (bUpsideDown)
                transform.localPosition -= moveVector;
            else
                transform.localPosition += moveVector;

            if (transform.localPosition.y < -pullRange)
                transform.localPosition = new Vector3(0f, -pullRange, 0f);
            else if (transform.localPosition.y > pullRange)
                transform.localPosition = new Vector3(0f, pullRange, 0f);
            else
                lastControllerPos = grabbable.HandGrabbers[0].TrackedController.transform.position;

            totalLengthPulled = transform.localPosition.y;

            onRopePulled.Invoke(totalLengthPulled);

            print(totalLengthPulled);
        }
    }
}
