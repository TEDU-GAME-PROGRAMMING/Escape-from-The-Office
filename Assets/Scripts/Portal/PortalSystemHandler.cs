using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSystemHandler : MonoBehaviour
{
    public GameObject otherPortal;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = otherPortal.transform.position + otherPortal.transform.forward;
        other.gameObject.transform.rotation = otherPortal.transform.rotation;
    }
}
