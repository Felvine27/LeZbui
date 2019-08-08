using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePointsText : MonoBehaviour
{

    [SerializeField]
    private Text lifePointsText;

    void Start()
    {
        
    }

    void Update()
    {

        lifePointsText.text = "HP: " + LifeManager.LifePoints.ToString();

    }
}
