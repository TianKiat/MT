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
	
	public override IEnumerator ShootRoutine() {
			m_IsWaiting = true;
			// Debug.Log("Shoot from hand");
			GameObject bullet = Instantiate(m_ProjectileToShoot, m_MuzzleTransform.position, m_MuzzleTransform.rotation) as GameObject;
			bullet.GetComponent<BaseProjectile>().ShootProjectile(GetSpreadOffset());
			m_IsWaiting = true;
			yield return m_FireRate;
			m_IsWaiting = false;
	}
}
