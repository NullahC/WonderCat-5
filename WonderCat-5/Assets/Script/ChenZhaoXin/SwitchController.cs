using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    [HideInInspector]
    public Sprite OpenSwitch = null;
    [HideInInspector]
    public Sprite CloseSwitch = null;
    public GameObject []MovedBySwitch = null;

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
        for (int i = 0; i < MovedBySwitch.Length; i++)
        {
            try
            {
                if (MovedBySwitch[i].tag == "ZhaMen" && SwitchJudge)
                {
                    RaiseH = RaiseH + 0.008f;
                    MovedBySwitch[i].transform.position = new Vector2(MovedBySwitch[i].transform.position.x, MovedBySwitch[i].transform.position.y + RaiseH);
                }
                else if (MovedBySwitch[i].tag == "Fire" && SwitchJudge)
                {
                    Destroy(MovedBySwitch[i]);
                }
            }
            catch(System.Exception)
            {

            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SwitchJudge = true;
    }
}
