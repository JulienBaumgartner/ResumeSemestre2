using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public bool isOpen = false;

    private Rigidbody rb = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = !isOpen;
    }

    public void OpenDoor()
    {
        rb.freezeRotation = false;
        isOpen = true;
    }

}
