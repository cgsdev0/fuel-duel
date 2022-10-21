using UnityEngine;
using System.Collections;

public class RefuelScript : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider col)
    {
        AeroplaneController m_Aeroplane;
        m_Aeroplane = col.gameObject.GetComponentInParent<AeroplaneController>();
        if (m_Aeroplane != null)
        {
            m_Aeroplane.Refuel();
        }
    }
}
