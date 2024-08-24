//https://www.youtube.com/watch?v=WyPgJ5scclM

using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    

    [RequireComponent(typeof (BusController))]
    public class BusUserControl : MonoBehaviour
    {
        //private BusController m_Bus; // the car controller we want to use

        public BusController m_Bus;
        private void Awake()
        {
            // get the car controller
            //m_Bus = GetComponent<BusController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Bus.Move(h, v, v, handbrake);
#else
            m_Bus.Move(h, v, v, 0f);
#endif
        }
    }
}
