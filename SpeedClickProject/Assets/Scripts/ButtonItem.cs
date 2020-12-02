using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ButtonItem : MonoBehaviour
{
    public int ID { get; set; }

    public Image buttonImage;

    // Start is called before the first frame update
    void Start()
    {
        this.ID = Convert.ToInt32(string.Join("", gameObject.name.ToCharArray().Where(Char.IsDigit)));
        Debug.Log(gameObject.name + " ID: " + ID);
        buttonImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
