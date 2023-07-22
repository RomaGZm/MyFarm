using UnityEngine;

namespace Core.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        /// <summary>
        /// Enable walk animation
        /// </summary>
        /// <param name="dir"> direction movement</param>
        public void Walk(float dir)
        {
            animator.SetFloat("MoveDir", dir);
        }
    }
}

