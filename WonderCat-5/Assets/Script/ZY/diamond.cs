using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diamond : MonoBehaviour
{


    public int Count;
        private ParticleSystem DiamondPartical;



    // public AudioClip diamondCollect;
    // Start is called before the first frame update
    void Start()
    {
        DiamondPartical = GetComponent<ParticleSystem>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.CompareTag("Hero"))
        {
            //播放吃金币音乐
            // AudioSource.PlayClipAtPoint(diamondCollect, Camera.main.transform.position);
            if(!obj.GetComponent<Hero_Controller>().isDead)
                {
                Instantiate(DiamondPartical, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        //if (collision.gameObject.CompareTag("diamond"))
        //{
        //    //播放吃金币音乐
        //    // AudioSource.PlayClipAtPoint(diamondCollect, Camera.main.transform.position);
        //    Destroy(collision.gameObject);
        //    Count++;
        //}

        // Update is called once per frame

    }

    

    // Update is called once per frame
    void Update()
    {









    }
}
