using UnityEngine;

public class PacmanCtrl : MonoBehaviour
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
            transform.position += moveDir * speed * Time.fixedDeltaTime;
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
            dir = Vector3Int.right;
        else if (_x < 0f)
            dir = Vector3Int.left;
        else if (_y < 0f)
            dir = Vector3Int.down;
        else if (_y > 0f)
            dir = Vector3Int.up;

        return dir;
    }


}
