using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class MyTile : MonoBehaviour
{
    public TileInfo info { get; set; }
    private SpriteRenderer sp { get { return GetComponent<SpriteRenderer>(); } }
   
    void Start()
    {
    }

    public void InitTile(TileInfo _info)
    {
        info = _info;
        sp.sprite = _info.sprite;
    }
   
}
