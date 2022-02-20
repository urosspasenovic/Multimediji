using UnityEngine;
using System.Collections;

public class TargetMover : MonoBehaviour {

	[SerializeField]
	float spinSpeed = 180f;
	[SerializeField]
	float moveSpeed = 0.1f;
	[SerializeField]
	bool spin = false;
	[SerializeField]
	bool horizontal = false;
	[SerializeField]
	bool vertical = false;

	void Update()
	{
		if (spin)
			gameObject.transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
		if (horizontal)
			gameObject.transform.Translate(Vector3.right * Mathf.Cos(Time.timeSinceLevelLoad) * moveSpeed);
		if (vertical)
			gameObject.transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * moveSpeed);
	}
}
