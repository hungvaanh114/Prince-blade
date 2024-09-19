using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private SimpleFlash flashEffect;
    [SerializeField] private GameObject itemHpDropPrefab;  
    [SerializeField] private GameObject itemManaDropPrefab;  
    [SerializeField] private GameObject itemGoldDropPrefab;  
    [SerializeField] private float dropChance = 0.2f;
    public SekeletonMove skeMV;
    public Slider slider;
    private Animator animator;
    private GameObject parent;
    private SkeletonAttack skeletonAttack;

    private void Start()
    {
        animator = GetComponent<Animator>();
        slider.maxValue = skeMV.skeletonData.MaxHp;
        parent = transform.parent.gameObject;
        skeletonAttack = parent.GetComponentInChildren<SkeletonAttack>();
        itemHpDropPrefab = Resources.Load<GameObject>("Prefabs/Item/PotionBlue");
        itemManaDropPrefab = Resources.Load<GameObject>("Prefabs/Item/PotionBlue");
        itemGoldDropPrefab = Resources.Load<GameObject>("Prefabs/Item/Gold");
    }
    private void Update()
    {
        slider.value = skeMV.skeletonData.Hp;
    }
    public void TakeDamage(float damage)
    {
        skeMV.skeletonData.Hp -= damage;
        StartCoroutine(OnHit(0.5f));
        Debug.Log("Bot nhan "+ damage);
        if (skeMV.skeletonData.Hp <= 0)
        {
            StartCoroutine(Die(4f)); 
        }
    }

    private IEnumerator Die(float delayDuration)
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
            animator.SetTrigger("die");
        Debug.Log("die");
        yield return new WaitForSeconds(delayDuration);
        Debug.Log("Bot đã chết!");
        
        parent.SetActive(false);
        skeMV.skeletonData.Hp = skeMV.skeletonData.MaxHp;
    }
    void DropItem()
    {
        // Kiểm tra xác suất rơi vật phẩm
        if (Random.value < dropChance)
        {
            // Tạo ra vật phẩm tại vị trí hiện tại của quái vật
            Instantiate(itemHpDropPrefab, transform.position, Quaternion.identity);
        }
        if (Random.value < dropChance)
        {
            // Tạo ra vật phẩm tại vị trí hiện tại của quái vật
            Instantiate(itemManaDropPrefab, transform.position, Quaternion.identity);
        }
        if (Random.value < dropChance)
        {
            int a = Random.Range(1, 50) ;
            for(int i = 0; i<a;i++ )
            Instantiate(itemGoldDropPrefab, transform.position, Quaternion.identity);
        }
    }

    private IEnumerator OnHit(float delayDuration)
    {
        animator.SetTrigger("onHit");
        flashEffect.Flash();
        skeMV.isMove = false;
        yield return new WaitForSeconds(delayDuration);
        skeMV.isMove = true;
    }
    public void SkeletonAttackKinght()
    {
        skeletonAttack.KnightTakedame();
    }
}
