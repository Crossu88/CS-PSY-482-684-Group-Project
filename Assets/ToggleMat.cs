using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMat : MonoBehaviour
{
    public Material mat1;
    public Material mat2;
    private Renderer rend;
    private bool curMat;
    
    // Start is called before the first frame update
    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void ChangeMat()
    {
        curMat = !curMat;
        rend.material = curMat ? mat1 : mat2;
    }
}
