// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerAttributes.cs" company="Anthony">
//   CODE HARD EVERY DAY
// </copyright>
// <summary>
//   Defines the PlayerAttributes type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Player
{
    using UnityEngine;

    public class PlayerAttributes : MonoBehaviour, IDamagable
    {
        [SerializeField] private int health;

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        // Use this for initialization
        public void Awake()
        {
            Health = Health <= 0 ? 10 : Health;
        }

        // Update is called once per frame
        public void Update()
        {
            if (Health > 0)
            {
                return;
            }

            var playerCamera = transform.FindChild(GetComponentInChildren<Camera>().name);
            playerCamera.parent = null;
            Destroy(gameObject);
        }

        public void OnCollisionEnter(Collision other)
        {
            // if the guy I collide with is a damager
            var otherDamager = other.gameObject.GetComponent<IDamager>();
            if (otherDamager == null)
            {
                return;
            }

            // Take Damage
            TakeDamage(otherDamager.Damage);
        }

        public void OnTriggerEnter(Collider other)
        {
            // if the guy I collide with is a damager
            var otherDamager = other.gameObject.GetComponent<IDamager>();
            if (otherDamager == null)
            {
                return;
            }

            // Take Damage
            TakeDamage(otherDamager.Damage);
        }

        public void TakeDamage(int dam)
        {
            Health -= dam;
        }
    }
}