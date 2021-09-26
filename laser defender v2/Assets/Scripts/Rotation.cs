using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float SpinSpeed = 10f;
    
  
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, SpinSpeed * Time.deltaTime);
    }
}
