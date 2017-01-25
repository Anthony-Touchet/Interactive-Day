// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpawnEnemies.cs" company="Anthony">
//   CODE HARD EVERY DAY
// </copyright>
// <summary>
//   Defines the SpawnEnemies type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts
{
    using System.Collections.Generic;
    using System.Linq;
    using Player;
    using UnityEngine;

    /// <summary>
    /// This script will control the number of enemies on the field.
    /// </summary>
    public class SpawnEnemies : MonoBehaviour
    {
        /// <summary>
        /// The prefabs list.
        /// </summary>
        public List<GameObject> PrefabsList = new List<GameObject>();

        /// <summary>
        /// The spawn points list.
        /// </summary>
        public List<Transform> SpawnPointsList = new List<Transform>();

        /// <summary>
        /// The max number of enemies.
        /// </summary>
        public int MaxNumberEnemies;

        /// <summary>
        /// The spawn buffer so enemies don't spawn too close to each other.
        /// </summary>
        public float SpawnBuffer = 5f;

        /// <summary>
        /// The target.
        /// </summary>
        public Transform Target;

        /// <summary>
        /// The max speed that each unit can go.
        /// </summary>
        public float MaxSpeed = 5f;

        /// <summary>
        /// The enemy list.
        /// </summary>
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private List<Unit> enemyList = new List<Unit>();

        /// <summary>
        /// Use this for initialization
        /// </summary>
        public void Awake()
        {
            Target = FindObjectOfType<PlayerMovement>().transform;
            var enemies = FindObjectsOfType<Unit>();
            if (enemies == null)
            {
                return;
            }

            foreach (var e in enemies)
            {
                enemyList.Add(e);
            }
        }

        /// <summary>
        /// Update is called once per frame
        /// </summary>
        public void Update()
        {
            // Keeping control of how many enemies there are
            if (enemyList.Count >= MaxNumberEnemies)
            {
                return;
            }

            var randomPrefab = PrefabsList[Random.Range(0, PrefabsList.Count - 1)];

            var choice = SpawnPointsList[Random.Range(0, SpawnPointsList.Count - 1)];
            if (UnitInDistance(choice.position, SpawnBuffer))
            {
                return;
            }

            var randomLocation = choice;
            var newEnemy = Instantiate(randomPrefab, randomLocation.position, new Quaternion())
                               as GameObject;
            if (newEnemy != null)
            {
                enemyList.Add(newEnemy.GetComponent<Unit>());
            }         
        }

        /// <summary>
        /// The fixed update where all the math behind movement will be.
        /// </summary>
        public void FixedUpdate()
        {
            enemyList.RemoveAll(e => e == null);
            var enemyAIs = enemyList.Select(e => e.GetComponent<EnemyAI>()).ToList();
            foreach (var bb in enemyAIs)
            {
                var r2 = Dispersion(bb, enemyAIs);
                var tendTowards = TendTowardsPlace(bb);
                bb.Velocity += (r2 + tendTowards) / bb.Mass;
                LimitVelocity(bb);
            }
        }

        /// <summary>
        /// The dispersion.
        /// </summary>
        /// <param name="b">
        /// The b.
        /// </param>
        /// <param name="list">
        /// The list.
        /// </param>
        /// <returns>
        /// The <see cref="Vector3"/>.
        /// </returns>
        private Vector3 Dispersion(EnemyAI b, List<EnemyAI> list)
        {
            // Rule 2: distancing each other appart
            var avoid = list.Where(bj => (bj.transform.position - b.transform.position).magnitude <= 2 && bj != b).Aggregate(Vector3.zero, (current, bj) => current - (bj.transform.position - b.transform.position));

            return avoid.normalized;
        }

        private Vector3 TendTowardsPlace(EnemyAI bb)
        {
            return (Target.position - bb.transform.position).normalized;
        }

        private void LimitVelocity(EnemyAI bb)
        {
            if (bb.Velocity.magnitude > MaxSpeed)
            {
                // Normalizing                       times speed you want
                bb.Velocity = (bb.Velocity / bb.Velocity.magnitude) * MaxSpeed;
            }
        }

        /// <summary>
        /// Check to see if there are any units nearby
        /// </summary>
        /// <param name="startPoint">
        /// The start point.
        /// </param>
        /// <param name="dist">
        /// The distance between the start point and the edge of the range.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool UnitInDistance(Vector3 startPoint, float dist)
        {
            enemyList.RemoveAll(e => e == null);
            return enemyList.Any(unit => (unit.transform.position - startPoint).magnitude <= dist);
        }
    }
}
