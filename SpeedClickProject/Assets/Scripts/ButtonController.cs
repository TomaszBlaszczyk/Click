using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : Singleton<ButtonController>
{
    public List<ButtonItem> buttons;

    public Sprite button_red;
    public Sprite button_green;

    // Start is called before the first frame update
    void Start()
    {
        buttons = new List<ButtonItem>(FindObjectsOfType<ButtonItem>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckCorrectButton(ButtonItem buttonItem)
    {
        if(buttonItem.ID == LampController.Instance.currentValue)
        {
            AudioController.Instance.PlayCorrectSound();

            buttonItem.buttonImage.sprite = button_green;
            buttonItem.buttonImage.DOColor(Color.white, 0.5f).OnComplete(() => { buttonItem.buttonImage.sprite = button_red; });
            Debug.LogWarning("Dobrze! ID: " + buttonItem.ID);
            LampController.Instance.RandomizeLamps();
            UIController.Instance.currentScore++;
            TimeController.Instance.timer = 0f;
            TimeController.Instance.currentTime -= 0.1f;

            if (TimeController.Instance.currentTime < 1f)
            {
                TimeController.Instance.currentTime = 1f;
            }

        }
        else
        {
            AudioController.Instance.PlayWrongSound();
            UIController.Instance.mainPanel.DOShakePosition(1f, 8f);
            TimeController.Instance.timer += (TimeController.Instance.timer * 0.5f);
        }
    }
}
