﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarrel.Gateway.DownstreamEvents
{
    public class MessageDelete
    {
        [JsonProperty("id")]
        public string MessageId { get; set; }
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }
    }
}
