using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    public Transform goalPoint;
    public float speed = 1f;
    public string type;
    float scale;
    Vector2 velo;
    // Start is called before the first frame update
    void Start()
    {
        velo = new Vector2(transform.position.x - goalPoint.position.x, transform.position.y - goalPoint.position.y);
        scale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currPoint = new Vector2(this.transform.position.x, this.transform.position.y);
        gameObject.transform.Translate(velo.normalized * speed * Time.deltaTime);
        if (Vector2.Distance(new Vector2(goalPoint.position.x, goalPoint.position.y), currPoint) < 2f) velo = new Vector2(0, 0);
    }
}
