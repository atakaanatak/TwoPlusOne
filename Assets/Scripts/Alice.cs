using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Interactables;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Alice : MonoBehaviour
{
    public int Health;
    [SerializeField] private Room  MainRoom;
    public static Action OnGameOver;
    public NavMeshAgent agent;
    public bool shouldPatrol;
    public Room selectedRoom;
    public static Action OnReturnedToMainRoom;
    public bool isEntered;

    private void Start()
    {
        BaseInteractable.OnInteract += SetRoomCompleteAndReturnToMainRoom;
        Eye.OnTimeRunOut += TakeDamage;
        
    }

    private void OnDestroy()
    {
        BaseInteractable.OnInteract -= SetRoomCompleteAndReturnToMainRoom;
        Eye.OnTimeRunOut -= TakeDamage;
    }
    
    private void TakeDamage()
    {
        HealthBar canSistemi = FindFirstObjectByType<HealthBar>();
        if (canSistemi != null)
        {
            canSistemi.TakeDmg(1);
        }
        Health--;
        if(Health <= 0) OnGameOver?.Invoke();
    }

    public IEnumerator GoToRoom(Room room)
    {  
        selectedRoom = room;
        isEntered = false;
        Debug.Log("Alice : "+selectedRoom+" :  Opened" + "Patrol : " + room.GetLock());
        agent.SetDestination(selectedRoom.transform.position);
        
        if (room.GetLock())
        {
            shouldPatrol = true;
          
            while (shouldPatrol)
            {
                
                Patrol(); 
                yield return new WaitForSeconds(1);
                ActivateRoom();
            }
        }
        else
        {
            yield return new WaitForSeconds(1);
            ReturnToMainRoom();
        }

    }
    
    private void Patrol()
    {
        var a = selectedRoom.GetNextPatrolPoint().position;
        agent.SetDestination(a);
        
    }
    private void ActivateRoom()
    {
        if (isEntered) return;
        Debug.Log(selectedRoom+" : Room Activated");
        selectedRoom.OpenEye();
        isEntered = true;
    }

    private void SetRoomCompleteAndReturnToMainRoom()
    {
        selectedRoom.SetCompleted(true);
        ReturnToMainRoom();
    }
    
    private void ReturnToMainRoom()
    {
        StopCoroutine( GoToRoom(selectedRoom));
        selectedRoom.CloseEye();
        agent.SetDestination(MainRoom.transform.position);
        shouldPatrol = false;
        OnReturnedToMainRoom?.Invoke();
        
        
      
    }

}