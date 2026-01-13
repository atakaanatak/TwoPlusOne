using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomManager : MonoBehaviour
{
    public static Action OnGameWon;
    [SerializeField] private Alice alice;
    [SerializeField] private Room[] rooms;
    public Room currentRoom;
    public bool patrol;
    public List<Room> unSelectedRooms;
    private Coroutine waitCoroutine;

    private void Start()
    {
        Alice.OnReturnedToMainRoom += StartWait;
        PickRoom();
    }

    private void OnDestroy()
    {
        Alice.OnReturnedToMainRoom -= StartWait;
    }
    
    private void StartWait()
    {
        if (waitCoroutine != null)
        {
            StopCoroutine(waitCoroutine);
        }
        
        waitCoroutine = StartCoroutine(WaitAndReturnToMainRoom(2f));
    }

    private IEnumerator WaitAndReturnToMainRoom(float delay)
    {
        yield return new WaitForSeconds(delay);
        PickRoom();
    }

    [ContextMenu("Pick Room")]
    private async void PickRoom()
    {
        currentRoom = GetRandomRoom();
        if (!currentRoom)
        {
            Debug.Log("No Rooms Left");
            Debug.Log("GameOver");
            OnGameWon?.Invoke();
            
            return;
        }
        patrol = Random.Range(0, 2) == 0;
        currentRoom.SetLock(patrol);
      
        currentRoom.SetSelected(true);
        StopAllCoroutines();
        StartCoroutine(alice.GoToRoom(currentRoom));
    }
    
    private Room GetRandomRoom()
    {
        unSelectedRooms = rooms.Where(room => !room.GetCompleted()).ToList();

        if (unSelectedRooms.Count <= 0) return null;
        var randomIndex = Random.Range(0, unSelectedRooms.Count);
        return unSelectedRooms[randomIndex];

    }
    
    
}