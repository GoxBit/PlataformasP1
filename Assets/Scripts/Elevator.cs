using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public bool canMove;
    [SerializeField] float speed;
    [SerializeField] int startPoint;
    [SerializeField] Transform[] points;

    int i;
    bool reverse;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startPoint].position;
        i = startPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, points[i].position) < 0.01f)
        {
            if(i == points.Length - 1)
            {
                reverse = true;
                i--;
                return;
            }
            else if(i ==0)
            {
                reverse = true;
                i++;
                return;
            }
            if(reverse) 
            {
                i--;
            }
            else
            {
                i++;
            }
        }

     
         transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        
    }
}
