using HurricaneVR.Framework.Core.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPointerVCVR : HVRUIPointer
{
    public GameObject m_Dot;

    private void Update()
    {
        Pointer.enabled = CurrentUIElement;
        m_Dot.SetActive(CurrentUIElement);
        if (Pointer.enabled)
        {
            Pointer.SetPosition(0, transform.position + 0.2f * Vector3.Normalize(PointerEventData.pointerCurrentRaycast.worldPosition - transform.position));//Pointer.SetPosition(0, transform.position);
            Pointer.SetPosition(1, PointerEventData.pointerCurrentRaycast.worldPosition);
            m_Dot.transform.position = PointerEventData.pointerCurrentRaycast.worldPosition;
            m_Dot.transform.LookAt(PointerEventData.pointerCurrentRaycast.worldPosition + PointerEventData.pointerCurrentRaycast.worldNormal);
        }

        
    }
}
