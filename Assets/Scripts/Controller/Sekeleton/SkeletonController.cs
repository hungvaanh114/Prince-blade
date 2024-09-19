using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    public SkeletonData skeletonData;  // Tham chiếu đến ScriptableObject chứa dữ liệu của skeleton

    private float health;
    private float attackPower;
    private float moveSpeed;

    void Start()
    {
        // Gán dữ liệu từ SkeletonData cho đối tượng Skeleton
        Initialize(skeletonData);
    }

    public void Initialize(SkeletonData data)
    {
        if (data != null)
        {
            health = data.Hp;
            attackPower = data.AttackPower;
            moveSpeed = data.Speed;
        }
        else
        {
            Debug.LogError("Skeleton data is null!");
        }
    }
}
