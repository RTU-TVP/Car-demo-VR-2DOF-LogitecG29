#region

using LogitechG29.Core.Input;
using UnityEngine;

#endregion

namespace LogitechG29.Sample
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private InputControllerReader _inputControllerReader;

        private void Start()
        {
            _inputControllerReader.OnHomeCallback += value => Application.Quit();

            _inputControllerReader.OnOptionsCallback += OnOptionsCallback;
        }

        private void Update()
        {
            if (_inputControllerReader.Steering != 0)
            {
                Debug.Log("Steering: " + _inputControllerReader.Steering);
            }

            if (_inputControllerReader.Throttle > 10)
            {
                Debug.Log("Help me, please!");
            }
        }

        private void OnOptionsCallback(bool value)
        {
            Debug.Log("OnOptionsCallback: " + value);
        }
    }
}