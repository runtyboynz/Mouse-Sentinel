using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBody : MonoBehaviour {

	private Animator anim;

	public bool bodyDying = false;

	private Vector3 recordBodyLoc;

	ParticleSystem smokeParticle;

	//private float shuffle;
	//private float running;

	void Start () 
	{
		anim = GetComponent<Animator> ();

		recordBodyLoc = this.transform.position;

		smokeParticle = GetComponentInChildren<ParticleSystem> ();

		int n = Random.Range (0, 2);//Chooses a random number between 0,1, or 2. Then plays that animation.

		if (n == 0) 
		{
			anim.Play ("Zomb1Shuffle", -1, 0f);
		} 
		if (n == 1) 
		{
			anim.Play ("Zomb1Running", -1, 0f);
		}
	} 

	void Update () {

		if (bodyDying) {

			transform.position = recordBodyLoc;
		}
	}

	// Update is called once per frame
	void OnMouseDown () {

		bodyDying = true;
		recordBodyLoc = this.transform.position;

		var emission = smokeParticle.emission;
		emission.enabled = true;
		DeathAnimationsExplode ();		
		// Slow down head //
		this.gameObject.transform.parent.GetComponent<ZombieController>().changeSpeed(1);

	}


	public void DeathAnimationsExplode() {

		if (bodyDying) {

			int n = Random.Range (0, 3);//Chooses a random number between 0,1, or 2. Then plays that animation.

			if (n == 0) {
				anim.Play ("Zomb1BodyShot", -1, 0f);
			} 
			if (n == 1) {
				anim.Play ("Zomb1BodyShot2", -1, 0f);
			} 
			if (n == 2) {
				anim.Play ("Zomb1BodyShot3", -1, 0f);
			} 
		}
	}

	public void DeathAnimationsFallDown() {

		int n = Random.Range (0, 2);//Chooses a random number between 0,1, or 2. Then plays that animation.

		if (n == 0) {
			anim.Play ("Zomb1Death", -1, 0f);
		}
		if (n == 1) {
			anim.Play ("Zomb1Death2", -1, 0f);
		}
	}

	public void DestroyZombie() {

		Destroy(this.gameObject);

	}

	//anim.SetFloat ("inputH", inputH);
	//anim.SetFloat ("inputV", inputV);
}
