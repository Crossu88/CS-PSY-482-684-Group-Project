using HurricaneVR.Framework.Core;
using HurricaneVR.Framework.Core.Grabbers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Atlas.Puzzles
{
    public class RopePulleyMachine : MonoBehaviour
    {
        public PullableRope rope1;
        public PullableRope rope2;

        public float totalLengthPulled;
        private float maxPull;

        public void onRope1Pulled(float lengthPulled)
        {
            rope2.transform.localPosition = new Vector3(0f, lengthPulled, 0f);
            totalLengthPulled = lengthPulled;
        }
        public void onRope2Pulled(float lengthPulled)
        {
            rope1.transform.localPosition = new Vector3(0f, lengthPulled, 0f);
            totalLengthPulled = lengthPulled;
        }

        public void onRope1Grabbed(HVRGrabberBase grabber, HVRGrabbable grabbable)
        {
            rope2.grabbable.ForceRelease();
        }

        public void onRope2Grabbed(HVRGrabberBase grabber, HVRGrabbable grabbable)
        {
            rope1.grabbable.ForceRelease();
        }

        // Start is called before the first frame update
        void Start()
        {
            rope1.onRopePulled.AddListener(onRope1Pulled);
            rope2.onRopePulled.AddListener(onRope2Pulled);
            rope1.grabbable.HandGrabbed.AddListener(onRope1Grabbed);
            rope2.grabbable.HandGrabbed.AddListener(onRope2Grabbed);
            maxPull = rope1.pullRange;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}