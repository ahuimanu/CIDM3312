using System.ComponentModel.DataAnnotations;

using VatsimLibrary.VatsimClientV1;

namespace WebApp.Models {
    public class VatsimClientPilotV1BindingTarget {

        [Required]
        public string Cid { get; set; }        

        [Required]
        public string Callsign { get; set; }

        [Required]
        public string Clienttype { get; set; }        

        [Required]
        public string Realname { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }     

        [Required]
        public string Protrevision { get; set; }

        [Required]
        public string Server { get; set; }

        [Required]
        public string TimeLastAtisReceived { get; set; }

        [Required]
        public string TimeLogon { get; set; }


        public VatsimClientPilotV1 ToVatsimClientPilotV1() => new VatsimClientPilotV1() {

            Callsign = this.Callsign,
            Cid = this.Cid,
            Clienttype = this.Clienttype,
            Latitude = this.Latitude,
            Longitude = this.Longitude,
            Protrevision = this.Protrevision,
            Realname = this.Realname,
            Server = this.Server,
            TimeLastAtisReceived = this.TimeLastAtisReceived,
            TimeLogon = this.TimeLogon,
        };
    }
}