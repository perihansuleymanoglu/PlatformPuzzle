using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour
{
    [SerializeField]
    private float speed = 2;
    [SerializeField]
    private int direction = 1;

    private void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * speed * direction;
        if (transform.position.y < -10)
        {
            // gameOver.SetActive(true);
            speed = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Duvar")
        {
            direction *= -1;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}
