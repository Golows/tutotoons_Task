using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{

    public TextAsset textJSON;

    public Root root = new Root();

    public void LoadData()
    {
        root = JsonUtility.FromJson<Root>(textJSON.text);

        foreach(DataLevel lvl in root.levels)
        {
            Level newLevel = new Level();
            for(int i = 0; i < lvl.level_data.Count; i++) 
            {
                if(i%2 == 0)
                {
                    newLevel.x.Add(lvl.level_data[i]);
                }
                else
                {
                    newLevel.y.Add(lvl.level_data[i]);
                }
            }
            GameController.instance.levels.Add(newLevel);
        }
    }

    private void Awake()
    {
        LoadData();
    }
}

[Serializable]
public class DataLevel
{
    public List<int> level_data;
}

[Serializable]
public class Root
{
    public List<DataLevel> levels;
}
