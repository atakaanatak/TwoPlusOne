using System;
using System.Collections;
using Interactables;
using UnityEngine;

namespace DefaultNamespace
{
    public class PillowFirst: BaseInteractableMove
    { 
        protected override void Interact()
        {
            if(!canBeInteractable) return;
            base.Interact();
            
            StartCoroutine( MoveOverTime(new Vector3(7.7f,0.6f,-5.6f), 1f));
            StartCoroutine(WaitAndReset(60f));
        }
        protected override void ResetInteractable()
        {
            StartCoroutine( MoveOverTime(new Vector3(6.21f,1.22f,-6.34f), 1f));
            onComplete += ResetObject;
        }
    }
}