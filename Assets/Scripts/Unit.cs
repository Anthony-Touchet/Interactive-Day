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

    public class Unit : MonoBehaviour, IDamagable, IDamager
    {
        [SerializeField] private int health;
        [SerializeField] private int damage;

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public void TakeDamage(int dam)
        {
            Health -= dam;
        }

        // This is the first call of the Script. Best place to set Values
        public void Awake()
        {
            Health = (Health <= 0) ? 10 : Health;
            Damage = (Damage <= 0) ? 1 : Damage;
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
        public void OnTriggerEnter(Collider other)
        {
            // This is where we will say what happens when the Bullet collides
            // with this GameObject.
            var otherDamager = other.gameObject.GetComponent<IDamager>();
            if (otherDamager == null)
            {
                return;
            }

            TakeDamage(otherDamager.Damage);
        }
    }
}