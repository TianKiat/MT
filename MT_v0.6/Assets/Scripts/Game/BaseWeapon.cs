// ===============================
// AUTHOR: Ng Tian Kiat
// CREATE DATE: 5 May 2016
// Description: BaseWeapon is the base class of all weapons
// ===============================
/* Change History:

*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class BaseWeapon : BaseInteractable, IWeapon {
	[HeaderAttribute("Projectiles")]
	public GameObject m_ProjectileToShootHandheld;
	public GameObject m_ProjectileToShootMounted;
	
	[HeaderAttribute("Mounted Settings")]
	public bool m_AutoFire;
	[HideInInspector]public bool m_CanFire;
	[HideInInspector]public List<BaseEnemy> m_CurrentEnemiesInRange = new List<BaseEnemy>();
	[HideInInspector]public BaseEnemy m_CurrentEnemyToKill;
	
	[HeaderAttribute("Rate of Fire")]
	public int m_RoundsPerSecondHandheld;
	public int m_RoundsPerSecondMounted;
	
	[HeaderAttribute("Form references")]
	public Transform m_MuzzleHandheld;
	public Transform m_MuzzleMounted;
	public GameObject m_HandheldForm;
	public GameObject m_MountedForm;
	
	protected WaitForSeconds m_FireRateHandheld;
	protected WaitForSeconds m_FireRateMounted;
	
	[HideInInspector]public bool m_IsWaiting;
	[HideInInspector]public bool m_IsMounted = false;

	void Start() {
		m_FireRateHandheld = new WaitForSeconds(1/m_RoundsPerSecondHandheld);
		m_FireRateMounted = new WaitForSeconds(1/m_RoundsPerSecondMounted);
		m_IsWaiting = false;
		m_CanFire = true;
		
	}
	public void Shoot() 
	{
			StartCoroutine(ShootHandheld());
	}
	
	public void Mount()
	{
		if (m_IsMounted)
		{
			//unmount
			m_IsMounted = false;
			StartCoroutine(TransformWeapon(m_IsMounted));
		}
		else if (!m_IsMounted)
		{
			//mount
			m_IsMounted = true;
			StartCoroutine(TransformWeapon(m_IsMounted));
		}
	}
	//Method: when called shoots the set projectile
	public virtual IEnumerator ShootHandheld() {
		yield return null;
	}
	//Method: when called shoots the set projectile
	public virtual IEnumerator ShootMounted() {
		yield return null;
	}
	
	//Method: when called shoots the set projectile
	public IEnumerator TransformWeapon(bool _form) {
		//transform from one form to another
		
		//transform from handheld to mounted
		if (_form)
		{
			m_HandheldForm.SetActive(false);
			m_MountedForm.SetActive(true);
			StartCoroutine("ShootMounted");
		}
		// transform from mounted to handheld
		else if (!_form)
		{
			m_HandheldForm.SetActive(true);
			m_MountedForm.SetActive(false);
			StopCoroutine("ShootMounted");
		}
		yield return null;
	}
// 	public BaseEnemy FindNearestEnemy() 
// 	{
// 		m_CurrentEnemiesInRange.Sort(new SortByDistance());
// 		return m_CurrentEnemiesInRange[0];
// 	}
}

// public class SortByDistance : IComparer<BaseEnemy> {
// 	// list[0] will be the closest,
// 	float ByDistance(BaseEnemy a, BaseEnemy b)
//  	{
// 		float dstToA = Vector3.Distance(transform.position, a.transform.position);
// 		float dstToB = Vector3.Distance(transform.position, b.transform.position);
// 		return dstToA.CompareTo(dstToB);
//  	}
//  }
