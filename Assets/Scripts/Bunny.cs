using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour
{
    [SerializeField]
    private float speed = 2;
    [SerializeField]
    private int direction = 1;
    [SerializeField]
    private Sprite cheer;
    [SerializeField]
    private GameObject finish, gameOver;
    private void Awake()
    {
    }

    private void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * speed * direction;

        if(transform.position.y < -5)
        {
            gameOver.SetActive(true);
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
        if (other.transform.tag == "Engel")
        {          
            gameOver.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Door door = other.transform.GetComponent<Door>();
        if (door != null)
        {
            if (door.next != null)
            {
                transform.position = door.next.transform.position;
                door.next.Clean();
            }
        }
        else if (other.transform.tag == "Carrot")
        {
            finish.SetActive(true);
            this.GetComponent<Animator>().enabled = false;
            this.GetComponent<SpriteRenderer>().sprite = cheer;
            speed = 0;
        }
       
    }
}
