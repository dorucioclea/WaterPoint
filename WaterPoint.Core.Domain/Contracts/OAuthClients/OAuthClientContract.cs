﻿using System;

namespace WaterPoint.Core.Domain.Contracts.OAuthClients
{
    public class OAuthClientContract : IContract
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Name { get; set; }
        public bool IsInternal { get; set; }
        public string Version { get; set; }
        public Guid Uid { get; set; }
        public DateTime UtcCreated { get; set; }
    }
}
