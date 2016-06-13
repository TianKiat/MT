// ===============================
// AUTHOR: Ng Tian Kiat
// CREATE DATE:
// Description: HoverCraft is the parent object and will manage all systems on the hovercraft
// ===============================
/* Change History:

*/
using UnityEngine;
using System.Collections;

public class HoverCraft : MonoBehaviour {
	[Header("Hovercraft object references")]
	public VehicleParent m_VehicleParent;
	public VehicleWeaponsManager m_VehicleWeaponsManager;
	public HoverSteer m_SteeringObject;
}
