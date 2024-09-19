using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilderController : MonoBehaviour
{
    public Slider sliderHp;
    public Slider sliderMana;
    private KnightData knightData;

    void Start()
    {
        knightData = Resources.Load<KnightData>("GameData/Knight/KnightData");
    }

    // Update is called once per frame
    void Update()
    {
        sliderHp.maxValue = knightData.MaxHp;
        sliderHp.value = knightData.Health;

        sliderMana.maxValue = knightData.MaxMana;
        sliderMana.value = knightData.Mana;
    }
}
