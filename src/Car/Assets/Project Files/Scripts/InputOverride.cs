using System;
using Services.Input;
using UnityEngine;

namespace Car.ByGround
{
    public class InputOverride : MonoBehaviour
    {
        [SerializeField] private PlayerInputControlsReader playerInputControlsReader;
        private RCC_Inputs _newInputs;

        private void Awake()
        {
            Initialization();
        }

        private void Initialization()
        {
            RCC_InputManager.Instance.logitechHShifterUsed = true;
            
            _newInputs = new RCC_Inputs
            {
                gearInput = -2
            };

            var rccCarControllerV3 = GetComponent<RCC_CarControllerV3>();
            rccCarControllerV3.OverrideInputs(_newInputs); // переопределение ввода
            rccCarControllerV3.AutoReverse = false; // автоматический реверс, когда игрок нажимает кнопку тормоза
            rccCarControllerV3.AutomaticGear = false; // автоматическое переключение передач
            rccCarControllerV3.UseAutomaticClutch = false; // автоматическое сцепление
        }

        public void OnEnable()
        {
            playerInputControlsReader.Steering += OnSteering;
            playerInputControlsReader.Handbrake += OnHandbrake;
            playerInputControlsReader.Throttle += OnThrottle;
            playerInputControlsReader.Clutch += OnClutch;
            playerInputControlsReader.Brake += OnBrake;
            playerInputControlsReader.Shifter += OnShifter;
            playerInputControlsReader.ShifterUp += OnShifterUp;
            playerInputControlsReader.ShifterDown += OnShifterDown;
        }

        public void OnDisable()
        {
            playerInputControlsReader.Steering -= OnSteering;
            playerInputControlsReader.Handbrake -= OnHandbrake;
            playerInputControlsReader.Throttle -= OnThrottle;
            playerInputControlsReader.Clutch -= OnClutch;
            playerInputControlsReader.Brake -= OnBrake;
            playerInputControlsReader.Shifter -= OnShifter;
            playerInputControlsReader.ShifterUp -= OnShifterUp;
            playerInputControlsReader.ShifterDown -= OnShifterDown;
        }

        private void OnSteering(float value)
        {
            _newInputs.steerInput = value;
        }

        private void OnHandbrake(float value)
        {
            _newInputs.handbrakeInput = value;
        }

        private void OnThrottle(float value)
        {
            _newInputs.throttleInput = value;
        }

        private void OnClutch(float value)
        {
            _newInputs.clutchInput = value;
        }

        private void OnBrake(float value)
        {
            _newInputs.brakeInput = value;
        }

        private void OnShifter(int gearNumber, bool isNoNeutral)
        {
            if (isNoNeutral && gearNumber != 0)
            {
                if (gearNumber != 6)
                {
                    _newInputs.gearInput = gearNumber - 1;
                }
                else
                {
                    _newInputs.gearInput = -1;
                }
            }
            else
            {
                _newInputs.gearInput = -2;
            }
        }

        private void OnShifterUp()
        {
            if (_newInputs.gearInput < 7)
            {
                OnShifter(_newInputs.gearInput + 1, true);
            }
        }

        private void OnShifterDown()
        {
            if (_newInputs.gearInput > -1)
            {
                OnShifter(_newInputs.gearInput - 1, true);
            }
        }
    }
}