using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SekeletonMove : MonoBehaviour
{
    private float moveSpeed = 2.0f;  // Tốc độ di chuyển
    public float direction;
    public bool movingRight = true;  // Đang di chuyển sang phải hay không
    public bool isPrecinct = false;// Kiểm tra nếu Skeleton đang đứng trên mặt đất
    public bool isMove = true;

    private Animator animator;
    public SkeletonData skeletonData;

    private void Start()
    {
       // transform.position = new Vector3(skeletonData.PositionX, skeletonData.PositionY, 0);
        moveSpeed = skeletonData.Speed;
        animator =transform.GetComponent<Animator>();
    }
    private void Update()
    {
        if (skeletonData.Hp <= 0)
        {
            isMove = false;
        }
        if (isMove)
        {
            Move();
        }
        else
        {
            transform.Translate(Vector2.zero);
            animator.SetBool("walk", false);
        }
    }
    private void Move()
    {
        if (isPrecinct)
        {
            Flip();
            isPrecinct = false;
        }
        // Di chuyển Skeleton
        direction = movingRight ? 1 : -1;
        transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);
        animator.SetBool("walk",true);
    }
    public void Flip()
    {
        // Đảo hướng di chuyển
        movingRight = !movingRight;
        // Lật hình ảnh của Skeleton
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

}
