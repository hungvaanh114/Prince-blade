using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttack : MonoBehaviour
{
    private KnightData knightData;
    private Key key;
    [SerializeField] private KnightMove knightMove;
    [SerializeField] private GameObject knight;
    [SerializeField] private GameObject spellAtt1;
    [SerializeField] private GameObject spellAtt2;

    private Animator animator;

    private Coroutine delayCoroutine;

    private int combo=0;
    private bool isAttack;
    public bool isOnModeQ;

    private List<Skeleton> botsInRange = new List<Skeleton>();
    private BossMage bossMageInRange ;
    void Start()
    {
        animator = knight.GetComponentInChildren<Animator>();
        knightData = Resources.Load<KnightData>("GameData/Knight/KnightData");
        key = Resources.Load<Key>("GameData/Keys");
    }
    void Update()
    {

        Combos();
    }

    public void StartCombo()
    {
        if (combo < 1)
        {
            combo++;
            isAttack = false;
        }
    }
    public void FinishAni()
    {
        knightMove.IsMove(true);
        isAttack = true;
    }
    public void Combos()
    {
        if ((Input.GetKeyDown(key.AttackKey) && !isAttack) )
        {
            knightMove.IsMove(false);
            isAttack = true;
            animator.SetTrigger("attack" + combo);
            delayCoroutine = StartCoroutine(DelayAttack(knightData.AttackSpeed));
            if (combo != 0)
            {
                StopCoroutine(delayCoroutine);
                delayCoroutine = null;
                StartCoroutine(DelayAttack(knightData.AttackSpeed));
            }
            
        }

        if (isAttack)
        {
            combo = 0;
        }
    }
    private IEnumerator DelayAttack(float time)
    {
        yield return new WaitForSeconds(time);
        isAttack = false;
        knightMove.IsMove(true);
    }
    public void Attack()
    {
        foreach ( Skeleton bot in botsInRange)
        {
            bot.TakeDamage(knightData.AttackPower);
            if (bot.skeMV.skeletonData.Hp<=0)
            {
                botsInRange.Remove(bot);
                break;
            }
        }
        if (bossMageInRange != null)
        {
            if (bossMageInRange.skeletonData.Hp > 0)
            {
                bossMageInRange.TakeDamage(knightData.AttackPower);
            }
        }

    }
/*    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bot"))
        {
            Skeleton bot = collision.GetComponent<Skeleton>();
            if (bot != null && !botsInRange.Contains(bot))
            {
                botsInRange.Add(bot);
            }
        }
    }*/

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bot"))
        {
            Skeleton bot = collision.GetComponent<Skeleton>();
            if (bot != null && !botsInRange.Contains(bot))
            {
                botsInRange.Add(bot);
            }
            BossMage bossMage = collision.GetComponent<BossMage>();
            if (bossMage!=null)
            {
                bossMageInRange = bossMage;
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Skeleton bot = collision.GetComponent<Skeleton>();
        if (bot != null && botsInRange.Contains(bot))
        {
            botsInRange.Remove(bot);
        }
        bossMageInRange = null;
    }
    void SpellAttack1()
    {
        if (isOnModeQ)
        {
            spellAtt1.SetActive(true);
        } 
    }
    void SpellAttack2()
    {
        if (isOnModeQ)
        {
            spellAtt2.SetActive(true);
        }
    }
}
