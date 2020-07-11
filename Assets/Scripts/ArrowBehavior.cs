using System.Collections;
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
        if (Vector2.Distance(new Vector2(goalPoint.position.x, goalPoint.position.y), currPoint) < 2f) Destroy(this.gameObject);

    }
}
