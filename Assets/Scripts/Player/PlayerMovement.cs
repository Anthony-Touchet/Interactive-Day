﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerMovement.cs" company="Anthony">
//   CODE HARD EVERY DAY
// </copyright>
// <summary>
//   This script is in charge of moving the player. This script will require the GameObject it is attached
//   to have a RigidBody Componet
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Player
{
    using UnityEngine;

    public class PlayerMovement : MonoBehaviour
    {
        public float Speed;
        private new Rigidbody rigidbody;
        
        // This is the first call of the Script. Best place to set Values
        public void Awake()
        {
            rigidbody = gameObject.GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        public void FixedUpdate()
        {
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");

            Vector3 newPos = transform.position + (transform.forward * Speed * vertical) 
                + (transform.right * Speed * horizontal);
            rigidbody.MovePosition(newPos);
        }
    }
}