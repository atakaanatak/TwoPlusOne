using System;
using System.Collections;
using UnityEngine;

namespace Interactables
{
    public class CatBed : BaseInteractableMove
    {
        public Collider EasterEgg;
        protected override void Interact()
        {
            if(!canBeInteractable) return;
            base.Interact();
            
            StartCoroutine( MoveOverTime(new Vector3(1.841f,0.3305974f,-3f), 1f));
            EasterEgg.enabled = true;
            StartCoroutine(WaitAndReset(60f));
        }
        protected override void ResetInteractable()
        {
            StartCoroutine( MoveOverTime(new Vector3(1.841f,0.3305974f,-2.033f), 1f));
            EasterEgg.enabled = false;
            onComplete += ResetObject;
        }

        
    }
}