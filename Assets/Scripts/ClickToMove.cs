using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;  

public class ClickToMove : MonoBehaviour
{
    public Camera playerCamera;  
    public NavMeshAgent agent;   
    private RaycastHit hitInfo;  

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = playerCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out hitInfo))
            {
                Vector3 hitPoint = hitInfo.point;
                
                hitPoint.y = agent.transform.position.y; 

                NavMeshHit navHit;
                if (NavMesh.SamplePosition(hitPoint, out navHit, 1.0f, NavMesh.AllAreas))
                {
                    agent.SetDestination(navHit.position);
                  
                }
             
            }
        }
    }
}