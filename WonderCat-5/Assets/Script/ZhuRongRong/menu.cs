using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class menu : MonoBehaviour
{
    public Button bn_back;
    public Button play;
    public Animator pa_settings;
    // Start is called before the first frame update
    public GameObject SetttingsPanel = null;
    public void Play_Click()

    {
        //场景跳转
        SceneManager.LoadScene("ui1");
    }
    public void Settings_Click()
    {
        pa_settings.enabled = true;
    }
    public void Close_Settings()
    {
        SetttingsPanel.SetActive(false);
    }
    public void ToQuit()
    {
        Application.Quit();
    }
    public void back()
    {
        pa_settings.SetBool("SlideIn", false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
