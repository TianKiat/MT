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

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * m_BulletSpeed * Time.deltaTime);
	}

	void OnTriggerEnter() {
		HitTarget();
	}

	public override void HitTarget() {
		Debug.Log("I Hit!");
		Destroy(gameObject);
	}
}
