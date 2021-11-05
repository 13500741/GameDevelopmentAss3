using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{

    private float timecount = 0f;
    private bool cango = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!cango)
        {
            timecount += Time.fixedDeltaTime;
        }
        if (!cango && timecount >= 100)
        {
            cango = true;
            timecount = 0f;
            Vector3 pos = transform.position;
            pos.x = -12.5f;
            pos.y = 4f;
            transform.position = pos;
        }
        if (cango)
        {
            transform.position += (Vector3)Vector3Int.right * Time.fixedDeltaTime;
        }

        if(transform.position.x > 14)
        {
            cango = false;
            timecount = 0f;
            Vector3 pos = transform.position;
            pos.x = -45.5f;
            pos.y = 4f;
            transform.position = pos;
        }
    }
}
