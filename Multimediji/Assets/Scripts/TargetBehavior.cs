using UnityEngine;
using System.Collections;

public class TargetBehavior : MonoBehaviour
{

	public int scoreAmount = 0;
	public float timeAmount = 0.0f;

	[SerializeField]
	GameObject explosionPrefab;


	void OnCollisionEnter(Collision newCollision)
	{
		if (GameManager.gm.gameIsOver)
			return;

		if (newCollision.gameObject.tag == "Projectile")
		{
			Instantiate(explosionPrefab, transform.position, transform.rotation);
			GameManager.gm.targetHit(scoreAmount, timeAmount);
			Destroy(newCollision.gameObject);
			Destroy(gameObject);
		}
	}
}