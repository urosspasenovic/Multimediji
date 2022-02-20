using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{

	[SerializeField]
	GameObject projectile;
	[SerializeField]
	float power = 10.0f;
	[SerializeField]
	AudioClip shootSFX;

	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			GameObject newProjectile = Instantiate(projectile, transform.position + transform.forward, transform.rotation) as GameObject;
			newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);	
			newProjectile.GetComponent<AudioSource>().PlayOneShot(shootSFX, 0.4f);		
		}
	}
}