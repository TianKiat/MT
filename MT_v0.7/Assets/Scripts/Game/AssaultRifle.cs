// ===============================
// AUTHOR: Ng Tian Kiat
// CREATE DATE:
// Description: AssaultRifle is the base starting gun
// ===============================
/* Change History:

*/
using UnityEngine;
using System.Collections;

public class AssaultRifle : BaseWeapon{
	
<<<<<<< HEAD
	// void OnTriggerEnter(Collider other) {
	// 	if(other.gameObject.CompareTag("Enemy")) 
	// 	{
	// 		//Add enemy to list
	// 	}
	// }
	// void OnTriggerExit(Collider other) {
	// 	if(other.gameObject.CompareTag("Enemy")) 
	// 	{
	// 		//delete enemy from list
	// 	}
	// }
	
	public override IEnumerator ShootHandheld() {
		if (!m_IsMounted)
		{
			m_IsWaiting = true;
			// Debug.Log("Shoot from hand");
			GameObject bullet = Instantiate(m_ProjectileToShootHandheld, m_MuzzleHandheld.position, m_MuzzleHandheld.rotation) as GameObject;
			bullet.GetComponent<BaseProjectile>().ShootProjectile(GetSpreadOffsetHandheld());
			// bullet.m_tr.Rotate(GetSpreadOffsetHandheld());
			// bullet.m_RB.AddForce(transform.forward * bullet.m_BulletSpeed);
			m_IsWaiting = true;
			yield return m_FireRateHandheld;
			m_IsWaiting = false;
		}
	}
	public override IEnumerator ShootMounted() {
		while (m_IsMounted && m_CanFire && m_AutoFire)
		{
				m_IsWaiting = true;
				// Debug.Log("Shoot from mount");
				GameObject bullet = Instantiate(m_ProjectileToShootMounted, m_MuzzleMounted.position, m_MuzzleMounted.rotation) as GameObject;
				bullet.GetComponent<BaseProjectile>().ShootProjectile(GetSpreadOffsetMounted());
				// bullet.m_tr.Rotate(GetSpreadOffsetMounted());
				// bullet.m_RB.AddForce(transform.forward * bullet.m_BulletSpeed);
				m_IsWaiting = true;
				yield return m_FireRateMounted;
				m_IsWaiting = false;
				
		}
		yield return null;
=======
	public override IEnumerator ShootRoutine() {
			m_IsWaiting = true;
			// Debug.Log("Shoot from hand");
			GameObject bullet = Instantiate(m_ProjectileToShoot, m_MuzzleTransform.position, m_MuzzleTransform.rotation) as GameObject;
			bullet.GetComponent<BaseProjectile>().ShootProjectile(GetSpreadOffset());
			m_IsWaiting = true;
			yield return m_FireRate;
			m_IsWaiting = false;
>>>>>>> origin/Feature_Branch
	}
}
