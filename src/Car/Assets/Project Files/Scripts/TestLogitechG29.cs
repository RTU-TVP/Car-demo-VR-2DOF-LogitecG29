using System;
using LogitechG29.Runtime.LogitechSDK;
using UnityEngine;

public class TestLogitechG29 : MonoBehaviour
{
    private LogitechG29.Runtime.LogitechG29 _logitechG29;

    [Space] public int springForceOffset; public int springForceSaturation; public int springForceCoefficient;
    [Space] public int constantForceMagnitude;
    [Space] public int damperForceCoefficient;
    [Space] public int frontalCollisionForceMagnitude;
    [Space] public int sideCollisionForceMagnitude;
    [Space] public int dirtRoadEffectMagnitude;
    [Space] public int bumpyRoadEffectMagnitude;
    [Space] public int slipperyRoadEffectMagnitude;
    [Space] public LogitechG29.Runtime.LogitechG29.SurfaceType surfaceType; public int surfaceEffectMagnitude;public int  surfaceEffectPeriod;
    [Space] public int softstopForceUsableRange;

    [Space, Space, Space] 
    public bool forceEnable;
    public int overallGain;
    public int springGain;
    public int damperGain;
    public bool defaultSpringEnabled;
    public int defaultSpringGain;
    public bool combinePedals;
    public int wheelRange;
    public bool gameSettingsEnabled;
    public bool allowGameSettings;

    private void Start()
    {
        _logitechG29 = LogitechG29.Runtime.LogitechG29.Current;
    }

    void Update()
    {
        if (_logitechG29.IsConnected == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            var propertiesData = new LogitechGsdk.LogiControllerPropertiesData();
            _logitechG29.GetControllerProperties(ref propertiesData);
            forceEnable = propertiesData.forceEnable;
            overallGain = propertiesData.overallGain;
            springGain = propertiesData.springGain;
            damperGain = propertiesData.damperGain;
            defaultSpringEnabled = propertiesData.defaultSpringEnabled;
            defaultSpringGain = propertiesData.defaultSpringGain;
            combinePedals = propertiesData.combinePedals;
            wheelRange = propertiesData.wheelRange;
            gameSettingsEnabled = propertiesData.gameSettingsEnabled;
            allowGameSettings = propertiesData.allowGameSettings;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            var propertiesData = new LogitechGsdk.LogiControllerPropertiesData
            {
                forceEnable = forceEnable,
                overallGain = overallGain,
                springGain = springGain,
                damperGain = damperGain,
                defaultSpringEnabled = defaultSpringEnabled,
                defaultSpringGain = defaultSpringGain,
                combinePedals = combinePedals,
                wheelRange = wheelRange,
                gameSettingsEnabled = gameSettingsEnabled,
                allowGameSettings = allowGameSettings
            };
            _logitechG29.SetControllerProperties(propertiesData);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (springForceOffset > 0 || springForceSaturation > 0 || springForceCoefficient > 0)
                _logitechG29.PlaySpringForce(springForceOffset, springForceSaturation, springForceCoefficient);

            if (constantForceMagnitude > 0)
                _logitechG29.PlayConstantForce(constantForceMagnitude);

            if (damperForceCoefficient > 0)
                _logitechG29.PlayDamperForce(damperForceCoefficient);

            if (frontalCollisionForceMagnitude > 0)
                _logitechG29.PlayFrontalCollisionForce(frontalCollisionForceMagnitude);

            if (sideCollisionForceMagnitude > 0)
                _logitechG29.PlaySideCollisionForce(sideCollisionForceMagnitude);

            if (dirtRoadEffectMagnitude > 0)
                _logitechG29.PlayDirtRoadEffect(dirtRoadEffectMagnitude);

            if (bumpyRoadEffectMagnitude > 0)
                _logitechG29.PlayBumpyRoadEffect(bumpyRoadEffectMagnitude);

            if (slipperyRoadEffectMagnitude > 0)
                _logitechG29.PlaySlipperyRoadEffect(slipperyRoadEffectMagnitude);

            if (surfaceEffectMagnitude > 0 || surfaceEffectPeriod > 0)
                _logitechG29.PlaySurfaceEffect(surfaceType, surfaceEffectMagnitude, surfaceEffectPeriod);

            if (softstopForceUsableRange > 0)
                _logitechG29.PlaySoftstopForce(softstopForceUsableRange);
        }
    }
}