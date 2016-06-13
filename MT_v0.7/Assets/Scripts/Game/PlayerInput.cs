// ===============================
// AUTHOR: Ng Tian Kiat
// CREATE DATE:
// Description: PlayerInput is 
// ===============================
/* Change History:

*/
using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	public KeyCode m_HandheldWeaponFireKey;
	public KeyCode m_ShotGunWeaponFireKey;
	// public KeyCode m_MountingWeaponKey;
	public float m_InteractionRange;
	public LayerMask m_InteractableObjects;
	public PlayerActions m_PlayerActions;

	void Update() {
		//Fire the handheld weapon
		if (Input.GetKey(m_HandheldWeaponFireKey)) {
			//check for null
			if (m_PlayerActions.m_HandheldWeapon != null)
			{
				m_PlayerActions.ShootPistol();
			}
			else
			{
				Debug.Log("No weapon in hand you little shit!");
			}
		}
		//Fire the mounted weapon
		if (Input.GetKeyDown(m_ShotGunWeaponFireKey)) {
			//check for null
			if (m_PlayerActions.m_ShotGunWeapon != null)
			{
				m_PlayerActions.ShootShotGun();
			}
			else
			{
				Debug.Log("No shotgun weapon you little shit!");
			}
		}
	}
}
