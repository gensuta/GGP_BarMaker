using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform camTransform;

    [SerializeField]
    private float movementSpeed;
    [SerializeField] 
    private float lerpTime;
    [SerializeField]
    private float rotationAmount;
    [SerializeField]
    private Vector3 zoomAmount;


    private Vector3 newPosition;
    private Quaternion newRotation;
    private Vector3 newZoom;

    private Vector3 dragStartPos, dragCurrentPos;
    private Vector3 rotateStartPos, rotateCurrentPos;

    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = camTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        HandleKeyInput();
        HandleMouseInput();

        //lerping!!
        transform.position = Vector3.Lerp(transform.position, newPosition, lerpTime * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, lerpTime * Time.deltaTime);
        camTransform.localPosition = Vector3.Lerp(camTransform.localPosition, newZoom, lerpTime * Time.deltaTime);
    }

    void HandleMouseInput()
    {
        // we're creating a plane to simulate clicking on a point of the world and dragging from that position we click on
        //TODO: Clean this up so we don't have this if statement twice
        if(Input.GetMouseButtonDown(2))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry; // entry point of raycast

            if(plane.Raycast(ray, out entry))
            {
                dragStartPos = ray.GetPoint(entry);
            }
        }

        //if we're still holding the mouse down
        if (Input.GetMouseButton(2))
        {

            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry; // entry point of raycast

            if (plane.Raycast(ray, out entry))
            {
                dragCurrentPos = ray.GetPoint(entry);

                //Setting new position by getting the difference of the current pos/startdragpos and the current drag pos
                newPosition = transform.position + dragStartPos - dragCurrentPos;
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            rotateStartPos = Input.mousePosition;

        }
        if (Input.GetMouseButton(1))
        {
            rotateCurrentPos = Input.mousePosition;
            Vector3 difference = rotateStartPos - rotateCurrentPos;

            rotateStartPos = rotateCurrentPos;

            newRotation *= Quaternion.Euler(Vector3.up * (-difference.x / 5f));
        }


        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            newZoom += zoomAmount;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            newZoom -= zoomAmount;
        }
    }

    void HandleKeyInput()
    {
        if(Input.GetKey(KeyCode.W))
        {
            newPosition += transform.forward * movementSpeed;

        }

        if (Input.GetKey(KeyCode.S))
        {
            newPosition += transform.forward * -movementSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            newPosition += transform.right * -movementSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            newPosition += transform.right * movementSpeed;
        }

        //rotation
        if(Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }
        if (Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }
    }
}
