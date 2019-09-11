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
    public AudioClip click = null;
    public void Play_Click()

    {
        //场景跳转
        AudioSource.PlayClipAtPoint(click, Camera.main.transform.position);
        SceneManager.LoadScene("ui1");

    }
    public void Settings_Click()
    {
        AudioSource.PlayClipAtPoint(click, Camera.main.transform.position);
        pa_settings.enabled = true;
    }
    public void Close_Settings()
    {
        AudioSource.PlayClipAtPoint(click, Camera.main.transform.position);
        SetttingsPanel.SetActive(false);
    }
    public void ToQuit()
    {
        AudioSource.PlayClipAtPoint(click, Camera.main.transform.position);
        Application.Quit();
    }
    public void back()
    {
        AudioSource.PlayClipAtPoint(click, Camera.main.transform.position);
        pa_settings.SetBool("SlideIn", false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
