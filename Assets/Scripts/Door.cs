using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Door previous, next;
    public bool selected;
    private void OnMouseDown()
    {
        if (selected)
            Clean();
        if (DoorManager.instance.door == null)
        {
            this.spriteRenderer.color = Color.green;
            DoorManager.instance.door = this;
            //Giris
        }
        else
        {
            if (DoorManager.instance.door != this)
            {
                previous = DoorManager.instance.door;
                previous.next = this;
                this.spriteRenderer.color = Color.red;
            }
            DoorManager.instance.door = null;
            //Çıkış
        }
        selected = true;
    }

    private void Clean()
    {
        if (previous != null)
        {
            print("previous");
            previous.spriteRenderer.color = Color.white;
            previous.Clean();
        }
        else if (next != null)
        {
            next.previous = null;
            print("next");
            next.spriteRenderer.color = Color.white;
            next.Clean();
            next = null;
        }
        print("son");
        selected = false;
    }
}
