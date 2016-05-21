// ===============================
// AUTHOR: Ng Tian Kiat
// CREATE DATE:
// Description: BaseProjectile is 
// ===============================
/* Change History:

*/
using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
public class BaseProjectile : MonoBehaviour {
	public float m_Damage;
	public Rigidbody m_RB;
	public float m_BulletSpeed;
	public float m_lifetime=10;

	void Start() {
		Invoke("kill", m_lifetime);
	}

	// Method: What will happen when the projectile hits something and how it deals damage
	public virtual void HitTarget() {
		//Override this to give behaviour to what happens when it hits something and how it deals damage
	}

	private void kill() {
		Destroy(gameObject);
	}
}
