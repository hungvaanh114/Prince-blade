using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightActions : MonoBehaviour
{
    [SerializeField] private SimpleFlash flashEffect;
    [SerializeField] private GameObject startGame;
    public KnightData knightData;
    private GameObject knight;
    public KnightMove move;
    public Animator animator;
    private KnightAttack modeQ;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Color flashColor;
    private Key key;


    [SerializeField] private float healingAmount = 20f; // Lượng hồi máu
    [SerializeField] private float manaAmount = 20f;
    [SerializeField] private float manaSpell1 = 10f;
    [SerializeField] private float timeModeQ = 10f;
    [SerializeField] private float dameBonus = 15f;
    [SerializeField] private float cooldownTime = 10f;
    [SerializeField] private bool isCooldown = false;


    private bool die=false;

    private void Start()
    {
        knight = GameObject.Find("Knight");
        knightData = Resources.Load<KnightData>("GameData/Knight/KnightData");
        animator = knight.GetComponentInChildren<Animator>();
        modeQ = knight.GetComponent<KnightAttack>();
        key = Resources.Load<Key>("GameData/Keys");
        spriteRenderer = knight.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
            ColorUtility.TryParseHtmlString("#EC7E7E", out flashColor); // Chuyển mã màu thành đối tượng Color
        }
    }
    private void Update()
    {
        if (die)
        {
            return; 
        }
        Actions();
    }

    public void Actions()
    {

        if (Input.GetKeyDown(key.UsePotionRedKey))
        {
            Heal();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            InteractWithNPC();
        }
        if (Input.GetKeyDown(key.Skill1Key)&&!isCooldown)
        {
            CastSpell(1);
            
        }
        if (Input.GetKeyDown(key.Skill1Key) && !isCooldown)
        {
            StartCoroutine(Cooldown());
            CastSpell(2);
        }
        if (Input.GetKeyDown(key.UsePotionBlueKey))
        {
            Mana();
        }

    }
    IEnumerator Cooldown()
    {
        isCooldown = true; 
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }
    private void Mana()
    {
        if (knightData.Mana < knightData.MaxMana)
        {
            knightData.Mana += manaAmount;
            knightData.PotionBlue--;
            if (knightData.Mana >= knightData.MaxMana)
                knightData.Mana = knightData.MaxMana;
        }
    }

    public void Heal()
    {
        if ( knightData.PotionRed > 0 && knightData.Health < knightData.MaxHp)
        {
            knightData.Health += healingAmount ;
            knightData.PotionRed--;
        if ( knightData.Health >= knightData.MaxHp)
             knightData.Health = knightData.MaxHp;
        }
        
    }

    public void InteractWithNPC()
    {

    }

    public void CastSpell(int a)
    {
        if (knightData.Mana >  manaSpell1)
        {
            knightData.Mana = knightData.Mana - manaSpell1;
            StartCoroutine(ModeQ(timeModeQ));
        }
    }

    public void TakeDamage(float damage)
    {
        if (knightData.Health > 0) { 

            knightData.Health -= damage;
            flashEffect.Flash();
            Debug.Log("Took damage: " + damage + ". Current health: " + knightData.Health);
            if (knightData.Health <= 0)
            {
                knightData.Health = 0;
                StartCoroutine(Die(4f));
            }
            else
            {
                animator.SetTrigger("onHit");
            }
        }
    }

    private IEnumerator Die(float delayDuration)
    {
        move.IsMove(false);
        animator.SetTrigger("dead");
        Debug.Log("Knight died.");
        this.enabled=false;
        move.enabled = false;
        knight.GetComponent<KnightAttack>().enabled = false;
        yield return new WaitForSeconds(delayDuration);
        move.IsMove(true);
        this.enabled = true;
        move.enabled = true;
        knight.GetComponent<KnightAttack>().enabled = true;
        knight.transform.position = startGame.transform.position;
        animator.SetTrigger("endDead");
        knightData.Health = knightData.MaxHp;
    }
    private IEnumerator ModeQ(float delayDuration)
    {
        knightData.AttackPower = knightData.AttackPower + dameBonus;
        spriteRenderer.color = flashColor;
        modeQ.isOnModeQ = true;
        yield return new WaitForSeconds(delayDuration);
        spriteRenderer.color = originalColor;
        modeQ.isOnModeQ = false;
        knightData.AttackPower = knightData.AttackPower - dameBonus;
    }
   
}

