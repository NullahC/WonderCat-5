using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diamond : MonoBehaviour
{
    public int Count = 0;
   // public AudioClip diamondCollect;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("diamond"))
        {
            //播放吃金币音乐
            // AudioSource.PlayClipAtPoint(diamondCollect, Camera.main.transform.position);
            Destroy(collision.gameObject);
            Count++;
        }

        // Update is called once per frame

    }

    // Update is called once per frame
    void Update()
    {









    }
}
