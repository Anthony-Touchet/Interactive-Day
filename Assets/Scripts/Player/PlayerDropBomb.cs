// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerDropBomb.cs" company="Anthony">
//   CODE HARD EVERY DAY
// </copyright>
// <summary>
//   This script will handel the player shooting
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts.Player
{
    using UnityEngine;

    public class PlayerDropBomb : MonoBehaviour
    {
        public GameObject BombPrefab;
        public float DropRate = 2f;
        private GameObject bomb;
        private float timeSinceDrop = 0;

        public void Awake()
        {
            
        }

        public void Update()
        {
            if (timeSinceDrop < DropRate)
            {
                timeSinceDrop += Time.deltaTime;
            }
            else if (bomb == null && Input.GetKeyUp(KeyCode.Space))
            {
                var playerPosition = transform.position;
                var playerVelocity = GetComponent<Rigidbody>().velocity;
                var dropPosition = playerPosition - playerVelocity.normalized;
                bomb = Instantiate(BombPrefab, dropPosition, new Quaternion()) as GameObject;
                timeSinceDrop = 0;
            }
        }
    }
}