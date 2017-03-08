using System;
using UnityEngine;


namespace UnityStandardAssets.Utility
{
    public class FollowTarget : MonoBehaviour
    {
        public Transform target;
		public float smoothTime = 0.3F;
		private Vector3 velocity = Vector3.zero;

        public Vector3 offset = new Vector3(0f, 7.5f, 0f);


        private void LateUpdate(){
			Vector3 targetPosition = target.position + offset;
			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
