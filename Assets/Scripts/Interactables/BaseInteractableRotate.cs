using System;
using System.Collections;
using UnityEngine;

namespace Interactables
{
    public class BaseInteractableRotate: BaseInteractable
    {
        protected Action onComplete;


        protected IEnumerator RotateOverTime(Quaternion targetRotation, float duration)
        {
            Quaternion startRotation = transform.rotation;
            float timeElapsed = 0f;

            while (timeElapsed < duration)
            {
                float t = timeElapsed / duration;
                transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            transform.rotation = targetRotation;
            onComplete?.Invoke();
        }
        protected void ResetObject()
        {
            isUsed = false;
            onComplete -= ResetObject;
        }
    }
}