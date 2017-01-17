// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Unit.cs" company="Anthony">
//   CODE HARD EVERY DAY
// </copyright>
// <summary>
//   This Script is used to track the Unit's Health and any collision detection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts
{
    using UnityEngine;

    public class Unit : MonoBehaviour
    {
        public int Health;

        // This is the first call of the Script. Best place to set Values
        public void Awake()
        {
            Health = (Health <= 0) ? 10 : Health;
        }

        // Update is called once per frame. Will be used to destroy the GameObject
        public void Update()
        {
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }

        // This is where we will say what happens if the GameObject is Hit. GameObject
        // will need a Collider
        public void OnCollisionEnter(Collision other)
        {
            // This is where we will say what happens when the Bullet collides
            // with this GameObject.
            if (other.gameObject.GetComponent<Bullet>() != null)
            {
                Health -= other.gameObject.GetComponent<Bullet>().Damage;
                Destroy(other.gameObject);
            }
        }
    }
}