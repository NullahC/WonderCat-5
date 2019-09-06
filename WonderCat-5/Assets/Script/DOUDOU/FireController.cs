using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject fire;

    // Start is called before the first frame update
    void Start()
    {
        fire.transform.position = transform.position;//火焰位置与粒子位置重合

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rig = transform.GetComponent<Rigidbody2D>();
        Instantiate(fire, transform.position, Quaternion.identity);
        fire.SetActive(true);
        rig.constraints = RigidbodyConstraints2D.None;

    }
}
