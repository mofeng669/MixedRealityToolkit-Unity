﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using UnityEngine;

namespace MixedRealityToolkit.SpatialSound
{
    /// <summary>
    /// Room sizes for the Microsoft Spatial Sound Spatializer.
    /// </summary>
    public enum SpatialSoundRoomSizes
    {
        Small,          // Office to small conference room
        Medium,         // Large conference room
        Large,          // Auditorium
        None            // Similar to being outdoors
    }

    /// <summary>
    /// The SpatialSoundSettings class provides a set of methods that simplify making modifications
    /// to Microsoft Spatial Sound Spatializer parameters.
    /// </summary>
    public static class SpatialSoundSettings
    {
        public const SpatialSoundRoomSizes DefaultSpatialSoundRoom = SpatialSoundRoomSizes.Small;

        // Ranges and default values for the Microsoft Spatial Sound Spatializer parameters.
        // See: <https://msdn.microsoft.com/en-us/library/windows/desktop/mt186602(v=vs.85).aspx>
        // for more details.
        public const float MinimumGainDecibels = -96.0f;
        public const float MaximumGainDecibels = 12.0f;
        public const float MinimumUnityGainDistanceMeters = 0.05f;
        public const float MaximumUnityGainDistanceMeters = float.MaxValue;
        public const float DefaultMinGain = MinimumGainDecibels;
        public const float DefaultMaxGain = MaximumGainDecibels;
        public const float DefaultUnityGainDistance = 1.0f;

        /// <summary>
        /// The available Microsoft Spatial Sound Spatializer parameters.
        /// </summary>
        private enum SpatialSoundParameters
        {
            RoomSize = 1
        }

        /// <summary>
        /// Sets the Spatial Sound room size.
        /// </summary>
        /// <param name="audioSource">The AudioSource on which the room size will be set.</param>
        /// <param name="room">The desired room size.</param>
        public static void SetRoomSize(AudioSource audioSource, SpatialSoundRoomSizes room)
        {
            SetParameter(audioSource, SpatialSoundParameters.RoomSize, (float)room);
        }

        /// <summary>
        /// Sets a Spatial Sound parameter on an AudioSource.
        /// </summary>
        /// <param name="audioSource">The AudioSource on which the specified parameter will be set.</param>
        /// <param name="param">The Spatial Sound parameter to set.</param>
        /// <param name="value">The value to set for the Spatial Sound parameter.</param>
        private static void SetParameter(AudioSource audioSource, SpatialSoundParameters param, float value)
        {
            audioSource.SetSpatializerFloat((int)param, value);
        }
    }
}