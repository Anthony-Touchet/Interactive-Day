// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bullet.cs" company="Anthony">
//   CODE HARD EVERY DAY
// </copyright>
// <summary>
//   This Script will keep track of Bullet related items such as damage and when
//   the Bullet should be destroyed.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts
{
    using UnityEngine;

    public class Bullet : MonoBehaviour, IDamager
    {
        public float LifeTime;
        private float timeAlive = 0f;

        public int Damage { get; set; }

        public void Update()
        {
            if (timeAlive >= LifeTime)
            {
                Destroy(gameObject);
            }

            timeAlive += Time.deltaTime;
        }

        public void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }
    }
}