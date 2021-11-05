using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ExitButton : MonoBehaviour
{
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnExitClick);
    }

    public void OnExitClick()
    {
        SceneManager.LoadScene("StartScreen");
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
