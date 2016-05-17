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
			Debug.Log("Shoot");
			Instantiate(m_ProjectileToShootHandheld, m_MuzzleHandheld.position, m_MuzzleHandheld.rotation);
			m_IsWaiting = true;
			yield return m_FireRateHandheld;
			m_IsWaiting = false;
		}
	}
	public override IEnumerator ShootMounted() {
		while (m_IsMounted && m_CanFire && m_AutoFire)
		{
				m_IsWaiting = true;
				Debug.Log("Shoot");
				Instantiate(m_ProjectileToShootMounted, m_MuzzleMounted.position, m_MuzzleMounted.rotation);
				m_IsWaiting = true;
				yield return m_FireRateMounted;
				m_IsWaiting = false;
				
		}
		yield return null;
	}
}
