using System;
using System.Collections;
using UnityEngine;

namespace Interactables
{
    public class BaseInteractableMove: BaseInteractable
    {
        protected Action onComplete;
        protected IEnumerator MoveOverTime(Vector3 targetPosition, float duration)
        {
            Vector3 startPosition = transform.position;
            float timeElapsed = 0f;  

            while (timeElapsed < duration)
            {
                float t = timeElapsed / duration;

            
                transform.position = Vector3.Lerp(startPosition, targetPosition, t);
                
                timeElapsed += Time.deltaTime;
                
                yield return null;
            }
            
            transform.position = targetPosition;
            onComplete?.Invoke();
        }
        protected void ResetObject()
        {
            isUsed = false;
            onComplete -= ResetObject;
        }
    }
}