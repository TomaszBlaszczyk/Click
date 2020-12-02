using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    public GameObject startPanel;
    public GameObject endPanel;

    public RectTransform mainPanel;

    public int currentScore = 0;
    public Text currentScoreText;
    public Text currentScoreText_endScreen;

    public Image timeBar;

    public bool isStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentScoreText.text = currentScore.ToString();
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        isStarted = true;
    }

    public void GameOver()
    {
        isStarted = false;
        endPanel.SetActive(true);
        currentScoreText_endScreen.text = currentScore.ToString();
        LampController.Instance.TurnOffAllLamps();
    }

    public void PlayAgain()
    {
        currentScore = 0;
        endPanel.SetActive(false);
        startPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
