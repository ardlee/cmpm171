using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    public Transform start, end;
    public int Speed;
    Vector2 targetPos;

    void Start()
    {
        Debug.Log("Start position: " + start.position);
        Debug.Log("End position: " + end.position);
        targetPos = end.position;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, start.position) < 0.1f)
        {
            targetPos = end.position;
        }

        if (Vector2.Distance(transform.position, end.position) < 0.1f)
        {
            targetPos = start.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.SetParent(null); 
    }
}
