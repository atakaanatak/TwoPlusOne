using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Serialization;

public class PopUpDamageScreen : MonoBehaviour
{
    public static Action DamageOn;
    public static Action DamageOff;

    [Header("Settings")] public Image movingPicture;
    public Sprite[] pictureList;
    public float transitionSpeed = 1.0f;
    public float screenTime = 1.5f;


    private Vector3 rightSide;
    private Vector3 leftSide;
    private Vector3 midPoint;

    private Coroutine currentSlideCoroutine;

    void Start()
    {
        if (movingPicture != null)
        {
            midPoint = Vector3.zero;

            rightSide = new Vector3(Screen.width, 0, 0);
            leftSide = new Vector3(-Screen.width, 0, 0);


            movingPicture.rectTransform.anchoredPosition = new Vector2(2000, 0);
            movingPicture.gameObject.SetActive(false);
        }
    }


    public void ShowDmg(int whichDamage)
    {
        DamageOn?.Invoke();


        int index = whichDamage - 1;

        if (index >= 0 && index < pictureList.Length)
        {
            movingPicture.sprite = pictureList[index];
            movingPicture.gameObject.SetActive(true);
            movingPicture.rectTransform.anchoredPosition = new Vector2(2000, 0);


            if (currentSlideCoroutine != null)
            {
                StopCoroutine(currentSlideCoroutine);
            }

            currentSlideCoroutine = StartCoroutine(SlidingCanvas());
        }
    }

    IEnumerator SlidingCanvas()
    {
        RectTransform rt = movingPicture.rectTransform;

        float time = 0;
        Vector2 start = new Vector2(2000, 0);
        Vector2 goal = Vector2.zero; // Orta

        while (time < 1f)
        {
            time += Time.deltaTime * transitionSpeed;
            rt.anchoredPosition = Vector2.Lerp(start, goal, time);
            yield return null;
        }


        yield return new WaitForSeconds(screenTime);


        time = 0;
        start = Vector2.zero;
        goal = new Vector2(-2000, 0);

        while (time < 1f)
        {
            time += Time.deltaTime * transitionSpeed;
            rt.anchoredPosition = Vector2.Lerp(start, goal, time);
            yield return null;
        }


        movingPicture.gameObject.SetActive(false);
        DamageOff?.Invoke();
    }
}