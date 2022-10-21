using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

    public class TrailScript : MonoBehaviour
    {

        LineRenderer line;
        public float pointSpacing = 0.1f;
        List<Vector3> points;
        public GameObject world;
        BoxCollider lastCollider;
        RaycastHit hit;
        int layerMask;
        public bool stopped = false;

        // Use this for initialization
        void Start()
        {
            line = GetComponent<LineRenderer>();

            points = new List<Vector3>();
            SetPoints();
            layerMask = 1 << LayerMask.NameToLayer("Plane");
        }

        // Update is called once per frame
        void Update()
        {
            if (!stopped && Vector3.Distance(points.Last(), transform.position) > pointSpacing)
                SetPoints();
        }

        // Collision Physics
        void FixedUpdate()
        {
            int i = Hit();
            if (i > 0)
            {
                AeroplaneController m_Aeroplane;
                Collider[] c = Physics.OverlapBox(points[i], Vector3.one * 4f, Quaternion.identity, layerMask);
                foreach(Collider co in c) {
                    m_Aeroplane = co.gameObject.GetComponentInParent<AeroplaneController>();
                    if (m_Aeroplane != null)
                    {
                        m_Aeroplane.Immobilize();
                    }
                }
            }
        }

        void SetPoints()
        {
            points.Add(transform.position);
            line.SetVertexCount(points.Count);
            line.SetPosition(points.Count - 1, transform.position);
        }

        int Hit()
        {
            int i = 0;
            while (i < points.Count - 8)
            {
                if (Physics.CheckBox(points[i], Vector3.one * 4f, Quaternion.identity, layerMask)) return i;
                i += 2;
            }
            if (i - 2 < 0) return -1;
            for (int x = -1; x <= 1; x++)
                for (int y = -1; y <= 1; y++)
                    for (int z = -1; z <= 1; z++)
                    {
                        Vector3 dir = new Vector3(x, y, z);
                        Debug.DrawLine(points[i - 2], points[i - 2] + dir * 4f);
                    }
            return -1;
        }
    }