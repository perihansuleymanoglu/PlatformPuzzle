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
    print(Vector3.right);
    transform.position += Vector3.right * Time.deltaTime * speed * direction;
  }
  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.transform.tag == "Duvar")
    {
      direction *= -1;
      transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
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
  }
}
