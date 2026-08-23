using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformtriggerchecker : MonoBehaviour
{
    private Rigidbody rbParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Invoke("FallDownPlatform", 2f);
            //FallDownPlatform();
        }
    }

    private void FallDownPlatform()
    {

        rbParent = GetComponentInParent<Rigidbody>();
        rbParent.useGravity = true;
        rbParent.isKinematic = false;

        Destroy(transform.parent.gameObject, 2f);
    }
}
