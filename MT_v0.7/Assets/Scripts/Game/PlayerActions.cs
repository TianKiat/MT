// ===============================
// AUTHOR: Ng Tian Kiat
// CREATE DATE:
// Description: PlayerActions is 
// ===============================
/* Change History:

*/
using UnityEngine;
using System.Collections;

public class PlayerActions : MonoBehaviour {
	public BaseWeapon m_HandheldWeapon;
	public Transform m_HandTransform;

	public BaseWeapon m_ShotGunWeapon;

	void Start() {
		if (m_HandheldWeapon != null) {
			m_HandheldWeapon.transform.parent = m_HandTransform;
			m_HandheldWeapon.transform.localPosition = Vector3.zero;
		}
	}
	public void ShootPistol() {
		if (!m_HandheldWeapon.m_IsWaiting)
			{
				m_HandheldWeapon.Shoot();
			}
	}
	public void ShootShotGun() {
		if (!m_ShotGunWeapon.m_IsWaiting)
			{
				m_ShotGunWeapon.Shoot();
			}
	}
}
