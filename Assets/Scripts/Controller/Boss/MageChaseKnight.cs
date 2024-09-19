using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageChaseKnight : MonoBehaviour
{
    public BossMage bossMage;

    private float timer = 0.0f;
    private float fireRate = 5.0f;
    private bool isAttack = false;
    void Start()
    {
        
    }
    void Update()
    {
        if (isAttack)
        {
            timer += Time.deltaTime;
            // Kiểm tra xem thời gian đã trôi qua có đủ 2 giây chưa
            if (timer >= fireRate)
            {
                int randomValue = Random.Range(1, 8);
                switch (randomValue)
                {
                    case 1:
                        Attack1();
                        fireRate = 10f;
                        break;
                    case 2:
                        Attack2();
                        fireRate = 10f;
                        break;
                    case 3:
                        Attack3();
                        fireRate = 3f;
                        break;
                    case 4:
                        Attack4();
                        fireRate = 42f;
                        break;
                    case 5:
                        Attack5();
                        fireRate = 10f;
                        break;
                    case 6:
                        Attack6();
                        fireRate = 12f;
                        break;
                    case 7:
                        Attack7();
                        fireRate = 13f;
                        break;
                    default:
                        Debug.LogError("Unexpected random value.");
                        break;
                }
                isAttack = false;
                timer = 0.0f;
            }

        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bot"))
        {
           bossMage.Flip();
        }
        if (collision.gameObject.CompareTag("knight"))
        {
            bossMage.isMove = true;
            isAttack = false;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("knight"))
        {
            isAttack = true;
        }
    }
    void Attack1()
    {
        bossMage.animator.SetTrigger("attack2");
    }
    void Attack2()
    {
        bossMage.animator.SetTrigger("attack1");
    }
    void Attack3()
    {
        bossMage.animator.SetTrigger("attack3");
    }
    void Attack4()
    {
        StartCoroutine(MoveToKnightRepeatedly());
        
    }
    private IEnumerator MoveToKnightRepeatedly()
    {
        for (int i = 0; i < 3; i++)
        {
            bossMage.animator.SetTrigger("attack4");
            yield return new WaitForSeconds(14f);
        }
    }
    void Attack7()
    {
        bossMage.animator.SetTrigger("attack7");
    }void Attack5()
    {
        bossMage.animator.SetTrigger("attack5");
    }
    void Attack6()
    {
        bossMage.animator.SetTrigger("attack6");
    }




}
