namespace _2DOF.Core
{
    public class ObjectTelemetryData
    {
        public double AnglesX { get; set; }
        public double AnglesZ { get; set; }
        public double AnglesY { get; set; }
        public double VelocityZ { get; set; }
        public double VelocityX { get; set; }
        public double VelocityY { get; set; }

        public double[] DataArray => new[] { AnglesX, AnglesZ, AnglesY, VelocityZ, VelocityX, VelocityY };

        public void Reset()
        {
            AnglesX = 0.0;
            AnglesZ = 0.0;
            AnglesY = 0.0;
            VelocityZ = 0.0;
            VelocityX = 0.0;
            VelocityY = 0.0;
        }
    }
}