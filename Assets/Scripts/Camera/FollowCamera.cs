using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Interfaces;

namespace Core.Cameras
{

    public class FollowCamera : MonoBehaviour, Initialize
    {
		[Header("Move")]
		public float minDistance = 0;
		public float followDistance = 0;
		public float moveSpeed = 1;
		public Vector3 offset = Vector3.zero;

		[Header("Other")]
		public GameObject target;


        #region private variabbles
        private Vector3 targetPos;
		private float velocity;

        #endregion

        public void Init()
		{
			targetPos = transform.position;
		}
			
		private void FixedUpdate()
		{
			if (target)
			{
				Vector3 posNoZ = transform.position;
				posNoZ.z = target.transform.position.z;

				Vector3 targetDirection = (target.transform.position - posNoZ);
				velocity = targetDirection.magnitude * 5f;
				targetPos = transform.position + (targetDirection.normalized * velocity * Time.deltaTime);

				transform.position = Vector3.Lerp(transform.position, targetPos + offset, moveSpeed);

			}
		}

       
    }
}

