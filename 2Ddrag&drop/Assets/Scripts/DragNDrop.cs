using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    [SerializeField] private SpringJoint2D DragJoint;

    [SerializeField] private float DragDetectRadius;
    [SerializeField] private LayerMask DragableObjectsLayers;

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            DragJoint.connectedBody = Physics2D.OverlapCircle(cam.ScreenToWorldPoint(Input.mousePosition), DragDetectRadius, DragableObjectsLayers)?.attachedRigidbody;
        }
        else if (Input.GetButton("Fire1"))
        {
            DragJoint.transform.position = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            DragJoint.connectedBody = null;
        }

        DragJoint.gameObject.SetActive(DragJoint.connectedBody);
    }
}
