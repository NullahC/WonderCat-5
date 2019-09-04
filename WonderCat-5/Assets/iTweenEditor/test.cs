using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Hashtable args = new Hashtable();
        args.Add("speed", 5.0f);
        args.Add("path", iTweenPath.GetPath("Pat"));
        iTween.MoveTo(gameObject, args);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
