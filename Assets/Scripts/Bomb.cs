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
        public float ExplotionRadius;
        public GameObject ParticlePrefab;
        private float timeAlive;
        private GameObject pe;
        private int damage = 10;
        private bool normalColor = true;
        private Material color;

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public void Awake()
        {
            LifeTime = (LifeTime <= BombTimer) ? BombTimer + 0.5f : LifeTime;
            color = gameObject.GetComponent<Renderer>().material;
        }

        public void Update()
        {
            normalColor = timeAlive % 1f < .5f;
            var newColor = normalColor == false ? Color.red : Color.white;
            color.color = newColor;

            if (timeAlive >= LifeTime)
            {
                Destroy(pe);
                Destroy(gameObject);
            }

            if (timeAlive >= BombTimer && gameObject.GetComponent<SphereCollider>() == null)
            {
                SphereCollider sc = gameObject.AddComponent<SphereCollider>();
                pe = Instantiate(ParticlePrefab, transform.position, ParticlePrefab.transform.rotation) as GameObject;
                sc.radius = ExplotionRadius;
                sc.isTrigger = true;
            }

            timeAlive += Time.deltaTime;
        }     
    }
}