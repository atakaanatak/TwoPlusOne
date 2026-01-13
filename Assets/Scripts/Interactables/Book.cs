using System;
using System.Collections;
using Interactables;
using UnityEngine;

namespace DefaultNamespace
{
    public class Book: BaseInteractableMove
    {
        protected override void Interact()
        {
            if(!canBeInteractable) return;
            base.Interact();
            
            StartCoroutine( MoveOverTime(new Vector3(0.9298301f,0.6f,-2.678f), 1f));
            StartCoroutine(WaitAndReset(60f));
        }
        protected override void ResetInteractable()
        {
            StartCoroutine( MoveOverTime(new Vector3(0.874f,1.357f,-3.311f), 1f));
            onComplete += ResetObject;
        }
    }
}