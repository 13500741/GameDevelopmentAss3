using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePanel : MonoBehaviour
{
    public Text label_Time;
    private int timer;
    void Start()
    {
        timer = GameMgr.inst.waitTime;
        label_Time.text = timer.ToString();
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1);
        timer -= 1;
        label_Time.text = timer.ToString();
        if (timer > 0)
        {
            StartCoroutine(CountDown());
        }
        else
        {
            yield return new WaitForSeconds(0.05f);
            UIMgr.inst.ClosePanel<TimePanel>();
            GameMgr.inst.gameState = GameState.Play;
            SoundMgr.inst.BGMPlay(AudioName.ghostNormal);
        }
    }
}
