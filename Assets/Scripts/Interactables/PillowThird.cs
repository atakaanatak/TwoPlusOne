using System;
using System.Collections;
using Interactables;
using UnityEngine;
namespace Interactables
{
    public class PillowThird: BaseInteractableMove
    {
        

        protected override void Interact()
        {
            if(!canBeInteractable) return;
            base.Interact();
            
            StartCoroutine( MoveOverTime(new Vector3(9.8f,0.4f,-7.6f), 1f));
            StartCoroutine(WaitAndReset(60f));
        }
        protected override void ResetInteractable()
        {
            StartCoroutine( MoveOverTime(new Vector3(8.77383f,0.873f,-8.936069f), 1f));
            onComplete += ResetObject;
        }
    }
}