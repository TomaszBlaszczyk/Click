using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LampItem : MonoBehaviour
{
    public int ID { get; set; }

    public TypeOfLamp type;

    public int value;

    public bool Active { get; set; } = false;

    private Image lampImage;

    // Start is called before the first frame update
    void Start()
    {
        this.ID = Convert.ToInt32(string.Join("", gameObject.name.ToCharArray().Where(Char.IsDigit)));
        Debug.Log(gameObject.name + " ID: " + ID);
        lampImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActiveLamps()
    {
        if (Active)
        {
            lampImage.sprite = LampController.Instance.lamp_on;
            LampController.Instance.currentValue += this.value;
        }
        else
        {
            lampImage.sprite = LampController.Instance.lamp_off;
        }
    }
}

public enum TypeOfLamp
{
    None,
    Vertical,
    Horizontal
}