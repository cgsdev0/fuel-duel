using UnityEngine;
using System.Collections;
using InControl;

    [RequireComponent(typeof(AeroplaneController))]
    public class AirplaneControls : MonoBehaviour
    {
        // these max angles are only used on mobile, due to the way pitch and roll input are handled
        public float maxRollAngle = 80;
        public float maxPitchAngle = 80;
        public int playerNum = 0;
        private InputDevice myDevice;

        // reference to the aeroplane that we're controlling
        private AeroplaneController m_Aeroplane;


        private void Awake()
        {
            // Set up the reference to the aeroplane controller.
            m_Aeroplane = GetComponent<AeroplaneController>();
            Persist p = GameObject.Find("GamePersistent").GetComponent<Persist>();
            if(playerNum < p.numPlayers)
                myDevice = GameObject.Find("GamePersistent").GetComponent<Persist>().controllers[playerNum];
        }


        private void FixedUpdate()
        {
            // Read input for the pitch, yaw, roll and throttle of the aeroplane.
            float roll = myDevice.LeftStickX.Value;
            float pitch = myDevice.LeftStickY.Value;
            float yaw1 = myDevice.LeftBumper.IsPressed ? -1f : 0f;
            float yaw2 = myDevice.RightBumper.IsPressed ? 1f : 0f;
            float yaw = yaw1 + yaw2;
            bool airBrakes = myDevice.LeftTrigger.IsPressed;

            // auto throttle up, or down if braking.
            float throttle = myDevice.RightTrigger.Value - myDevice.LeftTrigger.Value;
            //Debug.Log(throttle);

            // Pass the input to the aeroplane
            m_Aeroplane.Move(roll, pitch, yaw, throttle, airBrakes);
        }


        private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
        {
            // because mobile tilt is used for roll and pitch, we help out by
            // assuming that a centered level device means the user
            // wants to fly straight and level!

            // this means on mobile, the input represents the *desired* roll angle of the aeroplane,
            // and the roll input is calculated to achieve that.
            // whereas on non-mobile, the input directly controls the roll of the aeroplane.

            float intendedRollAngle = roll * maxRollAngle * Mathf.Deg2Rad;
            float intendedPitchAngle = pitch * maxPitchAngle * Mathf.Deg2Rad;
            roll = Mathf.Clamp((intendedRollAngle - m_Aeroplane.RollAngle), -1, 1);
            pitch = Mathf.Clamp((intendedPitchAngle - m_Aeroplane.PitchAngle), -1, 1);

            // similarly, the throttle axis input is considered to be the desired absolute value, not a relative change to current throttle.
            float intendedThrottle = throttle * 0.5f + 0.5f;
            throttle = Mathf.Clamp(intendedThrottle - m_Aeroplane.Throttle, -1, 1);
        }
    }
