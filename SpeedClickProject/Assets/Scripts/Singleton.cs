﻿using UnityEngine;
using System.Collections;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    #region Instance

    //##################################################

    private static T instance = null;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
                if (instance == null)
                {
                    string goName = typeof(T).ToString();
                    GameObject go = GameObject.Find(goName);
                    if (go == null)
                    {
                        go = new GameObject();
                        go.name = goName;
                    }

                    DontDestroyOnLoad(go);
                    instance = go.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    //##################################################

    #endregion

    #region Properties

    //##################################################

    protected bool init = false;
    public bool IsInit
    {
        get { return this.init; }
    }

    //##################################################

    #endregion
}