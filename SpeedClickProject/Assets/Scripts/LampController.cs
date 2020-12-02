using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : Singleton<LampController>
{
    private LampItem[] foundLamps;

    private List<LampItem> verticalLamps = new List<LampItem>();
    private List<LampItem> horizontalLamps = new List<LampItem>();

    public int activeLampID_V = 0;
    public int activeLampID_H = 0;

    public int currentValue = 0;

    public Sprite lamp_off;
    public Sprite lamp_on;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FindLamps()
    {
        if(foundLamps == null)
        {
            foundLamps = FindObjectsOfType<LampItem>();

            Debug.Log("Wyszukuje lampki!");

            foreach (var lamp in foundLamps)
            {
                if (lamp.type == TypeOfLamp.Vertical)
                {
                    Debug.Log("Dodaje lampe V o ID: " + lamp.ID);
                    verticalLamps.Add(lamp);
                }
                else if (lamp.type == TypeOfLamp.Horizontal)
                {
                    Debug.Log("Dodaje lampe H o ID: " + lamp.ID);
                    horizontalLamps.Add(lamp);
                }
            }
        }

        RandomizeLamps();
    }

    public void RandomizeLamps()
    {
        currentValue = 0;

        activeLampID_V = Random.Range(0, verticalLamps.Count);

        foreach (var lamp in verticalLamps)
        {
            if(lamp.ID == activeLampID_V)
            {
                lamp.Active = true;
            }
            else
            {
                lamp.Active = false;
            }

            lamp.ActiveLamps();
        }

        activeLampID_H = Random.Range(0, horizontalLamps.Count);

        foreach (var lamp in horizontalLamps)
        {
            if (lamp.ID == activeLampID_H)
            {
                lamp.Active = true;
            }
            else
            {
                lamp.Active = false;
            }

            lamp.ActiveLamps();
        }
    }

    public void TurnOffAllLamps()
    {
        foreach (var lamp in foundLamps)
        {
            lamp.Active = false;
            lamp.ActiveLamps();
        }
    }
}
