using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [Header("Input Actions")]
    [SerializeField] InputAction movement;
    [SerializeField] InputAction firing;
    [Header("Game Obejct")]
    [SerializeField] GameObject[] lasers;

    [SerializeField] float movementSpeed = 35f;
    [SerializeField] float Xrange = 10f;
    [SerializeField] float Yrange = 7f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2f;

    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = -20f;
    float xThrow;
    float yThrow;
    float currXthrow;
    float currYthrow;
    void Start()
    {
        
    }

    void OnEnable()
    {
        movement.Enable();
    }

    void OnDisable()
    {
        movement.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }
    void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + currYthrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor ;
        float roll = currXthrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
     void ProcessTranslation()
    {
         xThrow = movement.ReadValue<Vector2>().x;
         yThrow = movement.ReadValue<Vector2>().y;

         currXthrow = Mathf.MoveTowards(currXthrow, xThrow, 3f * Time.deltaTime);
        
        currYthrow = Mathf.MoveTowards(currYthrow, yThrow, 3f * Time.deltaTime);
        
        //float horizontalValue = Input.GetAxis("Horizontal");
        // float verticalValue = Input.GetAxis("Vertical");
        float xOffset = currXthrow * movementSpeed * Time.deltaTime;
        float yOffset = currYthrow * movementSpeed * Time.deltaTime;


        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        float clampedXpos = Mathf.Clamp(rawXPos, -Xrange, Xrange);
        float clampedYpos = Mathf.Clamp(rawYPos, -Yrange, Yrange);

        transform.localPosition = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z);
    }
    void ProcessFiring()
    {

       
         if (Input.GetButton("Fire1"))
         {
            ActivateLasers(true);

         }
         else
          {
            ActivateLasers(false);
        }
    }
    void ActivateLasers(bool isActive)
    {
        foreach(GameObject laser in lasers)
        {
            var emisionModule = laser.GetComponent<ParticleSystem>().emission;
            emisionModule.enabled = isActive;
        }
    }
    
    
}
