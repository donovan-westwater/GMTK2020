using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootBehavior : MonoBehaviour
{
    Vector2 ogSize;
    public string type;
    public float scale;
    public float delay;
    public Animator dancer;
    // Start is called before the first frame update
    void Start()
    {
        ogSize = this.transform.localScale;
        scale = 1;
        this.GetComponent<SpriteRenderer>().color = Color.black;
        this.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = scale * ogSize;
        if (type.Equals("left"))
        {
            dancer.SetInteger("Side", 0);
        }
        else if (type.Equals("up"))
        {
            dancer.SetInteger("Side", 1);
        }
        else if (type.Equals("right"))
        {
            dancer.SetInteger("Side", 2);
        }
        if (scale <= 0.40 && scale >= 0.1)
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            
        }
        else if (scale < 0.1)
        {
            dancer.SetInteger("Side", -1);
            this.transform.localScale = ogSize;
            this.GetComponent<SpriteRenderer>().color = Color.black;
            scale = 1;
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.SetActive(false);
        }
        scale -= Time.deltaTime * (1 / delay);
    }
}
