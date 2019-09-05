using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat_move : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed =4.0f;
    public GameObject edge;
    public bool Ddge;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Ddge = edge.GetComponent<edge>().catCome;
        if (Ddge)
        {
            move();
        }
      
    }
    private void move()
    {
        rig.transform.Translate(Vector2.left*speed*Time.deltaTime,Space.Self);
    }
}
