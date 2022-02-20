using UnityEngine;
using System.Collections;

public class DestroyProjectile : MonoBehaviour {

	[SerializeField]
	float timeOut = 0.5f;
	private float elapsedSeconds = 0;
	private void Update()
	{
		elapsedSeconds += Time.deltaTime;
		if (elapsedSeconds >= timeOut)
		{
			Destroy(gameObject);
		}
	}
}
