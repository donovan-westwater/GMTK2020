using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
    public Transform goalPoint;
    public float speed = 1f;
    public string arrowtype;
    public GameObject manager;
    Vector2 ogScale;
    float size = 1;
    Vector2 velo;
    // Start is called before the first frame update
    void Start()
    {
        velo = new Vector2(goalPoint.position.x - transform.position.x, goalPoint.position.y- transform.position.y);
        ogScale = this.transform.localScale;
        manager = GameObject.Find("Conductor");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currPoint = new Vector2(this.transform.position.x, this.transform.position.y);
        gameObject.transform.Translate(velo.normalized * speed * Time.deltaTime);
        this.transform.localScale = ogScale * size;
        size -= Time.deltaTime*(speed/10);
        Physics2D.IgnoreLayerCollision(1, 1, true);
        //if (Vector2.Distance(new Vector2(goalPoint.position.x, goalPoint.position.y), currPoint) < .1f) Destroy(this.gameObject);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag.Equals("Arrow")) return;
        if (col.collider.tag.Equals("FailBox"))
        {
            manager.GetComponent<Conductor>().points -= 100;
            Debug.Log(arrowtype + " arrow missed");
        }
        else
        {
            manager.GetComponent<Conductor>().points += 100;
            col.gameObject.GetComponent<FootBehavior>().wasHit = true;
            Debug.Log(arrowtype + " arrow hit the foot");
        }
        Destroy(this.gameObject);
    }
}
