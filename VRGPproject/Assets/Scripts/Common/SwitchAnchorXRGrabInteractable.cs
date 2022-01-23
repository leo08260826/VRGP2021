using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SwitchAnchorXRGrabInteractable : XRGrabInteractable
{
    public Transform leftHandAttachTransform, rightHandAttachTransform;
    // Start is called before the first frame update
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactor.name.ToLower().Contains("left"))
        {
            attachTransform = leftHandAttachTransform;
        }
        else
        {
            attachTransform = rightHandAttachTransform;
        }
        base.OnSelectEntered(args);
    }
}
