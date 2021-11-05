using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private AudioClip eatPellet;
    [SerializeField]
    private AudioClip hitWall;
    [SerializeField]
    private AudioClip notEatPellet;
    [SerializeField]
    private AudioClip death;

    private Animator anim;
    private Vector3 moveDir;
    private bool canMove;
    private bool isDead;
    private char lastInput;
    private char currentInput;
    private float goflag = 0f;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        moveDir = Vector3Int.right;
        canMove = true;
        source.clip = notEatPellet;

    }

    
    private void Update()
    {
        if (GameMgr.inst.gameState != GameState.Play) return;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (h != 0 || v != 0)
        {
            moveDir = GetMoveDir(h, v);
        }

        anim.SetBool("Move", canMove);
        anim.SetFloat("move_x", moveDir.x);
        anim.SetFloat("move_y", moveDir.y);
    }
    private void FixedUpdate()
    {
        if (GameMgr.inst.gameState != GameState.Play) return;

        if (canMove)
        {
            goflag += speed * Time.fixedDeltaTime;
            if (goflag >= 1 && LevelGenerator.levelMap[(14 - (int)(transform.position.y + moveDir.y)), (int)(transform.position.x + moveDir.x + 13.5)] == 5) 
            {
                //print(LevelGenerator.levelMap[(int)(transform.position.x + moveDir.x + 13.5), (14 - (int)(transform.position.y + moveDir.y))]);
                transform.position += moveDir;
                goflag = 0f;
            }
            
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
    }

    private Vector3 GetMoveDir(float _x, float _y)
    {
        Vector3Int dir = Vector3Int.zero;
        if (_x > 0f)
        {
            dir = Vector3Int.right;
            lastInput = 'd';
        }
        else if (_x < 0f)
        {
            dir = Vector3Int.left;
            lastInput = 'a';
        }
        else if (_y < 0f)
        {
            dir = Vector3Int.down;
            lastInput = 's';
        }
        else if (_y > 0f)
        {
            dir = Vector3Int.up;
            lastInput = 'w';
        }

        return dir;
    }


}
