using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class IntroManager : MonoBehaviour
{
    [FormerlySerializedAs("storyPanel")] [Header("Settings")]
    public GameObject StoryPanel;

    [FormerlySerializedAs("pictureShown")] public Image SeenImage;
    [FormerlySerializedAs("storyImage")] public Sprite[] StorySprites;

    [FormerlySerializedAs("gameSceneName")]
    public string gameScene = "SampleScene";

    private int ImageLine = 0;

    void Start()
    {
        if (StoryPanel != null)
            StoryPanel.SetActive(false);
    }

    public void startStory()
    {
        StoryPanel.SetActive(true);
        ImageLine = 0;
        UpdateImage();
    }

    public void NextImage()
    {
        ImageLine++;

        if (ImageLine >= StorySprites.Length)
        {
            startGame();
        }
        else
        {
            UpdateImage();
        }
    }

    void UpdateImage()
    {
        SeenImage.sprite = StorySprites[ImageLine];
    }

    void startGame()
    {
        SceneManager.LoadScene(gameScene);
    }
}