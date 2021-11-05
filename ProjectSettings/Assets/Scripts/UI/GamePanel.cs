using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    public Text label_Score, label_Level;
    public List<GameObject> lifeIcons;
    private int life;
    void Start()
    {
    }

    void Update()
    {
        if (GameMgr.inst.gameState == GameState.Play)
        {
            label_Score.text = GameMgr.inst.score.ToString();
            label_Level.text = GameMgr.inst.level.ToString();
            if (life != GameMgr.inst.pacManLife)
            {
                life = GameMgr.inst.pacManLife;
                for (int i = 0; i < lifeIcons.Count; i++)
                {
                    if (i > life)
                    {
                        lifeIcons[i].SetActive(false);
                    }
                }
            }
        }
    }
}
