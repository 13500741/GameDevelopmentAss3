using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    public static UIMgr inst;
    public Canvas uiroot;
    public bool dontDestroy;
    private Dictionary<string, GameObject> panelDic = new Dictionary<string, GameObject>();
    public GameObject panel_1;
    public GameObject panel_2;
    public GameObject panel_3;
    public GameObject panel_4;

    private void Awake()
    {
        if (dontDestroy)
        {
            if (UIMgr.inst == null)
            {
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        OnInit();
    }

    private void Start()
    {
    }
    private void OnInit()
    {
        inst = this;
        if (!uiroot)
        {
            uiroot = GameObject.FindObjectsOfType<Canvas>().FirstOrDefault(x => x.name == "Canvas");
        }
    }
    public GameObject OpenPanel(string panelName)
    {
        if (!panelDic.ContainsKey(panelName))
        {
            if (panelName == "StartPanel")
            {
                //GameObject obj = Resources.Load<GameObject>("UI/" + panelName);
                GameObject panel = Instantiate(panel_1, uiroot.transform);
                panelDic.Add(panelName, panel);
                return panel;

            }
            if (panelName == "EndPanel")
            {
                GameObject panel = Instantiate(panel_2, uiroot.transform);
                panelDic.Add(panelName, panel);
                return panel;
            }
            if (panelName == "GamePanel")
            {
                GameObject panel = Instantiate(panel_3, uiroot.transform);
                panelDic.Add(panelName, panel);
                return panel;
            }
            if (panelName == "TimePanel")
            {
                GameObject panel = Instantiate(panel_4, uiroot.transform);
                panelDic.Add(panelName, panel);
                return panel;
            }
            return null;
        }
        else { 
            return panelDic[panelName];
        }
    }

    public T OpenPanel<T>() where T : Component
    {
        string panelName = typeof(T).ToString();
        return OpenPanel(panelName).GetComponent<T>();
    }

    public GameObject GetPanel(string panelName)
    {
        if (panelDic.ContainsKey(panelName))
        {
            return panelDic[panelName];
        }
        else
            return null;
    }
    public T GetPanel<T>() where T : Component
    {
        string panelName = typeof(T).ToString();
        if (panelDic.ContainsKey(panelName))
        {
            GameObject panel = panelDic[panelName];
            return panel.GetComponent<T>();
        }
        else
            return null;
    }

    public void ClosePanel(string _panelName = "")
    {
        string panelName = string.IsNullOrEmpty(_panelName) ? panelDic.LastOrDefault().Key : _panelName;
        GameObject panel = panelDic[panelName];
        panelDic.Remove(panelName);
        Destroy(panel);
    }

    public void ClosePanel<T>() where T : Component
    {
        string panelName = typeof(T).ToString();
        if (panelDic.ContainsKey(panelName))
        {
            GameObject panel = panelDic[panelName];
            Destroy(panel);
            panelDic.Remove(panelName);
        }
    }
    public void CloseAllPanel()
    {
        int number = panelDic.Count;
        for (int i = 0; i < number; i++)
        {
            ClosePanel();
        }
    }
}
