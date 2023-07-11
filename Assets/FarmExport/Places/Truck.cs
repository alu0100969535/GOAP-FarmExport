using System;
using UnityEngine;

namespace ShipFactory {
	public class Truck : MonoBehaviour {

		[SerializeField] private Vector3 movementVector;
		[SerializeField] private Vector3 stopPoint;
		[SerializeField] private float maxDistanceFromOrigin;
		[SerializeField] private float speed;
		[SerializeField] private float stopTimeDuration;

		private float timeSpentStopped;
		private bool shouldMove;
		private bool hasStopped;

		private void Start() {
			Reset();
		}

		public bool WillDepartSoon() {
			return stopTimeDuration - timeSpentStopped < 10f;
		}

		private void Update() {

			if (!shouldMove) {
				timeSpentStopped += Time.deltaTime;
				if (timeSpentStopped >= stopTimeDuration) {
					shouldMove = true;
					GWorld.Instance.GetWorld().ModifyState("truckWaiting", -1);
				}
				else {
					return;
				}
			}

			Move();

			if (transform.position.magnitude >= maxDistanceFromOrigin) {
				Reset();
				return;
			}

			if (hasStopped) {
				return;
			}
			

			CheckStopPoint();
		}

		private void Move() {
			transform.position += movementVector * (speed * Time.deltaTime);
		}

		private void CheckStopPoint() {
			if ((transform.position - stopPoint).magnitude < Vector3.one.magnitude) {
				shouldMove = false;
				GWorld.Instance.GetWorld().ModifyState("truckWaiting", 1);
			}
		}

		private void Reset() {
			shouldMove = true;
			hasStopped = false;
			timeSpentStopped = 0f;
			transform.position = movementVector * -maxDistanceFromOrigin;
		}
	}
}