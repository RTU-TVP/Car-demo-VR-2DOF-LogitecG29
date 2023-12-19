#region

using System.IO.MemoryMappedFiles;
using UnityEngine;

#endregion

namespace _2DOF.Core
{
    public class HandlerDataDebug : MonoBehaviour
    {
        private void Update()
        {
            using var memoryMappedFile = MemoryMappedFile.OpenExisting("2DOFMemoryDataGrabber");
            using var accessor = memoryMappedFile.CreateViewAccessor();

            var bytes = new byte[accessor.Capacity];

            accessor.ReadArray(0, bytes, 0, bytes.Length);

            Debug.Log($"AnglesX: {bytes[0]}");
            Debug.Log($"AnglesZ: {bytes[1]}");
            Debug.Log($"AnglesY: {bytes[2]}");
            Debug.Log($"VelocityZ: {bytes[3]}");
            Debug.Log($"VelocityX: {bytes[4]}");
            Debug.Log($"VelocityY: {bytes[5]}");
        }
    }
}