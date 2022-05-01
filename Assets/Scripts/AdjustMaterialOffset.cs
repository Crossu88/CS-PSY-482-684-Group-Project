using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class AdjustMaterialOffset : MonoBehaviour
{
    public Vector2 offsetAxis;
    [Header("Automatic")]
    public bool auto;
    public float speed;

    private Material adjustedMat;

    private void Start()
    {
        adjustedMat = GetComponent<Renderer>().material;
    }
    private void Update()
    {
        if (auto)
            adjustedMat.mainTextureOffset = adjustedMat.mainTextureOffset + (offsetAxis * speed * Time.deltaTime);
    }
    public void SetOffset(float newOffset)
    {
        adjustedMat.mainTextureOffset = adjustedMat.mainTextureOffset + (offsetAxis * newOffset);
    }
}
