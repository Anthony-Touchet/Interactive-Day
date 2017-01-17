// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CameraFollow.cs" company="Anthony">
//   CODE HARD EVERY DAY
// </copyright>
// <summary>
//   This script is used to have the camera follow a player. Will need a GameObject to 
//   follow, but will code so that if Gameobject Equals null the script will do nothing.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts
{
    using UnityEngine;

    public class CameraFollow : MonoBehaviour
    {
        public Transform Follower;
        private Vector3 offset;

        // This is the first call of the Script. Best place to set Values
        public void Awake()
        {
            offset = transform.position - Follower.position;
        }

        // LateUpdate is called once per frame once all other Update functions are called.
        public void LateUpdate()
        {
            transform.position = Follower.position + offset;
        }
    }
}
