// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerShoot.cs" company="Anthony">
//   CODE HARD EVERY DAY
// </copyright>
// <summary>
//   This script will handel the player shooting
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Player
{
    using UnityEngine;

    public class PlayerShoot : MonoBehaviour
    {
        public GameObject BulletPrefab;
        public Transform BulletSpawnPoint;
        public int BulletDamage;
        public float BulletForce;
        public float FireRate;
        private float timeAlive;

        public void Awake()
        {
            BulletDamage = (BulletDamage < 0) ? 2 : BulletDamage;
            BulletForce = (BulletForce < 0) ? 100 : BulletForce;
            timeAlive = FireRate;
        }

        public void Update()
        {
            // This Statement Stops this process
            if (!(Input.GetAxis("Fire1") >= 1.0f && timeAlive > FireRate))
            {
                return;
            }

            GameObject bullet;
            bullet = Instantiate(BulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation) as GameObject;
            if (bullet == null)
            {
                return;
            }

            bullet.GetComponent<Bullet>().Damage = BulletDamage;
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * BulletForce);

            timeAlive = 0f; // Reset Time to next bullet fire.
        }

        public void LateUpdate()
        {
            if (timeAlive <= FireRate)
            {
                timeAlive += Time.deltaTime;
            }
        }
    }
}