using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zuanshi : MonoBehaviour
{
    public GameObject diamond;
    // Start is called before the first frame update
    void Start()
    {
        diamond.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(diamond, transform.position, Quaternion.identity);
        diamond.SetActive(true);
    }
}
