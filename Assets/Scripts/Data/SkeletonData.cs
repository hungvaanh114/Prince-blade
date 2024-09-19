using UnityEngine;

[CreateAssetMenu(fileName = "SkeletonData", menuName = "Game Data/Skeleton Data")]
public class SkeletonData : ScriptableObject
{
    [SerializeField] private new string name = "Skeleton"; 
    [SerializeField] private float positionX = 0f;   
    [SerializeField] private float positionY = 0f;
    [SerializeField] private float maxHp = 0f;
    [SerializeField] private float hp = 0f;
    [SerializeField] private float speed = 0f;
    [SerializeField] private float attackPower = 0f;
    [SerializeField] private float attackSpeed = 0f;

    // Getters and setters
    public string Name
    {
        get => name;
        set => name = value;
    }
    public float PositionX
    {
        get => positionX;
        set => positionX = value;
    }
    public float PositionY
    {
        get => positionY;
        set => positionY = value;
    }
    public float MaxHp
    {
        get => maxHp;
        set => maxHp = value;
    }

    public float Hp
    {
        get => hp;
        set => hp = value;
    }
    public float Speed
    {
        get => speed;
        set => speed = value;
    }
    public float AttackPower
    {
        get => attackPower;
        set => attackPower = value;
    }
    public float AttackSpeed
    {
        get => attackSpeed;
        set => attackSpeed = value;
    }


}

