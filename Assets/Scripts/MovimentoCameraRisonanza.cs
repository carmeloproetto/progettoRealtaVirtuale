using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovimentoCameraRisonanza : MonoBehaviour
{
     public Camera mainCamera;    
    public float rotationSpeed = 8f;    
    void Update()    
    {        
        RotateCamera();
    }    
 
    
    private void RotateCamera()    
    {        
        
        if (Input.GetMouseButton(1))            
            {    
                Debug.Log("Script Attivo");                      
                float xRotation = rotationSpeed * Input.GetAxis("Mouse X");
                float yRotation = rotationSpeed * Input.GetAxis("Mouse Y");
                float xAngle = transform.eulerAngles.x%360f;
                float newAngle = ((xAngle + yRotation));
                
                if (Math.Cos(newAngle/360)<=0f)                    
                yRotation = 0;                               
        
                var angle = 
                    new Vector3(transform.eulerAngles.x + yRotation, transform.eulerAngles.y + xRotation, 0);                
                    transform.SetPositionAndRotation(transform.position,Quaternion.Euler(angle.x,angle.y,0));            
        }    
    } 
}
