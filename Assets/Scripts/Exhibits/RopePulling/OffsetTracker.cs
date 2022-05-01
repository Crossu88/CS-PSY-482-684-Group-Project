using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class OffsetTracker : MonoBehaviour
{
    public float movementMultiplier = 1f;
    public AdjustMaterialOffset materialOffset;
    private Vector3 lastPosition;
    private float change;
    public Axis axis;
    public enum Axis { x, y, z }

    private void Update()
    {
        switch (axis)
        {
            case Axis.x:
                change = transform.localPosition.x - lastPosition.x;
                break;
            case Axis.y:
                change = transform.localPosition.y - lastPosition.y;
                break;
            case Axis.z:
                change = transform.localPosition.z - lastPosition.z;
                break;
            default:
                break;
        }
        lastPosition = transform.localPosition;
        materialOffset.SetOffset(change * movementMultiplier);
    }
    [Button]
    public void ResetPosition(Vector3 newPos)
    {
        transform.localPosition = newPos;
        lastPosition = newPos;
    }
}
