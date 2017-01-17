// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnemyAI.cs" company="Anthony">
//   CODE HARD EVERY DAY
// </copyright>
// <summary>
//   This Script is used to move the Enemy Unit. Requires that a maximum speed be put in.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts
{
    using Player;
    using UnityEngine;

    public class EnemyAI : MonoBehaviour
    {
        public Transform TargetTransform;
        public float MaxSpeed;
        private Vector3 desiredVelocity = new Vector3();
        private Vector3 steering;
        private Rigidbody rb;
        private Vector3 velocity = new Vector3();

        // This is the first call of the Script. Best place to set Values
        public void Awake()
        {
            if (FindObjectOfType<PlayerMovement>() != null)
            {
                TargetTransform = FindObjectOfType<PlayerMovement>().gameObject.transform;
                rb = GetComponent<Rigidbody>();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // Update is called once per frame. 
        public void FixedUpdate()
        {
            desiredVelocity = (TargetTransform.position - transform.position).normalized;
            steering = (desiredVelocity - rb.velocity).normalized;
            velocity += steering / 1f;

            // Limit Velocity
            if (velocity.magnitude > MaxSpeed)
            {
                velocity = velocity.normalized * MaxSpeed;
            }

            rb.position += velocity * Time.deltaTime;
        }
    }
}