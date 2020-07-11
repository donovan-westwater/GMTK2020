using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootBehavior : MonoBehaviour
{
    Vector2 ogSize;
    float scale;
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        ogSize = this.transform.localScale;
        scale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = scale * ogSize;
        scale -= Time.deltaTime * (1 / delay);
        if(scale < 0.1)
        {
            this.transform.localScale = ogSize;
            scale = 1;
            this.gameObject.SetActive(false);
        }
    }
}
