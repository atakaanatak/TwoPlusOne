using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Interactables
{
    public class BaseInteractable : MonoBehaviour
    {
        
        public static Action OnInteract;
        
        public Button interactableButton;  // The button you want to position
        public Canvas worldSpaceCanvas;
        public Animator CatAnimator;
        
        private AudioSource audioSource;
        protected bool canBeInteractable;
        protected bool isUsed;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            interactableButton.onClick.AddListener(Interact);
            interactableButton.gameObject.SetActive(false);  
        }

        public void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag("Player") && !isUsed)
            {
               
                Vector3 worldPosition = new Vector3(this.transform.position.x, interactableButton.transform.position.y, this.transform.position.z);
                Vector3 localPosition = worldSpaceCanvas.transform.InverseTransformPoint(worldPosition);
                interactableButton.transform.localPosition = localPosition;
                interactableButton.transform.localPosition += new Vector3(0f, 0f, 0f);
                interactableButton.gameObject.SetActive(true); 
                canBeInteractable = true;
            }
        }

        public void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && !isUsed)
            {
               
                Vector3 worldPosition = new Vector3(this.transform.position.x, interactableButton.transform.position.y, this.transform.position.z);
                Vector3 localPosition = worldSpaceCanvas.transform.InverseTransformPoint(worldPosition);
                interactableButton.transform.localPosition = localPosition;
                interactableButton.transform.localPosition += new Vector3(0f, 0f, 0f);
                interactableButton.gameObject.SetActive(true); 
                canBeInteractable = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                interactableButton.gameObject.SetActive(false); 
                canBeInteractable = false;
            
            }
        }
    
        
        protected IEnumerator WaitAndReset(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            ResetInteractable();
         
        }
        
        protected virtual void ResetInteractable()
        {

         
        }

        protected virtual void Interact()
        {
            CatAnimator.SetTrigger("pati");
            if(VolumeButton.SoundOn)
                audioSource.PlayOneShot(audioSource.clip);
            
            
            interactableButton.gameObject.SetActive(false); 
            isUsed = true;
            OnInteract?.Invoke();
        }
    }
}