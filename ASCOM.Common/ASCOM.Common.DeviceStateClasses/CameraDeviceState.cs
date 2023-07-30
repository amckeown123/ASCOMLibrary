﻿using ASCOM.Common.DeviceInterfaces;
using ASCOM.Common.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ASCOM.Common.DeviceStateClasses
{
    /// <summary>
    /// Class that presents the device's operation state as a set of nullable properties
    /// </summary>
    public class CameraDeviceState
    {
        // Assign the name of this class
        string className = nameof(CameraDeviceState);

        /// <summary>
        /// Create a new CameraDeviceState instance
        /// </summary>
        public CameraDeviceState() { }

        /// <summary>
        /// Create a new CameraDeviceState instance from the device's DeviceState response.
        /// </summary>
        /// <param name="deviceState">The device's DeviceState response.</param>
        /// <param name="TL">Debug ILogger instance.</param>
        public CameraDeviceState(IList<IStateValue> deviceState, ILogger TL)
        {
            TL?.LogMessage(LogLevel.Debug, className, $"Received {deviceState.Count} items");

            // Handle null List
            if (deviceState is null) // No List was supplied so return
            {
                TL?.LogMessage(LogLevel.Debug, className, $"Supplied device state is null, all values will be unknown.");
                return;
            }

            // An List was supplied so process each supplied value
            foreach (IStateValue stateValue in deviceState)
            {
                try
                {
                    TL?.LogMessage(LogLevel.Debug, className, $"{stateValue.Name} = {stateValue.Value}");

                    switch (stateValue.Name)
                    {
                        case nameof(ICameraV4.CameraState):
                            try
                            {
                                CameraState = (CameraState)stateValue.Value;
                            }
                            catch (Exception ex)
                            {
                                TL?.LogMessage(LogLevel.Debug, className, $"CameraState - Ignoring exception: {ex.Message}");
                            }
                            TL?.LogMessage(LogLevel.Debug, className, $"CameraState has value: {CameraState.HasValue}, Value: {CameraState}");
                            break;

                        case nameof(ICameraV4.CCDTemperature):
                            try
                            {
                                CCDTemperature = (double)stateValue.Value;
                            }
                            catch (Exception ex)
                            {
                                TL?.LogMessage(LogLevel.Debug, className, $"CCDTemperature - Ignoring exception: {ex.Message}");
                            }
                            TL?.LogMessage(LogLevel.Debug, className, $"CCDTemperature has value: {CCDTemperature.HasValue}, Value: {CCDTemperature}");
                            break;

                        case nameof(ICameraV4.CoolerPower): 
                            try
                            {
                                CoolerPower = (double)stateValue.Value;
                            }
                            catch (Exception ex)
                            {
                                TL?.LogMessage(LogLevel.Debug, className, $"CoolerPower - Ignoring exception: {ex.Message}");
                            }
                            TL?.LogMessage(LogLevel.Debug, className, $"CoolerPower has value: {CoolerPower.HasValue}, Value: {CoolerPower}");
                            break;

                        case nameof(ICameraV4.HeatSinkTemperature):
                            try
                            {
                                HeatSinkTemperature = (double)stateValue.Value;
                            }
                            catch (Exception ex)
                            {
                                TL?.LogMessage(LogLevel.Debug, className, $"HeatSinkTemperature - Ignoring exception: {ex.Message}");
                            }
                            TL?.LogMessage(LogLevel.Debug, className, $"HeatSinkTemperature has value: {HeatSinkTemperature.HasValue}, Value: {HeatSinkTemperature}");
                            break;

                        case nameof(ICameraV4.ImageReady):
                            try
                            {
                                ImageReady = (bool)stateValue.Value;
                            }
                            catch (Exception ex)
                            {
                                TL?.LogMessage(LogLevel.Debug, className, $"ImageReady - Ignoring exception: {ex.Message}");
                            }
                            TL?.LogMessage(LogLevel.Debug, className, $"ImageReady has value: {ImageReady.HasValue}, Value: {ImageReady}");
                            break;

                        case nameof(ICameraV4.IsPulseGuiding):
                            try
                            {
                                IsPulseGuiding = (bool)stateValue.Value;
                            }
                            catch (Exception ex)
                            {
                                TL?.LogMessage(LogLevel.Debug, className, $"IsPulseGuiding - Ignoring exception: {ex.Message}");
                            }
                            TL?.LogMessage(LogLevel.Debug, className, $"IsPulseGuiding has value: {IsPulseGuiding.HasValue}, Value: {IsPulseGuiding}");
                            break;

                        case nameof(ICameraV4.PercentCompleted):
                            try
                            {
                                PercentCompleted = (short)stateValue.Value;
                            }
                            catch (Exception ex)
                            {
                                TL?.LogMessage(LogLevel.Debug, className, $"PercentCompleted - Ignoring exception: {ex.Message}");
                            }
                            TL?.LogMessage(LogLevel.Debug, className, $"PercentCompleted has value: {PercentCompleted.HasValue}, Value: {PercentCompleted}");
                            break;

                        case "TimeStamp":
                            try
                            {
                                TimeStamp = (DateTime)stateValue.Value;
                            }
                            catch (Exception ex)
                            {
                                TL?.LogMessage(LogLevel.Debug, className, $"TimeStamp - Ignoring exception: {ex.Message}");
                            }
                            TL?.LogMessage(LogLevel.Debug, className, $"TimeStamp has value: {TimeStamp.HasValue}, Value: {TimeStamp}");
                            break;

                        default:
                            TL?.LogMessage(LogLevel.Debug, className, $"Ignoring {stateValue.Name}");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    TL?.LogMessage(LogLevel.Debug, className, $"Exception: {ex.Message}.\r\n{ex}");
                }
            }
        }

        /// <summary>
        /// The device's CameraState
        /// </summary>
        public CameraState? CameraState { get; set; } = null;

        /// <summary>
        /// The device's CCDTemperature
        /// </summary>
        public double? CCDTemperature { get; set; } = null;

        /// <summary>
        /// The device's CoolerPower
        /// </summary>
        public double? CoolerPower { get; set; } = null;

        /// <summary>
        /// The device's HeatSinkTemperature
        /// </summary>
        public double? HeatSinkTemperature { get; set; } = null;

        /// <summary>
        /// The device's ImageReady property
        /// </summary>
        public bool? ImageReady { get; set; } = null;

        /// <summary>
        /// The device's IsPulseGuiding property
        /// </summary>
        public bool? IsPulseGuiding { get; set; } = null;

        /// <summary>
        /// The device's PercentCompleted property
        /// </summary>
        public double? PercentCompleted { get; set; } = null;

        /// <summary>
        /// The time at which the state was recorded
        /// </summary>
        public DateTime? TimeStamp { get; set; } = null;
    }
}
