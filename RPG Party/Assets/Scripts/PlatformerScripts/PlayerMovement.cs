using UnityEngine;
using UnityEngine.SceneManagement;

 
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;
    private Transform _originalParent;
    public float timeLeft;
    public GameManagerS GameManager;
    
    private void Start()
    {
        GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManagerS>();
    }
    
    private void Awake()
    {
        //Grabs references for rigidbody and animator from game object.
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        _originalParent = transform.parent;
    }
 
    private void Update()
    {
        //Time

        timeLeft -= Time.deltaTime;
        
        if(timeLeft <= 0f)
        {
            Lost();
        }
        
        horizontalInput = Input.GetAxis("Horizontal"); 
        //Flip player when facing left/right.
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(2, 2, 2);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-2, 2, 2);
        
        //walljump
        if(wallJumpCooldown > 0.2f)
        {
                
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
            
            if (onWall() && !isGrounded())
            {
            body.gravityScale = 0;
            body.velocity = Vector2.zero;
            }
            else
                body.gravityScale = 5;
                
            if (Input.GetKey(KeyCode.Space))
                Jump();
        }
        else
            wallJumpCooldown += Time.deltaTime;
    }
 
    private void Jump()
    {
        if(isGrounded())
        {
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        //anim.SetTrigger("jump");
        }
        else if(onWall()  && !isGrounded())
            {
            if(horizontalInput == 0)
            {
            body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10,  0);
            transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3,  6);
            
            wallJumpCooldown = 0;
            
            }
    }
    
    private bool isGrounded()
    {
    RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
    return raycastHit.collider != null;
    }
    
    private bool onWall()
    {
    RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
    return raycastHit.collider != null;
    }
    
    public void SetParent(Transform newParent)
    {
        _originalParent = transform.parent;
        transform.parent = newParent;
    }
    
    public void ResetParent()
    {
        transform.parent = _originalParent;
    }
    
    public void Lost()
    {
        Debug.Log("Lost!!!!!!");
        
        //update player health
        GameManager.loseHealth(1);
        
        SceneManager.LoadScene("Overworld");
        //pausegame
        Time.timeScale = 0;
    }
    
    public void Won()
    {
        Debug.Log("Won!!!!!");
        
        //update player health
        GameManager.addScore(100);
        
        SceneManager.LoadScene("Overworld");
        //pausegame
        Time.timeScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger!");
    }
    
}
