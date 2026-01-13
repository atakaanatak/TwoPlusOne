using System.Collections;
using Interactables;
using UnityEngine;
using System;

namespace DefaultNamespace
{
    public class BathroomCabin : BaseInteractableRotate
    {
        protected override void Interact()
        {
            if(!canBeInteractable) return;
            base.Interact();
            
            StartCoroutine( RotateOverTime(Quaternion.Euler(0f, -50f, 0f), 1f));
            StartCoroutine(WaitAndReset(60f));
        }
        protected override void ResetInteractable()
        {
            StartCoroutine( RotateOverTime(Quaternion.Euler(0f, 0f, 0f), 1f));
            onComplete += ResetObject;
        }
    }
}