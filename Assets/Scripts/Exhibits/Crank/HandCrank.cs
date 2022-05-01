using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;
using HurricaneVR.Framework.Core.Utils;
using HurricaneVR.Framework.Shared;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Atlas.Puzzles
{
    [RequireComponent(typeof(Rigidbody))]
    public class HandCrank : MonoBehaviour
    {
        public HVRGrabbable Grabbable;
        public GameObject ball1, ball2;
        public Vector3 axis;

        public virtual void Start()
        {
            Grabbable ??= GetComponent<HVRGrabbable>();
        }

        protected virtual void FixedUpdate()
        {
            if (!Grabbable || !Grabbable.IsHandGrabbed) return;
            
            var handTransform = Grabbable.HandGrabbers[0].TrackedController.transform;

            var localHandTransform = transform.InverseTransformPoint(handTransform.position);

            transform.LookAt(handTransform);

            transform.localRotation = Quaternion.Euler(Vector3.Scale(transform.localRotation.eulerAngles, axis));

            if (!(ball1 && ball2)) return;

            ball1.transform.position = handTransform.position;

            ball2.transform.localPosition = Vector3.Scale(localHandTransform,  Vector3.one - axis);
        }
    }
}