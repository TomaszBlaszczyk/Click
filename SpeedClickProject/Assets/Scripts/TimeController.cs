using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : Singleton<TimeController>
{
    public float defaultTime = 4f;
    public float currentTime;

    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = defaultTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(UIController.Instance.isStarted)
        {
            timer += Time.deltaTime;
            UIController.Instance.timeBar.fillAmount = (currentTime - timer) / currentTime;

            if (timer >= currentTime)
            {
                timer = 0f;
                UIController.Instance.GameOver();
                Debug.LogWarning("Przegrałeś!");
            }

            if (timer >= currentTime * 0.5)
            {
                UIController.Instance.timeBar.color = Color.red;
            }
            else
            {
                UIController.Instance.timeBar.color = Color.white;
            }
        }
        else
        {
            timer = 0f;
            currentTime = defaultTime;
        }
    }
}
