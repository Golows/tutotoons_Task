using System;
using System.Collections.Generic;

[Serializable]
public class Level
{
    public List<int> x;
    public List<int> y;

    public Level() 
    {
        x = new List<int>();
        y = new List<int>();
    }
}
