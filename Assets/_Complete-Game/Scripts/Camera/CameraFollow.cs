﻿using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;            // The position that that camera will be following.
        public float smoothing = 5f;        // The speed with which the camera will be following. ;giving a smoothing effect 


        Vector3 offset;                     // The initial offset from the target.


        void Start ()
        {
            // Calculate the initial offset.
            offset = transform.position - target.position;  //camera position - player position
        }


        void FixedUpdate ()
        {
            // Create a postion the camera is aiming for based on the offset from the target.
            Vector3 targetCamPos = target.position + offset; //so camera moves in such a way that target and camera stays at same distance always

            // Smoothly interpolate between the camera's current position and it's target position.
            transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
            //note : transform will be of that object to which this script is attached
        }
    }
}