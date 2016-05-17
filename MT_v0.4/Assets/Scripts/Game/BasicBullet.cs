// ===============================
// AUTHOR: Ng Tian Kiat
// CREATE DATE:
// Description: BasicBullet is 
// ===============================
/* Change History:

*/
using UnityEngine;
using System.Collections;

public class BasicBullet : BaseProjectile {

	void OnTriggerEnter() {
		HitTarget();
	}

	public override void HitTarget() {
		// Debug.Log("I Hit!");
		Destroy(gameObject);
	}
}
