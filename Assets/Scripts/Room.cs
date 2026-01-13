using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Room : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private Eye Eye;
    public Light pointLight;
    private bool isLocked;
    private bool isSelected;
    public bool isCompleted;
    private int patrolPointIndex;
    private bool Increase = true;

    private Animator animator;

    private void Awake()
    {
        if (Eye != null)
        {
            animator = Eye.GetComponent<Animator>();
            
        }
    }

    public void SetLock(bool isLocked)
    {
        this.isLocked = isLocked;
    }

    public void SetCompleted(bool isCompleted)
    {
        this.isCompleted = isCompleted;
        CloseEye();
    }

    public void SetSelected(bool isSelected)
    {
         this.isSelected = isSelected;
        
    }
    public void LeaveRoom()
    {
        isLocked = false;
        isSelected = false;
    }

    public void OpenEye()
    {
        if (!Eye) return;

        Debug.Log("Room : " + gameObject.name+" :  Opened" + "Patrol : " + GetLock());
        ColorUtility.TryParseHtmlString("#FF0000", out var color);
        pointLight.color = color;
        animator.SetBool("param",true);
        Eye.StartCountDown();
    } 
    public void CloseEye()
    {
        if (!Eye) return;
        
        ColorUtility.TryParseHtmlString("#A3A3A3", out var color);
        pointLight.color = color;
        Debug.Log(gameObject.name+" :  Closed");
        animator.SetBool("param",false);
        Eye.StopCountDown();
    }

    public bool GetLock() => isLocked;

    public bool GetCompleted() => isCompleted;

    public bool GetSelected() => isSelected;
    public Transform GetNextPatrolPoint()
    {
        if (Increase)
        {
            patrolPointIndex++;
            if(patrolPointIndex == patrolPoints.Length-1) Increase = false;
        }
        else
        {
            patrolPointIndex--;
            if(patrolPointIndex <= 0) Increase = true;
        }
        return patrolPoints[patrolPointIndex];
    }
    

}