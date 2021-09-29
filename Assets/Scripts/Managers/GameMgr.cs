using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static GameMgr inst;
    public bool dontDestroy = true;

    public GameState gameState = GameState.Stop;
    public int waitTime = 3;
    public int pacManLife=3;
    public int level = 1;
    public int score { get; set; }

    private void Awake()
    {
        if (dontDestroy)
        {
            if (inst == null)
                DontDestroyOnLoad(gameObject);
            else
            {
                Destroy(gameObject);
                return;
            }
        }
        inst = this;
    }

    void Start()
    {
        UIMgr.inst.OpenPanel<GamePanel>();
        UIMgr.inst.OpenPanel<StartPanel>();
        SoundMgr.inst.BGMPlay(AudioName.gameIntro);

    }


}
