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
<<<<<<< HEAD
<<<<<<< HEAD
public class BaseWeapon : BaseInteractable, IWeapon {
	[HeaderAttribute("Projectiles")]
	public GameObject m_ProjectileToShootHandheld;
	public GameObject m_ProjectileToShootMounted;
	// [HideInInspector]public BaseProjectile m_ProjectileHandheld;
	// [HideInInspector]public BaseProjectile m_ProjectileMounted;
	[HeaderAttribute("Basic firing settings")]
	public float m_BulletSpreadHandheld;
	public float m_BulletSpreadMounted;
	public int m_RoundsPerSecondHandheld;
	public int m_RoundsPerSecondMounted;
	
	[HeaderAttribute("Mounted Settings")]
	public bool m_AutoFire;
	[HideInInspector]public bool m_CanFire;
	[HideInInspector]public List<BaseEnemy> m_CurrentEnemiesInRange = new List<BaseEnemy>();
	[HideInInspector]public BaseEnemy m_CurrentEnemyToKill;
	
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
		// m_ProjectileHandheld = m_ProjectileToShootHandheld.GetComponent<BaseProjectile>();
		// m_ProjectileMounted = m_ProjectileToShootMounted.GetComponent<BaseProjectile>();
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
			m_IsWaiting = false;
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
	//get bullet spread handheld
	public Vector3 GetSpreadOffsetHandheld() {
		float _x = Random.Range(-m_BulletSpreadHandheld, m_BulletSpreadHandheld);
		float _y = Random.Range(-m_BulletSpreadHandheld, m_BulletSpreadHandheld);
		float _z = Random.Range(-m_BulletSpreadHandheld, m_BulletSpreadHandheld);
=======
=======
>>>>>>> master
[RequireComponent(typeof(AudioSource))]
public class BaseWeapon : BaseInteractable, IWeapon {
	
	[HeaderAttribute("Basic firing settings")]
	public GameObject m_ProjectileToShoot; // if the gun uses projectiles place here
	public float m_BulletSpread;
	public float m_RoundsPerSecond;
	public float m_BulletRange;
	
	
	[HeaderAttribute("Object references")]
	public Transform m_MuzzleTransform;
	public GameObject m_MuzzleFlashEffect;
	public AudioClip m_FiringSound;
	public GameObject m_BulletHitEffect;
	public AudioClip m_BulletHitSound;

	[HideInInspector]public bool m_CanFire;
	protected WaitForSeconds m_FireRate;
	[HideInInspector]public bool m_IsWaiting;

	void Start() {
		
		
		//Set up needed variables
		if (m_RoundsPerSecond > 0)
		{
			m_FireRate = new WaitForSeconds(1/m_RoundsPerSecond);
		}
		else
		{
			Debug.Log("No Fire Rate Set!");
			m_FireRate = new WaitForSeconds(0f);
		}
		m_IsWaiting = false;
		m_CanFire = true;
	}
	//Shooting method
	public void Shoot() 
	{
			StartCoroutine(ShootRoutine());
	}
	
	//Method: when called shoots the set projectile
	public virtual IEnumerator ShootRoutine() {
		yield return null;
	}
	
	//Method: help to get bullet spread rotation
	public Vector3 GetSpreadOffset() {
		float _x = Random.Range(-m_BulletSpread, m_BulletSpread);
		float _y = Random.Range(-m_BulletSpread, m_BulletSpread);
		float _z = Random.Range(-m_BulletSpread, m_BulletSpread);
<<<<<<< HEAD
>>>>>>> origin/Feature_Branch
=======
>>>>>>> master
		Vector3 _rotation = new Vector3(_x, _y, _z);
		
		return _rotation;
	}
<<<<<<< HEAD
<<<<<<< HEAD
	//get bullet spread mounted
	public Vector3 GetSpreadOffsetMounted() {
		float _x = Random.Range(-m_BulletSpreadMounted, m_BulletSpreadMounted);
		float _y = Random.Range(-m_BulletSpreadMounted, m_BulletSpreadMounted);
		float _z = Random.Range(-m_BulletSpreadMounted, m_BulletSpreadMounted);
		Vector3 _rotation =  new Vector3(_x, _y, _z);
		
		return _rotation;
	}
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
=======
=======
>>>>>>> master
	// Call this method to rumble the hand controllers
	public virtual void RumbleRecoil() {
		//implement this method when you get steamVR working
	}
}
<<<<<<< HEAD
>>>>>>> origin/Feature_Branch
=======
>>>>>>> master
