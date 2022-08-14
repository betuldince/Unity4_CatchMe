using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 50;
    
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        float horizantalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizantalInput * speed * Time.deltaTime);
    }
}
