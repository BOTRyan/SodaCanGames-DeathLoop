using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private bool startPanning = false;

    // Start is called before the first frame update
    void Start()
    {
        //target = FindObjectOfType<PlayerMovement>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, target.position) > 2f)
        {
            startPanning = true;
        }

        if (startPanning)
        {
            transform.position = AnimMath.Slide(transform.position, target.position, 0.01f);
            if (Vector3.Distance(transform.position, target.position) < 0.01f)
            {
                startPanning = false;
                transform.position = target.position;
            }
        }

    }
}
