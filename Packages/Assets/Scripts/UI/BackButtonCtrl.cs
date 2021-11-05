using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButtonCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn_1 = this.GetComponent<Button>();
        btn_1.onClick.AddListener(OnLevel1Click);

    }
    public void OnLevel1Click()
    {
        SceneManager.LoadScene("StratScreen");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
