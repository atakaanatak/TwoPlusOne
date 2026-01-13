using Interactables;
using System;
using System.Collections;
using Interactables;
using UnityEngine;
namespace DefaultNamespace
{
    public class Remote: BaseInteractableMove
    {
        protected override void Interact()
        {
            if(!canBeInteractable) return;
            base.Interact();
            StartCoroutine( MoveOverTime(new Vector3(9.1f,0.8f,-5f), 1f));
            StartCoroutine(WaitAndReset(60f));
        }
        protected override void ResetInteractable()
        {
            StartCoroutine( MoveOverTime(new Vector3(9.1f,1.5f,-6f), 1f));
            onComplete += ResetObject;
        }
    }
}