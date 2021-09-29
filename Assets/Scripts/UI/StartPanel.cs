using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    public Button btn_Start, btn_Quit;
    void Start()
    {
        btn_Start.onClick.AddListener(OnStartClick);
        btn_Quit.onClick.AddListener(OnQuitClick);
    }

    void OnStartClick()
    {
        UIMgr.inst.ClosePanel<StartPanel>();
        UIMgr.inst.OpenPanel<TimePanel>();
    }
    void OnQuitClick()
    {
        Application.Quit();
    }
}
