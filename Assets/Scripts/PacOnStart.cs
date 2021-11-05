using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacOnStart : MonoBehaviour
{
    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        dir = Vector3Int.right;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * Time.fixedDeltaTime / 2f;
        if(transform.position.x > -10)
        {
            dir = Vector3Int.left;
        }
        if (transform.position.x < -35 )
        {
            dir = Vector3Int.right;
        }
        GetComponent<Animator>().SetBool("Move", true);
        GetComponent<Animator>().SetFloat("move_x", dir.x);
        GetComponent<Animator>().SetFloat("move_y", dir.y);
    }
}
