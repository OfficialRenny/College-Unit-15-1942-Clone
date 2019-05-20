using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public static int curLevel;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (curLevel < 1) curLevel = 1;
    }

}
