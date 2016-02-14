using UnityEngine;
using System.Collections;

public class TreeController : MonoBehaviour {

	private Animator anim;

	private float shakeTime = 0f;
	private Vector3 lastMove = Vector3.zero;

	int hpHash = Animator.StringToHash("hp");
	int attackHash = Animator.StringToHash("TreeAttack");
	int hitHash = Animator.StringToHash("TreeHitCorrectly");

	public void Start() {
		anim = GetComponent<Animator>();
	}

	void Update () {
		if(shakeTime > Time.timeSinceLevelLoad) {
			if(lastMove == Vector3.zero) {
				lastMove = randomVector() * .1f;
				transform.position += lastMove;
			} else {
				transform.position -= lastMove;
				lastMove = Vector3.zero;
			}
		}
	}

	public void hit(int newHP, bool correctly) {
		anim.SetInteger(hpHash, newHP);
		if(correctly) {
			shakeTime = Time.timeSinceLevelLoad + .25f;
			anim.SetTrigger(hitHash);
		}
	}

	public void attack() {
		anim.SetTrigger(attackHash);
	}

	//hp should be taken care of inside this class in the future
	public void setHP(int hp) {
		anim.SetInteger(hpHash, hp);
	}

	private Vector3 randomVector() {
		return new Vector3(Random.value, Random.value);
	}
}