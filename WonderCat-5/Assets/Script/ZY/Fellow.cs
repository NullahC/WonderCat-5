using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fellow : MonoBehaviour
{
    //public LayerMask lay;
    //public RaycastHit hit;
    //public GameObject Bo;
    //public List<GameObject> cubeList;
    // void Start()
    //{

    //}
    // void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        if(Physics.Raycast(ray,out hit, 100, lay))
    //        {
    //            GameObject cube = Instantiate(Bo, hit.point, Quaternion.identity) as GameObject;
    //        }
    //    }
    //}

    //    // Start is called before the first frame update
    //    //需显示的物体
    public GameObject rightMenu;
    //    //摄像机
    public Camera uicamera;
    //    //开始隐藏物体
    void Start()
    {
        rightMenu.SetActive(false);
    }

    //    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(1))

        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //获得鼠标位置
            float x = Input.mousePosition.x;
            float y = Input.mousePosition.y;
            float z = Input.mousePosition.z;
            //给需要在鼠标点击位置出现的物体赋值
            rightMenu.transform.position = new Vector3(x, y, z);
            //显示物体
            rightMenu.SetActive(true);

        }
        //    }
        // void OnMouseDown()
        //{
        //    if(Input.GetMouseButton(1))
        //    {
        //        //获得鼠标位置
        //        float x = Input.mousePosition.x;
        //        float y = Input.mousePosition.y;
        //        float z = Input.mousePosition.z;
        //        //给需要在鼠标点击位置出现的物体赋值
        //        rightMenu.transform.position = new Vector3(x, y, z);
        //        //显示物体
        //        rightMenu.SetActive(true);
        //    }
        //}
    }
}
