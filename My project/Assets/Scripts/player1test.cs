using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1test : MonoBehaviour
{
    public GameObject o;
    public Transform o2;
    PlayerController P1;

    public float mouseSensitivity = 100f;
    float verticalRotation = 0f;
    //float horizontalRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        P1 = new PlayerController(o);
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        P1.Move();
        

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        

        
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        
        
        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        o2.Rotate(Vector3.up * mouseX);

        
    }
}
