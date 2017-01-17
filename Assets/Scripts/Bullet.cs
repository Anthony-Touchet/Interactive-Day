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

    public class Bullet : MonoBehaviour
    {
        public int Damage;
        public float LifeTime;
        private float timeAlive = 0f;

        public void Update()
        {
            if (timeAlive >= LifeTime)
            {
                Destroy(gameObject);
            }

            timeAlive += Time.deltaTime;
        }
    }
}