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
	public BaseWeapon m_CurrentWeapon;
	public Transform m_HandTransform;
	public KeyCode m_WeaponFireKey;
	public KeyCode m_MountingWeaponKey;
	public float m_InteractionRange;
	public LayerMask m_InteractableObjects;
	void Start() {
		if (m_CurrentWeapon != null) {
			m_CurrentWeapon.transform.parent = m_HandTransform;
			m_CurrentWeapon.transform.localPosition = Vector3.zero;
		}
	}

	void Update() {
		//Fire the handheld weapon
		if (Input.GetKey(m_WeaponFireKey) && m_CurrentWeapon != null) {
			if (!m_CurrentWeapon.m_IsWaiting)
			{
				m_CurrentWeapon.Shoot();
			}
		}
		
		//Mount a weapon to a weapon slot that is being mouse overed
		if (Input.GetKeyDown(m_MountingWeaponKey) && m_CurrentWeapon != null) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, m_InteractionRange, m_InteractableObjects))
			{
				if (hit.collider.gameObject.CompareTag("WeaponSlot"))
				{
					WeaponSlot slot =  hit.collider.gameObject.GetComponent<WeaponSlot>();
					if (!slot.m_IsEquipped)
					{
						slot.Mount(m_CurrentWeapon.gameObject);
						m_CurrentWeapon.transform.localRotation = Quaternion.identity;
						m_CurrentWeapon = null;
					}
				}
			}
		}
		
		//Pickup a weapon from the mounting slot
		else if (Input.GetKeyDown(m_MountingWeaponKey) && m_CurrentWeapon == null) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, m_InteractionRange, m_InteractableObjects))
			{
				if (hit.collider.gameObject.CompareTag("WeaponSlot"))
				{
					WeaponSlot slot =  hit.collider.gameObject.GetComponent<WeaponSlot>();
					if (slot.m_IsEquipped)
					{
						m_CurrentWeapon = slot.m_EquippedWeapon;
						slot.UnMount(this);
						m_CurrentWeapon.transform.localRotation = Quaternion.identity;
					}
				}
			}
		}
	}
}
