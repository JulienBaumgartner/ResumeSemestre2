using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 10;

    [HideInInspector] public int keys = 0;
    [HideInInspector] public bool controlPlayer = true;

    private Rigidbody rb = null;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controlPlayer)
        {
            float x = Input.GetAxis("Horizontal") * playerSpeed;
            float z = Input.GetAxis("Vertical") * playerSpeed;

            rb.velocity = new Vector3(x, rb.velocity.y, z);

            if (rb.velocity.magnitude > 0.1f)
            {
                transform.LookAt(transform.position + new Vector3(rb.velocity.x, 0, rb.velocity.z));
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            keys++;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Door")
        {
            DoorController door = collision.collider.GetComponent<DoorController>();
            if (!door.isOpen && keys > 0)
            {
                door.OpenDoor();
                keys--;
            }
        }
        else if(collision.collider.tag == "Car")
        {
            gameController.UseCar();
        }
    }
}
