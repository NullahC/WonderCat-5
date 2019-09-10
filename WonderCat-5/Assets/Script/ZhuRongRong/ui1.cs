using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ui1 : MonoBehaviour
{
    public Button chenzhaoxin;
    public Button zhangying;
    public Button doudou;
    public Button zhurongrong;
    public Button back;
    // Start is called before the first frame update

    public void zhurongrong_Click()
    {
        //场景跳转
        SceneManager.LoadScene("ZhuRongRong");
    }

    public void chenzhaoxin_Click()
    {
        //场景跳转
        SceneManager.LoadScene("ChenZhaoXinLevel");
    }

    public void zhangying_Click()
    {
        //场景跳转
        SceneManager.LoadScene("ZhangYing");
    }

    public void doudou_Click()
    {
        //场景跳转
        SceneManager.LoadScene("Doudou");
    }

    public void back_Click()
    {
        //场景跳转
        SceneManager.LoadScene("menu");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
