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

    /// <summary>
    /// The enemy ai controller. Used for moving the GameObject it is on
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class EnemyAI : MonoBehaviour
    {
        /// <summary>
        /// The velocity of the Enemy.
        /// </summary>
        [HideInInspector]
        public Vector3 Velocity;

        /// <summary>
        /// The mass of the object.
        /// </summary>
        public float Mass = 1f;

        /// <summary>
        /// The Rigid Body of the Object
        /// </summary>
        private Rigidbody rb;

        /// <summary>
        /// Setting the Rigid Body.
        /// </summary>
        public void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        /// <summary>
        /// The late update that actually moves to Object.
        /// </summary>
        public void LateUpdate()
        {
            // Were we will sum up all of the vectors.
            transform.forward = Velocity.normalized;
            rb.position += transform.forward * Velocity.magnitude * Time.deltaTime;
        }
    }
}