using UnityEngine;

public class FireBallMage6 : MonoBehaviour
{
    [SerializeField] private float dame;
    [SerializeField] private float growSpeed = 5f; // Tốc độ dài ra của laser
    [SerializeField] private float rotateSpeed = 180f; // Tốc độ xoay
    private bool isGrowing = true; // Trạng thái đang dài ra
    private bool isRotating = false; // Trạng thái đang xoay
    private BossMage bossMage;
    public float ballLocalScale=100f;
    private float rotationAngle = 0f; // Góc xoay hiện tại của laser
    private KnightActions knightActions;
    public bool runRight=true;
    private void Start()
    {
        bossMage = GetComponentInParent<BossMage>();
    }
    void Update()
    {
        bossMage.isMove = false;
        if (isGrowing)
        {
            // Tăng kích thước laser dần dần
            transform.localScale += new Vector3(growSpeed * Time.deltaTime, 0, 0);
            if(transform.localScale.x> ballLocalScale)
            {
                isGrowing = false;
                isRotating = true;
            }
        }

        if (isRotating)
        {
            // Xoay laser 180 độ
            if (runRight)
            {
                rotationAngle -= rotateSpeed * Time.deltaTime;
                if (rotationAngle <= -180f)
                {
                    isRotating = false; // Dừng xoay sau khi đạt 180 độ
                    onDestroy();
                }
            }
            else
            {
                rotationAngle += rotateSpeed * Time.deltaTime;
                if (rotationAngle >= 180f)
                {
                    isRotating = false; // Dừng xoay sau khi đạt 180 độ
                    onDestroy();
                }
            }
            transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("knight")) {
            knightActions = collision.GetComponentInChildren<KnightActions>();
            knightActions.TakeDamage(dame);
        }
    }
    public void onDestroy()
    {
        bossMage.animator.SetTrigger("attack end");
        bossMage.isMove = true;
        Destroy(gameObject);
    }
}
