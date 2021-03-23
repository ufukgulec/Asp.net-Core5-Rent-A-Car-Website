using System;
using System.Runtime.Serialization;

namespace CoreAracKiralama.Areas.AdminPaneli.Models
{
    [DataContract]

    public class Point
    {
        [DataMember(Name = "label")]
        public string Brands { get; set; }

        [DataMember(Name = "y")]
        public Nullable<int> VehicleCount { get; set; }
    }

}
