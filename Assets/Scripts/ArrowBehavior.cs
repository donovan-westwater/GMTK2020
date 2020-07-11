﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    public Transform goalPoint;
    public float speed = 1f;
    public string arrowtype;
    float scale;
    Vector2 velo;
    // Start is called before the first frame update
    void Start()
    {
        velo = new Vector2(goalPoint.position.x - transform.position.x, goalPoint.position.y- transform.position.y);
        scale = this.transform.localScale.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currPoint = new Vector2(this.transform.position.x, this.transform.position.y);
        gameObject.transform.Translate(velo.normalized * speed * Time.deltaTime);
        Physics2D.IgnoreLayerCollision(1, 1, true);
        //if (Vector2.Distance(new Vector2(goalPoint.position.x, goalPoint.position.y), currPoint) < .1f) Destroy(this.gameObject);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag.Equals("Arrow")) return;
        if(col.collider.tag.Equals("FailBox")) Debug.Log(arrowtype + " arrow missed");
        else Debug.Log(arrowtype + " arrow hit the foot");
        Destroy(this.gameObject);
    }
}
