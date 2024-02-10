using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public GameObject EventTrigger, Thing, Run, Gone;

    public void OnTriggerStay(Collider other)
    {
        //You should not have taken the skull. Once it reaches the end of the room (not hallway), the thing will wake up.
        if (other.gameObject.tag == "Skull")
        {
            Debug.Log("Uh Oh");
            Run.SetActive(true);
            Thing.SetActive(true);
            EventTrigger.SetActive(true);
        }
    }
}
