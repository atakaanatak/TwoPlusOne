using Interactables;
using System;
using System.Collections;
using Interactables;
using UnityEngine;

namespace DefaultNamespace
{
    public class PillowSecond: BaseInteractableMove
    {

        protected override void Interact()
        {
            if(!canBeInteractable) return;
            base.Interact();
            
            StartCoroutine( MoveOverTime(new Vector3(8f,0.5f,-7f), 1f));
            StartCoroutine(WaitAndReset(60f));
        }
        protected override void ResetInteractable()
        {
            StartCoroutine( MoveOverTime(new Vector3(6.4f,1f,-9f), 1f));
            onComplete += ResetObject;
        }
        
    }
}