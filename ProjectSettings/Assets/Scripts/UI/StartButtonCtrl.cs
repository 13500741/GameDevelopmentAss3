using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartButtonCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnLevel1Click);
    }

    public void OnLevel1Click()
    {
        SceneManager.LoadScene("Assess3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
