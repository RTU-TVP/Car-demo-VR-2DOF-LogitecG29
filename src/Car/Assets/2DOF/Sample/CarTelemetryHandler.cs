#region

using System.Collections;
using _2DOF.Core;
using UnityEngine;

#endregion

namespace _2DOF.Sample
{
    public class CarTelemetryHandler : MonoBehaviour
    {
        [SerializeField] private Transform vehicleTransform;
        [SerializeField] private Rigidbody _rigidbody;
        private ObjectTelemetryData _telemetryDataData;

        private void Start()
        {
            StartCoroutine(TelemetryHandler());
        }

        private IEnumerator TelemetryHandler()
        {
            while (true)
            {
                if (_telemetryDataData == null)
                {
                    yield return new WaitForSeconds(0.5f);
                    continue;
                }

                var rotation = vehicleTransform.rotation;
                _telemetryDataData.AnglesX = rotation.eulerAngles.x > 180
                    ? rotation.eulerAngles.x - 360
                    : rotation.eulerAngles.x;
                _telemetryDataData.AnglesZ = rotation.eulerAngles.z > 180
                    ? rotation.eulerAngles.z - 360
                    : rotation.eulerAngles.z;
                _telemetryDataData.AnglesY = rotation.eulerAngles.y > 180
                    ? rotation.eulerAngles.y - 360
                    : rotation.eulerAngles.y;

                var velocity = _rigidbody.velocity;
                _telemetryDataData.VelocityZ = velocity.z;
                _telemetryDataData.VelocityX = velocity.x;
                _telemetryDataData.VelocityY = velocity.y;

                yield return null;
            }
        }

        public void SetObjectTelemetryData(ObjectTelemetryData objectTelemetryData)
        {
            _telemetryDataData = objectTelemetryData;
        }
    }
}