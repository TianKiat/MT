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
		Vector3 _rotation = new Vector3(_x, _y, _z);
		
		return _rotation;
	}
	// Call this method to rumble the hand controllers
	public virtual void RumbleRecoil() {
		//implement this method when you get steamVR working
	}
}
