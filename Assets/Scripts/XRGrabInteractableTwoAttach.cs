using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabInteractableTwoAttach : XRGrabInteractable
{
    [SerializeField] private Transform          leftAttachTransform;
    [SerializeField] private Transform          rightAttachTransform;

    public override Transform GetAttachTransform(IXRInteractor interactor)
    {
        if (interactor.transform.CompareTag("Left Hand") && attachTransform != leftAttachTransform)
        {
            attachTransform = leftAttachTransform;
        }
        if (interactor.transform.CompareTag("Right Hand") && attachTransform != rightAttachTransform)
        {
            attachTransform = rightAttachTransform;
        }

        return base.GetAttachTransform(interactor);
    }
}
