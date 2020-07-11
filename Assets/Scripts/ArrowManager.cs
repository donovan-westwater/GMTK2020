using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject leftPrefab;
    public GameObject upPrefab;
    public GameObject rightPrefab;
    public float speed = 1.5f;
    void Start()
    {
        
    }


    void SpawnArrow(string type)
    {
        if (type.Equals("left"))
        {
            GameObject arrow = GameObject.Instantiate(leftPrefab);
            arrow.transform.position = new Vector2(gameObject.transform.GetChild(0).transform.position.x, gameObject.transform.GetChild(0).transform.position.y);
            arrow.GetComponent<ArrowBehavior>().arrowtype = "left";
            arrow.GetComponent<ArrowBehavior>().goalPoint = gameObject.transform.GetChild(3).GetChild(0);
            arrow.GetComponent<ArrowBehavior>().speed = this.speed;
        }
        else if (type.Equals("up"))
        {
            GameObject arrow = GameObject.Instantiate(upPrefab);
            arrow.transform.position = new Vector2(gameObject.transform.GetChild(1).transform.position.x, gameObject.transform.GetChild(1).transform.position.y);
            arrow.GetComponent<ArrowBehavior>().arrowtype = "up";
            arrow.GetComponent<ArrowBehavior>().goalPoint = gameObject.transform.GetChild(3).GetChild(1);
            arrow.GetComponent<ArrowBehavior>().speed = this.speed;
        }
        else if (type.Equals("right"))
        {
            GameObject arrow = GameObject.Instantiate(rightPrefab);
            arrow.transform.position = new Vector2(gameObject.transform.GetChild(2).transform.position.x, gameObject.transform.GetChild(2).transform.position.y);
            arrow.GetComponent<ArrowBehavior>().arrowtype = "right";
            arrow.GetComponent<ArrowBehavior>().goalPoint = gameObject.transform.GetChild(3).GetChild(2);
            arrow.GetComponent<ArrowBehavior>().speed = this.speed;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) SpawnArrow("left");
        if (Input.GetKeyDown(KeyCode.S)) SpawnArrow("up");
        if (Input.GetKeyDown(KeyCode.D)) SpawnArrow("right");
    }

}
