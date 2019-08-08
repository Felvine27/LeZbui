using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LifeManager
{

    private static int _lifePoints = 3;

    public static int LifePoints
    {
        get { return _lifePoints; }
        set { _lifePoints = value; }
    }

}
