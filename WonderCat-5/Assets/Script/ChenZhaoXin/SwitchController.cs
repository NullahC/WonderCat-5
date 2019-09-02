using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public Sprite OpenSwitch = null;
    public Sprite CloseSwitch = null;
    public GameObject MovedBySwitch = null;

    private SpriteRenderer SwitchRender = null;
    private bool SwitchJudge = false;
    private float RaiseH = 0;
    // Start is called before the first frame update
    void Start()
    {
        SwitchRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchRender.sprite = SwitchJudge ? OpenSwitch : CloseSwitch;
    }
    private void FixedUpdate()
    {
        if(MovedBySwitch.tag=="ZhaMen"&&SwitchJudge)
        {
            RaiseH=RaiseH+0.02f;
            MovedBySwitch.transform.position = new Vector2(MovedBySwitch.transform.position.x, MovedBySwitch.transform.position.y+ RaiseH);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SwitchJudge = true;
    }
}
