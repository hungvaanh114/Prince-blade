using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossMage : MonoBehaviour
{
    public SkeletonData skeletonData;

    public float hoverHeight ;
    public float hoverSpeed = 2.0f;
    public GameObject fireBall1;
    public GameObject fireBall2;
    public GameObject fireBall3;
    public GameObject fireBall4;
    public GameObject fireBall6;
    public GameObject fireBall5;
    public GameObject fireBall7;
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint6;
    public Transform firePoint5;
    public Transform firePoint7;
    private GameObject itemHpDropPrefab;
    private GameObject itemManaDropPrefab;
    private GameObject itemGoldDropPrefab;
    public Slider slider;
    private float dropChance = 0.2f;
    private float moveSpeed = 2.0f;  // Tốc độ di chuyển
    private float direction;
    private float hoverTime; 
    private bool movingRight = true;  // Đang di chuyển sang phải hay không
    public bool isMove = true;
    public bool isAttack = false;
    public bool isDead = false;
    public Animator animator;
    private GameObject parent;
    public GameObject damageTextPrefab; // Tham chiếu đến prefab của DamageText
    public Transform damageTextSpawnPoint;

    void Start()
    {
        itemHpDropPrefab = Resources.Load<GameObject>("Prefabs/Item/PotionBlue");
        itemManaDropPrefab = Resources.Load<GameObject>("Prefabs/Item/PotionBlue");
        itemGoldDropPrefab = Resources.Load<GameObject>("Prefabs/Item/Gold");
        parent = transform.parent.gameObject;
        slider.maxValue = skeletonData.MaxHp;

        hoverHeight = transform.position.y;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        moveSpeed = skeletonData.Speed;
        animator = transform.GetComponent<Animator>();
    }

    void Update()
    {
        slider.value = skeletonData.Hp;
        if (skeletonData.Hp <= 0)
        {
            isMove = false;
        }
        if (isMove)
        {
            Hover();
            Move();
        }
        else
        {
            transform.Translate(Vector2.zero);
            animator.SetBool("run", false);
        }
    }

    void Hover()
    {
        hoverTime += hoverSpeed * Time.deltaTime;
        float newY = hoverHeight + Mathf.Sin(hoverTime);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
    private void Move()
    {
        // Di chuyển Skeleton
        direction = movingRight ? 1 : -1;
        transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);
        animator.SetBool("run", true);
    }
    public void Flip()
    {
        movingRight = !movingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
/*    public void IsMoveOnAttack()
    {
        isMove = false;
    }*/
    void FireBall1()
    {
        GameObject bullet = Instantiate(fireBall1, firePoint1.position, Quaternion.identity);
        bullet.transform.SetParent(transform);
    }void FireBall4()
    {
        GameObject knight = GameObject.Find("Knight");
        transform.position = new Vector3(knight.transform.position.x, transform.position.y, 0);
        GameObject bullet = Instantiate(fireBall4,new Vector3( transform.position.x, transform.position.y-1,0), Quaternion.identity);
        bullet.transform.SetParent(transform);
        Destroy(bullet,10f);
    }

    void FireBall2()
    {
        GameObject bullet = Instantiate(fireBall2, firePoint2.position, Quaternion.identity);
        bullet.GetComponent<FireBallMage2>().hoverHeight = firePoint2.transform.position.y;
    }
    void FireBall3()
    {
        GameObject bullet = Instantiate(fireBall3, firePoint3.position, Quaternion.identity);
    }
    void FireBall7()
    {
        isMove = false;
        StartCoroutine(SpawnFireBallsEverySecond());
    }
    private IEnumerator SpawnFireBallsEverySecond()
    {
        BoxCollider2D boxCollider2D = firePoint7.GetComponent<BoxCollider2D>();
        int b = Random.Range(30, 50);
        for (int i = 0; i <= b; i++)
        {
            Vector3 offset = new Vector3(Random.Range(-boxCollider2D.size.x / 2, boxCollider2D.size.x / 2),
                boxCollider2D.size.y, 0f);
            Vector3 spawnPosition = firePoint7.transform.position + offset;
            GameObject bullet = Instantiate(fireBall7, spawnPosition, Quaternion.identity);
            if (i == b) { isMove = true; }
            yield return new WaitForSeconds(0.2f);
        }
        isMove = true;
        animator.SetTrigger("attack end");
    }

    void FireBall5()
    {
        BoxCollider2D boxCollider2D = firePoint5.GetComponent<BoxCollider2D>();
        Vector3 offset = new Vector3(-boxCollider2D.size.x / 2.2f, -boxCollider2D.size.y/3f, 0f);
        Vector3 spawnPosition = firePoint5.transform.position + offset;
        GameObject bullet = Instantiate(fireBall5, spawnPosition, Quaternion.identity);
    }
    void FireBall6()
    {
        BoxCollider2D boxCollider2D = firePoint5.GetComponent<BoxCollider2D>();
        GameObject bullet = Instantiate(fireBall6, firePoint6.position, Quaternion.identity);
        bullet.transform.SetParent(transform);
        bullet.GetComponent<FireBallMage6>().ballLocalScale = boxCollider2D.size.x*2;
        if(transform.localScale.x>0)
            bullet.GetComponent<FireBallMage6>().runRight = true;
        else
            bullet.GetComponent<FireBallMage6>().runRight = false;
    }

    public void TakeDamage(float damage)
    {
        skeletonData.Hp -= damage;
        GameObject damageTextObject = Instantiate(damageTextPrefab, damageTextSpawnPoint.position, Quaternion.identity);
        damageTextObject.transform.SetParent(damageTextSpawnPoint);
        DameText damageText = damageTextObject.GetComponent<DameText>();

        damageText.SetDamage(damage);
        StartCoroutine(OnHit(0.5f));
        Debug.Log("Bot nhan " + damage);
        if (skeletonData.Hp <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        if (isDead)
        {
            DropItem();
            GameObject sli = slider.gameObject;
            sli.SetActive(false);
            Rigidbody2D[] rigidbodies = GetComponentsInChildren<Rigidbody2D>();
            foreach (Rigidbody2D rigidbody in rigidbodies)
            {
                rigidbody.simulated = false;
            }

            Collider2D[] colliders = parent.GetComponentsInChildren<Collider2D>();

            // Bật tất cả các Collider2D
            foreach (Collider2D collider in colliders)
            {
                collider.enabled = false;
            }
        }
        animator.SetTrigger("die");
        
    }
    void AActive()
    {
        skeletonData.Hp = skeletonData.MaxHp;
        if (isDead)
        {
            parent.SetActive(false);
        }
        isDead = true;
    }
    private IEnumerator OnHit(float delayDuration)
    {
        animator.SetTrigger("onhit");
        isMove = false;
        yield return new WaitForSeconds(delayDuration);
        isMove = true;
    }
    void DropItem()
    {
        if (Random.value < dropChance)
        {
            Instantiate(itemHpDropPrefab, transform.position, Quaternion.identity);
        }
        if (Random.value < dropChance)
        {
            Instantiate(itemManaDropPrefab, transform.position, Quaternion.identity);
        }
        int a = Random.Range(20, 100);
        for (int i = 0; i < a; i++)
        {
            // Tạo biến ngẫu nhiên để thay đổi vị trí khởi tạo
            Vector3 offset = new Vector3(Random.Range(-1f, 1f), Random.Range(-0.5f, 1.5f), 0f);
            Vector3 spawnPosition = transform.position + offset;

            // Instantiate item
            Instantiate(itemGoldDropPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
