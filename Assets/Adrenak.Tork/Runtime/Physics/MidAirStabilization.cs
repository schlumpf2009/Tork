﻿using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Adrenak.Tork{
    public class MidAirStabilization : MonoBehaviour {
        [Header("Mid Air Stabilization")]
        public float stabilizationTorque = 15000;

        public Rigidbody m_Rigidbody;
        public Wheel[] m_Wheels;

        void FixedUpdate() {
            Stabilize();
        }

        void Stabilize() {
            var inAir = m_Wheels.Where(x => x.IsGrounded);
            if (inAir.Count() == 4) return;

            // Try to keep vehicle parallel to the ground while jumping
            Vector3 locUp = transform.up;
            Vector3 wsUp = new Vector3(0.0f, 1.0f, 0.0f);
            Vector3 axis = Vector3.Cross(locUp, wsUp);
            float force = stabilizationTorque;

            m_Rigidbody.AddTorque(axis * force);
        }
    }
}
