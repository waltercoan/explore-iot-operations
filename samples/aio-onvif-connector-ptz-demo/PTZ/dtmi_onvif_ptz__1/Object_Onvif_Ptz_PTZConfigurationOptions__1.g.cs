/* Code generated by Azure.Iot.Operations.ProtocolCompiler; DO NOT EDIT. */

#nullable enable

namespace PTZ.dtmi_onvif_ptz__1
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using PTZ;

    public class Object_Onvif_Ptz_PTZConfigurationOptions__1
    {
        /// <summary>
        /// The 'Extension' Field.
        /// </summary>
        [JsonPropertyName("Extension")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Object_PTZConfigurationOptions_Extension? Extension { get; set; } = default;

        /// <summary>
        /// Supported options for PT Direction Control.
        /// </summary>
        [JsonPropertyName("PTControlDirection")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Object_PTZConfigurationOptions_PTControlDirection? PTControlDirection { get; set; } = default;

        /// <summary>
        /// The list of acceleration ramps supported by the device. The smallest acceleration value corresponds to the minimal index, the highest acceleration corresponds to the maximum index.
        /// </summary>
        [JsonPropertyName("PTZRamps")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<int>? PTZRamps { get; set; } = default;

        /// <summary>
        /// A timeout Range within which Timeouts are accepted by the PTZ Node.
        /// </summary>
        [JsonPropertyName("PTZTimeout")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Object_PTZConfigurationOptions_PTZTimeout? PTZTimeout { get; set; } = default;

        /// <summary>
        /// A list of supported coordinate systems including their range limitations.
        /// </summary>
        [JsonPropertyName("Spaces")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Object_Onvif_Ptz_PTZSpaces__1? Spaces { get; set; } = default;

    }
}