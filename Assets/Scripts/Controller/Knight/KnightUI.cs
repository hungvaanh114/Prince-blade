using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightUI : MonoBehaviour
{
    private KnightActions knightActions;
    [SerializeField]private Slider HpBar;
    [SerializeField]private Slider ManaBar;
    [SerializeField]private Text PotionBlue;
    [SerializeField] private Text PotionRed;
    [SerializeField] private Text Gold;
    void Start()
    {
        knightActions =  GetComponentInChildren<KnightActions>();
        HpBar.maxValue = knightActions.knightData.MaxHp;
        ManaBar.maxValue = knightActions.knightData.MaxMana;

    }
    void Update()
    {
        HpBar.value = knightActions.knightData.Health;
        ManaBar.value = knightActions.knightData.Mana;
        PotionBlue.text ="X" + knightActions.knightData.PotionBlue;
        PotionRed.text = "X" + knightActions.knightData.PotionRed;
        Gold.text = "" + knightActions.knightData.Gold;
    }
}
