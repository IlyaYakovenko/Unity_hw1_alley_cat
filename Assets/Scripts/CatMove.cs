using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CatMove : MonoBehaviour
{
    public float jumpForce = 19.0f;

    public bool inAir;

    public float speed = 10f;
    private Rigidbody2D rig_bod;

    private bool faceRight = true;

    void Start()
    {
        rig_bod = GetComponent <Rigidbody2D> ();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rig_bod.MovePosition(rig_bod.position + Vector2.right * moveX * speed * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Space) && !inAir)
            {
                inAir = true;
                rig_bod.AddForce(Vector2.up * jumpForce);
            }


        if (moveX > 0 && !faceRight)
            flip();
        else if (moveX < 0 && faceRight)
            flip();
    }

    void flip () {
        faceRight = !faceRight;
        transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Surface"))
            inAir = false;

        if (collision.gameObject.name.Equals ("dog")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
