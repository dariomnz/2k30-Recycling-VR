using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShotHead : MonoBehaviour
{
    private GameObject lanzable = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lanzable != null)
        {
            transform.position = lanzable.transform.position;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Garbage"))
            lanzable = other.gameObject;
    }


}
