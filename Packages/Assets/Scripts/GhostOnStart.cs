using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostOnStart : MonoBehaviour
{
    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        dir = Vector3Int.up;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * Time.fixedDeltaTime / 2;
        if (transform.position.y > 15)
        {
            dir = Vector3Int.down;
        }
        if (transform.position.y < 5)
        {
            dir = Vector3Int.up;
        }
        GetComponent<Animator>().SetBool("Move", true);
        GetComponent<Animator>().SetFloat("move_x", dir.x);
        GetComponent<Animator>().SetFloat("move_y", dir.y);
    }
}
