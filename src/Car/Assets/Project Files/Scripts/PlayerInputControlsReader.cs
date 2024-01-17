#region

using System;
using UnityEngine;
using UnityEngine.InputSystem;

#endregion

namespace Services.Input
{
    [CreateAssetMenu(fileName = "PlayerInputControlsReader", menuName = "Input/PlayerInputControlsReader")]
    public class PlayerInputControlsReader : ScriptableObject,
        PlayerInputControls.IMovingActions,
        PlayerInputControls.IOtherActions
    {
        public static PlayerInputControlsReader Instance { get; private set; }

        #region Unity functions

        private PlayerInputControls _playerInputControls;

        private void OnEnable()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Debug.LogError("There is more than one PlayerInputControlsReader in the scene.");
            }

            _playerInputControls = new PlayerInputControls();

            _playerInputControls.Moving.SetCallbacks(this);
            _playerInputControls.Other.SetCallbacks(this);

            _playerInputControls.Enable();
        }

        private void OnDisable()
        {
            _playerInputControls.Disable();
        }

        #endregion

        #region Actions

        public Action<float> Steering { get; set; }
        public Action<float> Handbrake { get; set; }
        public Action<float> Throttle { get; set; }
        public Action<float> Clutch { get; set; }
        public Action<float> Brake { get; set; }
        public Action<int, bool> Shifter { get; set; }
        public Action ShifterUp { get; set; }
        public Action ShifterDown { get; set; }

        public Action<bool> Other_Ignition { get; set; }

        #endregion

        #region Moving

        public void OnSteering(InputAction.CallbackContext context)
        {
            Steering?.Invoke(context.ReadValue<float>());
        }

        public void OnThrottle(InputAction.CallbackContext context)
        {
            Throttle?.Invoke(context.ReadValue<float>());
        }

        public void OnClutch(InputAction.CallbackContext context)
        {
            Clutch?.Invoke(context.ReadValue<float>());
        }

        public void OnBrake(InputAction.CallbackContext context)
        {
            Brake?.Invoke(context.ReadValue<float>());
        }

        public void OnHandbrake(InputAction.CallbackContext context)
        {
            Handbrake?.Invoke(context.ReadValue<float>());
        }

        public void OnShifter1(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                return;
            }

            Shifter?.Invoke(1, context.ReadValueAsButton());
        }

        public void OnShifter2(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                return;
            }

            Shifter?.Invoke(2, context.ReadValueAsButton());
        }

        public void OnShifter3(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                return;
            }

            Shifter?.Invoke(3, context.ReadValueAsButton());
        }

        public void OnShifter4(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                return;
            }

            Shifter?.Invoke(4, context.ReadValueAsButton());
        }

        public void OnShifter5(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                return;
            }

            Shifter?.Invoke(5, context.ReadValueAsButton());
        }

        public void OnShifter6(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                return;
            }

            Shifter?.Invoke(6, context.ReadValueAsButton());
        }

        public void OnShifter7(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                return;
            }

            Shifter?.Invoke(7, context.ReadValueAsButton());
        }

        public void OnShifterUp(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                ShifterUp?.Invoke();
            }
        }

        public void OnShifterDown(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                ShifterDown?.Invoke();
            }
        }

        public void OnShifterNeutral(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                Shifter?.Invoke(0, false);
            }
        }

        #endregion

        #region Other

        public void OnIgnition(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                Other_Ignition?.Invoke(true);
            }

            if (context.canceled)
            {
                Other_Ignition?.Invoke(false);
            }
        }

        #endregion
    }
}