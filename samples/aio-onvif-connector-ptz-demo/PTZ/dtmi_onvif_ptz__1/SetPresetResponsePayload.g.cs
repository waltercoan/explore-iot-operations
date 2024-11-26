/* Code generated by Azure.Iot.Operations.ProtocolCompiler; DO NOT EDIT. */

#nullable enable

namespace PTZ.dtmi_onvif_ptz__1
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using PTZ;

    public class SetPresetResponsePayload : IJsonOnDeserialized, IJsonOnSerializing
    {
        /// <summary>
        /// The Command response argument.
        /// </summary>
        [JsonPropertyName("SetPresetResponse")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        [JsonRequired]
        public Object_Onvif_Ptz_SetPresetResponse__1 SetPresetResponse { get; set; } = default!;

        void IJsonOnDeserialized.OnDeserialized()
        {
            if (SetPresetResponse is null)
            {
                throw new ArgumentNullException("SetPresetResponse field cannot be null");
            }
        }

        void IJsonOnSerializing.OnSerializing()
        {
            if (SetPresetResponse is null)
            {
                throw new ArgumentNullException("SetPresetResponse field cannot be null");
            }
        }
    }
}