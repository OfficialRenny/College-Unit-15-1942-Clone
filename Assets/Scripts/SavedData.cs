using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class SavedData {
    private static SavedData instance = new SavedData();
    public IDictionary<int, int> highScore = new Dictionary<int, int>();
    
    public static SavedData getInstance()
    {
        return instance;

    }

}
