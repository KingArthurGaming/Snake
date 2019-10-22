using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
    private GameObject snake;
    private float horizontal;
    private float vertical;
    private Vector2 directionOfMovement;
    public float speed;
    void Awake()
    {
        speed = 3;
        directionOfMovement = new Vector2(0, 0);
    }
    void FixedUpdate()
    {
        horizontal = Mathf.Ceil(Input.GetAxisRaw("Horizontal"));
        vertical = Mathf.Ceil(Input.GetAxisRaw("Vertical"));
        if (horizontal != 0)
        {
            directionOfMovement = new Vector2(Mathf.Round(horizontal), 0);
        }
        else if (vertical != 0)
        {
            directionOfMovement = new Vector2(0, Mathf.Round(vertical));
        }

        transform.position += new Vector3(directionOfMovement.x, directionOfMovement.y, 0) * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(" "))
        {

        }
        Debug.Log("Triggered");
    }


}
