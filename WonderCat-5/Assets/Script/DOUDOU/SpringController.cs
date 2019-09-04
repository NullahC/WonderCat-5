using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringController : MonoBehaviour
{
    public iTween.EaseType type;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Spring")
        {
        Hashtable args = new Hashtable();
        args.Add("speed", 5.0f);
        args.Add("path", iTweenPath.GetPath("SpringPath"));
        args.Add("easeType", type);
        iTween.MoveTo(gameObject, args);
        }
        
    }
}
