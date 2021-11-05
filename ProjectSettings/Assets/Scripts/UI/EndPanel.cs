using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndPanel : MonoBehaviour
{
    public Button btn_Again, btn_Quit;
    void Start()
    {
        btn_Again.onClick.AddListener(OnAgainClick);
        btn_Quit.onClick.AddListener(OnQuitClick);
    }

    void OnAgainClick()
    {
        Destroy(UIMgr.inst.gameObject);
        Destroy(GameMgr.inst.gameObject);
        SceneManager.LoadScene(0);
    }

    void OnQuitClick()
    {
        Application.Quit();
    }
}
