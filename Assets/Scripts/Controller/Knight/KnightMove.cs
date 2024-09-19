using UnityEngine;

public class KnightMove : MonoBehaviour
{
    private KnightData knightData; 
    private GameObject knight;
    private Rigidbody2D rb;
    private Animator animator;
    private Key key;

    private bool crouch = false;
    public bool isDead = false;
    public bool isMoving = true;
    public bool isMove = true;
    private int jumpCount=0;
    [SerializeField] private float speedDash = 0;

    private GroundCheck groundCheck;
    private OnGround onGround;
    void Start()
    {
        knight = GameObject.Find("Knight");
        knightData  = Resources.Load<KnightData>("GameData/Knight/KnightData");
        key = Resources.Load<Key>("GameData/Keys");
        rb = knight.GetComponent<Rigidbody2D>();
        animator = knight.GetComponent<Animator>();
        groundCheck = knight.GetComponent<GroundCheck>();
        onGround = knight.GetComponentInChildren<OnGround>();
    }

    void Update()
    {
        isMoving = isMove;
        if (isDead)
        {
            return;
        }
        Move();
    }
    private void Move()
    {
        if (groundCheck.isGrounded)
        {
            animator.SetBool("endJump", true);
            jumpCount = 0;
        }
        
        if (jumpCount > 1 || !groundCheck.isGrounded)
        {
            animator.SetBool("endJump", false);
        }
        if (Input.GetKeyDown(key.JumpKey))
        {
            Jump();
        }
       
        if(isMoving||!groundCheck.isGrounded)
        {
            if (Input.GetKey(key.MoveLeftKey))
            {
                rb.velocity = new Vector2(-1 * knightData.Speed, rb.velocity.y);
                if (crouch)
                {
                    Walk();
                }
                else
                {
                    Run();
                }
            }
            else if (Input.GetKey(key.MoveRightKey))
            {
                rb.velocity = new Vector2(knightData.Speed, rb.velocity.y);
                if (crouch)
                {
                    
                    Walk();
                }
                else
                {
                    
                    Run();
                }
            }
        }
        if(Input.GetKeyDown(key.SitKey))
        {
            if (crouch)
            {
                knightData.Speed = knightData.Speed * 2;
                Idle();
                crouch = false;
            }
            else
            {
                knightData.Speed = knightData.Speed / 2;
                Crouch();
                crouch = true;
            }
            
        }
        if (Input.GetKeyDown(key.DashKey))
        {
            Dash();
        }
        if (rb.velocity.x == 0)
        {
            if (crouch)
            {
                Crouch();
            }
            else
            {
                Idle();
            }
        }
    }

    public void Jump()
    {
        if ( jumpCount <1)
        {
            rb.velocity = new Vector2(rb.velocity.x, knightData.JumpHeight);
            animator.SetBool("endJump", true);
            animator.SetTrigger("jump");
            jumpCount++;
        }
    }
    
    public void Run()
    {
        Flip();
        AnimationKN(1);
    }

    public void Walk()
    {
        Flip();
        AnimationKN(2);
    }
    public void Dash()
    {
        if (knight.transform.localScale.x < 0)
        {
            rb.velocity = Vector2.left * speedDash;
            animator.SetTrigger("dash");
        }
        if (knight.transform.localScale.x > 0)
        {
            rb.velocity = Vector2.right * speedDash;
            animator.SetTrigger("dash");
        }
    }
    public void Flip()
    {
        if (rb.velocity.x > 0 && knight.transform.localScale.x < 0)
        {
            Vector3 theScale = knight.transform.localScale;
            theScale.x *= -1;
            knight.transform.localScale = theScale;
        }
        if (rb.velocity.x < 0 && knight.transform.localScale.x > 0)
        {
            Vector3 theScale = knight.transform.localScale;
            theScale.x *= -1;
            knight.transform.localScale = theScale;
        }
    }
    public void Crouch()
    {
        AnimationKN(3);
    }
    public void Idle()
    {
        AnimationKN(0);
    }
    public void AnimationKN(float id)
    {
        if (!onGround.IsGrounded() && groundCheck.isGrounded)
        {
            animator.SetFloat("run_walk", 3.2f);
        }
        else if (!onGround.IsGrounded() && !groundCheck.isGrounded)
        {
            animator.SetFloat("run_walk", 3.1f);
        }
        else
        {
            animator.SetTrigger("endJump2");
            animator.SetFloat("run_walk", id);
        }
        
    }
    public void IsMove(bool move)
    {
        isMove = move;
    }


}