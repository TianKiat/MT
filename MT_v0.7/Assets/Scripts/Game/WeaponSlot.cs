// ===============================
// AUTHOR: Ng Tian Kiat
// CREATE DATE: May 5 2016
// Description: WeaponSlot is a holder for weapons it contains the mounting point and weapons interface for choosing the weapons
// ===============================
/* Change History:
	
*/
using UnityEngine;
using System.Collections;

public class WeaponSlot : MonoBehaviour {
	public BaseWeapon m_EquippedWeapon; // The currently equipped weapon on the weapon slot
	public bool m_IsEquipped;
	//Mount the weapon from players hand to weapon slot
	public void Mount(GameObject _Weapon) 
	{
		//get weapon component
		m_EquippedWeapon = _Weapon.GetComponent<BaseWeapon>();
		//move the weapon to mounting slot and parent it there
		_Weapon.transform.parent = transform;
		_Weapon.transform.localPosition = Vector3.zero;
		m_EquippedWeapon.Mount();
		m_IsEquipped = true;
	}
	
	public void UnMount(PlayerInput _Player)
	{
		//move the weapon to mounting slot and parent it there
		m_EquippedWeapon.transform.parent = _Player.m_HandTransform;
		m_EquippedWeapon.transform.localPosition = Vector3.zero;
		// m_EquippedWeapon.transform.rotation = Quaternion.identity; // reset the rotation
		m_EquippedWeapon.Mount();
		m_EquippedWeapon = null;
		m_IsEquipped = false;
	}
}
