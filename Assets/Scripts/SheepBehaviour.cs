using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBehaviour : MonoBehaviour
{
    public float WaitTime = 5;
    public float Speed = 0.2f;
    public float Radius = 0.5f;
    Vector3 pos;
    bool isMoving = false;

    float timeToMove;
    // Start is called before the first frame update
    void Start()
    {
        timeToMove = Random.Range(1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {

        if (timeToMove < 0 && !isMoving)
        {
            pos = (Random.insideUnitCircle * Radius);
            pos += transform.position;
            Move();
            //timeToMove = WaitTime;
            isMoving = true;
        }

        if (isMoving)
        {
            Move();
            timeToMove += Time.deltaTime;

            if (timeToMove > WaitTime)
            {
                isMoving = false;
                WaitTime = Random.Range(1f, 5f);
            }
        }
        else
        {
            timeToMove -= Time.deltaTime;
        }
    }

    void Move()
    {
        //Debug.Log(transform.parent);
        float step = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, pos, step);
    }
}
