// ===============================
// AUTHOR: Ng Tian Kiat
// CREATE DATE:
// Description: LaserPistol is a weapon that shoots a burst of lasers
// ===============================
/* Change History:

*/
using UnityEngine;
using System.Collections;

public class LaserPistol : BaseWeapon {
	[Tooltip("Number of bullets to shoot per burst\n(must be even number)")]public int m_BurstShotNumber; //Number of bullets to shoot per burst
	[Tooltip("How much vertical bullet spread there is")]public float m_VerticalRotationOffset; //the vertical rotation offect when shooting a shot
	public LayerMask m_HitMask; //layer mask to decide what the ray cast will hit
	public float m_BurstRate;
	public float m_Damage;
	private WaitForSeconds m_BurstWait;
	void Start() {
		m_BurstWait = new WaitForSeconds(m_BurstRate);
	}
	public override IEnumerator ShootRoutine() {
			m_IsWaiting = true;
			//Insert any shooting code here
			for (int i = -m_BurstShotNumber/2; i < m_BurstShotNumber/2; i++)
			{
				Fire(i);
				GameObject effect = Lean.LeanPool.Spawn(m_MuzzleFlashEffect,m_MuzzleTransform.position, m_MuzzleTransform.rotation);
				effect.GetComponent<ParticleSystemDestroyer>().DestroyLater();
				yield return m_BurstWait;
			}
			yield return m_FireRate;
			m_IsWaiting = false;	
	}
	private void Fire(int _index) {
		RaycastHit hit;
		Vector3 _Offset = new Vector3(0,_index * m_VerticalRotationOffset,0);// * GetSpreadOffset();
		if (Physics.Raycast(m_MuzzleTransform.position, m_MuzzleTransform.forward + _Offset, out hit, m_BulletRange, m_HitMask))
		{
			GameObject effect = Lean.LeanPool.Spawn(m_BulletHitEffect, hit.point, Quaternion.identity);
			effect.GetComponent<ParticleSystemDestroyer>().DestroyLater();
		}
	}
}
