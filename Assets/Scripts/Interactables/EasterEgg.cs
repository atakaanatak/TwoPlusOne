using System;
using System.Collections;
using UnityEngine;

namespace Interactables
{
    public class EasterEgg : BaseInteractable
    {
        private Action onComplete;

        protected override void Interact()
        {
            if (!canBeInteractable) return;
            CatAnimator.SetTrigger("pati");
            if (VolumeButton.SoundOn)
                GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
            interactableButton.gameObject.SetActive(false);
            isUsed = true;
            StartCoroutine(MoveAndScaleOverTime(new Vector3(5.39f, 2.56f, -4.41f), 1f, 20f));
            StartCoroutine(WaitAndReset(2f));
        }

        private IEnumerator MoveAndScaleOverTime(Vector3 targetPosition, float duration, float scaleMultiplier)
        {
            Vector3 startPosition = transform.position;
            Vector3 startScale = transform.localScale;

            Vector3 targetScale = startScale * scaleMultiplier;
            float timeElapsed = 0f;

            while (timeElapsed < duration)
            {
                float t = timeElapsed / duration;

                transform.position = Vector3.Lerp(startPosition, targetPosition, t);

                transform.localScale = Vector3.Lerp(startScale, targetScale, t);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPosition;
            transform.localScale = targetScale;

            onComplete?.Invoke();
        }

        protected override void ResetInteractable()
        {
            StartCoroutine(MoveAndScaleOverTime(new Vector3(1.841f, 0.33f, -1.90f), 1f, 0.05f));
            onComplete += ResetObject;
        }

        private void ResetObject()
        {
            isUsed = false;
            onComplete -= ResetObject;
        }
    }
}