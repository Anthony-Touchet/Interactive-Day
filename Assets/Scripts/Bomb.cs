// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bomb.cs" company="Anthony">
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

    public class Bomb : MonoBehaviour, IDamager
    {
        public float LifeTime;
        public float BombTimer = 2f;
        public GameObject ParticlePrefab;
        private float timeAlive;
        private GameObject pe;

        public int Damage { get; set; }

        public void Awake()
        {
            LifeTime = (LifeTime <= BombTimer) ? BombTimer + 0.5f : LifeTime;
        }

        public void Update()
        {
            if (timeAlive >= LifeTime)
            {
                Destroy(pe);
                Destroy(gameObject);
            }

            if (timeAlive >= BombTimer && gameObject.GetComponent<SphereCollider>() == null)
            {
                SphereCollider sc = gameObject.AddComponent<SphereCollider>();
                pe = Instantiate(ParticlePrefab, transform.position, ParticlePrefab.transform.rotation) as GameObject;
                sc.radius = 3.5f;
            }

            timeAlive += Time.deltaTime;
        }     
    }
}