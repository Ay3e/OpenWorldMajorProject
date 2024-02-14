using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPickUp : MonoBehaviour
{
    private bool isPlayerInTrigger;
    // Update is called once per frame
    void Update()
    {
        if (isPlayerInTrigger)
        {
            Debug.Log("In Trigger");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isPlayerInTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerInTrigger = false;
    }
}
