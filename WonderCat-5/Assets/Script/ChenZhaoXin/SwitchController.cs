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
    public GameObject fireP;
    public AudioClip Swiching=null;
    public AudioClip ZhamenOpened = null;

    private SpriteRenderer SwitchRender = null;
    private bool SwitchJudge = false;
    private float RaiseH = 0;
    private bool ZhaMenJ = false;
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
                    ZhaMenJ = true;
                    RaiseH = RaiseH + 0.008f;
                    MovedBySwitch[i].transform.position = new Vector2(MovedBySwitch[i].transform.position.x, MovedBySwitch[i].transform.position.y + RaiseH);
                }
                else if (MovedBySwitch[i].tag == "Fire" && SwitchJudge)
                {
                    fireP.transform.position = MovedBySwitch[i]. transform.position;
                    Rigidbody2D rig = MovedBySwitch[i].transform.GetComponent<Rigidbody2D>();
                    Instantiate(fireP, MovedBySwitch[i].transform.position, Quaternion.identity);
                    fireP.SetActive(true);
                    Destroy(MovedBySwitch[i]);
                }
                else if (MovedBySwitch[i].tag == "Bats" && SwitchJudge)
                {
                    MovedBySwitch[i].transform.position = Vector3.MoveTowards(MovedBySwitch[i].transform.position,
                        GameObject.FindGameObjectWithTag("Hero").transform.position,
                        0.1f);
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
        AudioSource.PlayClipAtPoint(Swiching, Camera.main.transform.position);
    }
    private void OnTriggerExit(Collider other)
    {
        if (ZhaMenJ)
            AudioSource.PlayClipAtPoint(ZhamenOpened, Camera.main.transform.position);
    }
}
