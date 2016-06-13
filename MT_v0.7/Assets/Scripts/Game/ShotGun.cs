// ===============================
// AUTHOR: Ng Tian Kiat
// CREATE DATE:
// Description: ShotGun is first secondary weapon the player has
// ===============================
/* Change History:

*/
using UnityEngine;
using System.Collections;

public class ShotGun : BaseWeapon {
	[Tooltip("Number of bullets to shoot per burst\n(must be even number)")]public int m_BurstShotNumber; //Number of bullets to shoot per burst
	public LayerMask m_HitMask; //layer mask to decide what the ray cast will hit
	public float m_BurstRate;
	public float m_ReloadTime;
	public float m_Damage;

	private WaitForSeconds m_BurstWait;
	private WaitForSeconds m_ReloadWait;
	void Start() {
		m_BurstWait = new WaitForSeconds(m_BurstRate);
		m_ReloadWait = new WaitForSeconds(m_ReloadTime);
	}
	public override IEnumerator ShootRoutine() {
			m_IsWaiting = true;
			//Insert any shooting code here
			for (int i = -m_BurstShotNumber/2; i < m_BurstShotNumber/2; i++)
			{
				Fire();
				GameObject effect = Lean.LeanPool.Spawn(m_MuzzleFlashEffect,m_MuzzleTransform.position, m_MuzzleTransform.rotation);
				effect.GetComponent<ParticleSystemDestroyer>().DestroyLater();
				yield return m_BurstWait;
			}
			yield return m_ReloadWait;
			m_IsWaiting = false;	
	}
	private void Fire() {
		RaycastHit hit;
		Vector3 _Offset = GetSpreadOffset();
		if (Physics.Raycast(m_MuzzleTransform.position, m_MuzzleTransform.forward + _Offset, out hit, m_BulletRange, m_HitMask))
		{
			GameObject effect = Lean.LeanPool.Spawn(m_BulletHitEffect, hit.point, Quaternion.identity);
			effect.GetComponent<ParticleSystemDestroyer>().DestroyLater();
		}
	}
}
