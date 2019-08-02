using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public static DoorManager instance;

    public Door door;
    void Awake()
    {
        instance = this;
    }
    public void AddDoor(Door door)
    {
        this.door = door;
    }
}
