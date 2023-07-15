using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Cameras
{

    public class FollowCamera : MonoBehaviour
    {
		[Header("Move")]
		public float minDistance = 0;
		public float followDistance = 0;
		public float moveSpeed = 1;
		public Vector3 offset = Vector3.zero;

		[Header("Other")]
		public GameObject target;

		private Vector3 targetPos;
		private float velocity;
		void Start()
		{
			targetPos = transform.position;
		}

		
		void FixedUpdate()
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

