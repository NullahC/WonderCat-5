﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class zhu : MonoBehaviour
{
    public Button home;
    public Button new1;
    public Button back;
    // Start is called before the first frame update

    public void home_Click()

    {
        //场景跳转
        SceneManager.LoadScene("menu");
        Cat.Count = 0;
    }
    public void new_Click()

    {
        //场景跳转
        SceneManager.LoadScene("ZhuRongRong");
        Cat.Count = 0;
    }

    public void back_Click()

    {
        //场景跳转
        SceneManager.LoadScene("ui1");
        Cat.Count = 0;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

