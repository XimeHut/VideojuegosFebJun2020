using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    //GameObject del FPS
    public GameObject fps;

    //Variables para el movimiento de la vista 
    public float mouseSensitive = 10f;
    private float mouseX;
    private float mouseY;
    private float rotationX;

    //Variables para el movimiento

    float speed;
    public float walk = 10f; //la velocidad con la que camina normal el fps
    public float run = 30f; //la velocidad con la que corre el fps

    public float jumpHeight = 2f;
    
    private float moves2s;
    private float movefb;
    private float moveud;
    private float gravity = -9.81f;
    private bool isGrounded;

    private Vector3 movimiento;
    private CharacterController controller;
  

    //Variables para un ground más estable

    public GameObject magicSphere;
    public LayerMask groundMask;
    private float radious = 0.2f;
    



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = fps.GetComponent<CharacterController>();
    }

    void Update()
    {

        FPSlook();
        FPSMove();
    }

    public void FPSMove()
    {
        speed = 10f;


        isGrounded = Physics.CheckSphere(magicSphere.transform.position, radious, groundMask);
        
        
        if (isGrounded)
            moveud = 0;
        else
            moveud += gravity * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
            moveud = Mathf.Sqrt(jumpHeight * -2f * gravity);

        if (Input.GetButton("Run") && Input.GetAxis("Vertical") != 0) //En este caso se aprieta la letra de "R" para modificar la velocidad.
                                                                      //Esta se configura en Edit --> Project Settings -->  Input Manager --> 
                                                                      //Agregas una con el nombre "Run" y eliges la letra o boton con el que quieres activar esta funcion . (En este caso es "r")
        {
            speed = run;
        }
        else
        {
            speed = walk;
        }


        movefb = Input.GetAxis("Vertical");
        moves2s = Input.GetAxis("Horizontal");

        movimiento = ((fps.transform.right * moves2s) +
                     (fps.transform.up * moveud) +
                     (fps.transform.forward * movefb));
        movimiento = movimiento * speed * Time.deltaTime;
        controller.Move(movimiento);

        




    }

    public void FPSlook()
    {
        mouseX = Input.GetAxis("Mouse X")*mouseSensitive*Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y")*mouseSensitive*Time.deltaTime;
        
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90, 90);

        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        fps.transform.Rotate(Vector3.up, mouseX);
    }


}
