using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
    public float attackCooldown = 1.5f;  // Thời gian giữa các lần tấn công
    public float attackDamage = 20f;        // Lượng sát thương gây ra
    private bool isAttacking = false;
    private float attackTimer = 1f;
    private bool knightExit = true;

    private Animator animator;
    private Transform knight;
    private SekeletonMove sekeletonMove;
    public SkeletonData skeletonData;
    public bool isSkeletonMove=true;
    public bool isSkeletonMove1 = false;
    void Start()
    {
        sekeletonMove = transform.parent.GetComponent<SekeletonMove>();
        skeletonData = sekeletonMove.skeletonData;
        attackDamage = skeletonData.AttackPower;
        attackCooldown = skeletonData.AttackSpeed;
        animator = transform.parent.GetComponent<Animator>();
        
    }

    void Update()
    {
        if (knight != null && isAttacking)
        {
            if (knight.gameObject.activeSelf)
            {
                attackTimer += Time.deltaTime;
                if (attackTimer >= attackCooldown)
                {
                    Attack();
                    attackTimer = 0f;
                }
            }
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra xem đối tượng vào vùng là knight hay không
        if (other.CompareTag("knight"))
        {
            knight = other.transform;
            isAttacking = true;
            if (knightExit)
            {
                attackTimer = attackCooldown-0.5f;
                knightExit = false;
                sekeletonMove.isMove = false;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        // Kiểm tra xem đối tượng trong vùng là knight hay không
        if (other.CompareTag("knight"))
        {
            knight = other.transform;
            isAttacking = true;
            sekeletonMove.isMove = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        // Kiểm tra xem knight có rời khỏi tầm đánh hay không
        if (other.CompareTag("knight"))
        {
            knight = null;
            isAttacking = false;
            knightExit = true;
            StartCoroutine(skeMove(skeletonData.AttackSpeed/5f));
        }
    }


    void Attack()
    {
        animator.SetTrigger("attack");
    }
    public void KnightTakedame()
    {
        if (knight != null)
        { 
            // Thực hiện gây sát thương cho knight
            KnightActions knightActions = knight.GetComponentInChildren<KnightActions>();

            if (knightActions != null)
            {
                if(knightActions.knightData.Health > 0)
                {
                    knightActions.TakeDamage(attackDamage);
                }
            }
            else
            {
                Debug.Log("knightActions = null");
            }
        }
       
    }
    private IEnumerator skeMove(float delayDuration)
    {
        yield return new WaitForSeconds(delayDuration);
        sekeletonMove.isMove = true;
    }
}
