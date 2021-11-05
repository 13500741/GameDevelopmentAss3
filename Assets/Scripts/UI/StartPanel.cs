using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        if(SceneManager.GetActiveScene().name == "Assess3")
        {
            UIMgr.inst.ClosePanel<StartPanel>();
            UIMgr.inst.OpenPanel<TimePanel>();
        }
       
    }
    void OnQuitClick()
    {
        UIMgr.inst.ClosePanel<StartPanel>();
        UIMgr.inst.ClosePanel<GamePanel>();
        SceneManager.LoadScene(0);
        //Application.Quit();
    }
}
