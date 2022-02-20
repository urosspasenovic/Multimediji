using UnityEngine;
using System.Collections;

public class TargetExit : MonoBehaviour
{
	[SerializeField]
	float exitAfterSeconds = 10f;
	[SerializeField]
	float exitAnimationSeconds = 1f;
	[SerializeField]
	bool isAsteroidBonusLvl2 = false;

	private bool startDestroy = false;
	private float targetTime;

	void Start()
	{
		targetTime = Time.time + exitAfterSeconds;
	}

	void Update()
	{
		if (Time.time >= targetTime)
		{
			if (!startDestroy)
			{
				startDestroy = true;
				if(!isAsteroidBonusLvl2)
					this.GetComponent<Animator>().SetTrigger("Exit");
				Invoke("KillTarget", exitAnimationSeconds);
			}
		}
	}

	void KillTarget()
	{
		Destroy(gameObject);
	}
}