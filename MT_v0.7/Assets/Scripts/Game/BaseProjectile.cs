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
	public Transform m_tr;
	public float m_BulletSpeed;
	public float m_lifetime=10;

	void Start() {
		Invoke("kill", m_lifetime);
	}

	// Method: What will happen when the projectile hits something and how it deals damage
	public virtual void HitTarget() {
		//Override this to give behaviour to what happens when it hits something and how it deals damage
	}
	
	public void ShootProjectile(Vector3 _rotationOffset) {
		transform.Rotate(_rotationOffset);
		m_RB.AddForce(transform.forward * m_BulletSpeed, ForceMode.Impulse);
	}

	private void kill() {
		Destroy(gameObject);
	}
}
