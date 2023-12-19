#region

using System.IO.MemoryMappedFiles;
using System.Threading;
using _2DOF.Core;
using UnityEngine;

#endregion

namespace _2DOF.Sample
{
    public class GameController : MonoBehaviour
    {
        private const string MAP_NAME = "2DOFMemoryDataGrabber";

        [SerializeField] private CarTelemetryHandler _carTelemetryHandler;
        private ObjectTelemetryData _objectTelemetryData;

        private void Awake()
        {
            InitializeParameters();
            new Thread(HandlerData).Start();
        }

        private void InitializeParameters()
        {
            _objectTelemetryData = new ObjectTelemetryData();
            _carTelemetryHandler.SetObjectTelemetryData(_objectTelemetryData);
        }

        private void HandlerData()
        {
            const int WAIT_TIME = 20;

            using var memoryMappedFile = MemoryMappedFile.CreateOrOpen(MAP_NAME, _objectTelemetryData.DataArray.Length);

            while (true)
            {
                using var accessor = memoryMappedFile.CreateViewAccessor();

                accessor.WriteArray(0, _objectTelemetryData.DataArray, 0, 6);

                Thread.Sleep(WAIT_TIME);
            }
        }
    }
}