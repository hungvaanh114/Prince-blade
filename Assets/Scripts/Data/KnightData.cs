using UnityEngine;

[CreateAssetMenu(fileName = "KnightData", menuName = "Game Data/Knight Data")]
public class KnightData : ScriptableObject
{ 
    [SerializeField] private float health = 10f;  // Máu
    [SerializeField] private float mana = 10f;    // Năng lượng/Mana
    [SerializeField] private float attackPower = 10f; // Sức mạnh tấn công
    [SerializeField] private float speed = 10f;   // Tốc độ di chuyển
    [SerializeField] private float attackSpeed = 10f; // Tốc độ đánh
    [SerializeField] private float jumpHeight = 10f;   // Chiều cao nhảy
    [SerializeField] private float maxHP = 100f;
    [SerializeField] private float maxMana = 100f;
    [SerializeField] private int potionBlue = 1;
    [SerializeField] private int potionRed = 1;
    [SerializeField] private int gold = 0;
    public float Health
    {
        get => health;
        set => health = value;
    }

    public float Mana
    {
        get => mana;
        set => mana = value;
    }

    public float AttackPower
    {
        get => attackPower;
        set => attackPower = value;
    }

    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    public float AttackSpeed
    {
        get => attackSpeed;
        set => attackSpeed = value;
    }

    public float JumpHeight
    {
        get => jumpHeight;
        set => jumpHeight = value;
    }

    public float MaxHp
    {
        get => maxHP;
        set => maxHP = value;
    }

    public float MaxMana
    {
        get => maxMana;
        set => maxMana = value;
    }
    public int PotionBlue
    {
        get => potionBlue;
        set => potionBlue = value;
    }
    public int PotionRed
    {
        get => potionRed;
        set => potionRed = value;
    }
    public int Gold
    {
        get => gold;
        set => gold = value;
    }
}

