using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DogMove : MonoBehaviour
{

    public float speed = 5f;
    private float dirX;

    private bool faceRight = true;
    private bool movingRight = true;

    void Update()
    {

        if (transform.position.x > 12.5) {
            movingRight = false;
        } else if (transform.position.x < -12.5) {
            movingRight = true;
        }

        if (movingRight) {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        } else {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }

        if (movingRight && !faceRight)
            flip();
        else if (!movingRight && faceRight)
            flip();
    }

    void flip () {
        faceRight = !faceRight;
        transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

}
