using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAndDrop : MonoBehaviour
{
    [Header("Pickup")]
    [SerializeField] public Transform playerCameraTransform;
    [SerializeField] public Transform objectGrabPointTransform;
    [SerializeField] public LayerMask pickUpLayerMask;

    public ObjectGrabbable objectGrabbable;
    public float pickupDistance = 2f;

    [Header("Throw")]
    public float throwForce;
    public float throwUpwardForce;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectGrabbable == null)
            {
                //Grab  
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance, pickUpLayerMask))
                {
                    //Debug.Log(raycastHit.transform); Thank god it's finally working
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform);
                        //Debug.Log(objectGrabbable); IT'S FINALLY WORKING WE'RE SO BACK
                    }
                }
            }
            else
            {
                //Throw
                Throw();
                objectGrabbable = null;

                //Drop
                //objectGrabbable.Drop();
                //objectGrabbable = null;
            }
        }
    }

    //Throw
    private void Throw()
    {
        objectGrabbable.Drop();
        //For Throw ^^

        Rigidbody projectileRb = objectGrabbable.GetComponent<Rigidbody>();

        Vector3 forceToAdd = objectGrabPointTransform.transform.forward * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);
    }
}
