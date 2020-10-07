using System;

namespace VatsimLibrary
{
    public class VatsimClientRecord
    {

        public static readonly char FIELD_DELIMITER = ':';

        // callsign:
        public static readonly int CALLSIGN_INDEX = 0;
        // cid:
        public static readonly int CID_INDEX = 1;
        // realname:
        public static readonly int REALNAME_INDEX = 2;
        // clienttype:
        public static readonly int CLIENTTYPE_INDEX = 3;
        // frequency:
        public static readonly int FREQUENCY_INDEX = 4;
        // latitude:
        public static readonly int LATITUDE_INDEX = 5;
        // longitude:
        public static readonly int LONGITUDE_INDEX = 6;
        // altitude:
        public static readonly int ALTITUDE_INDEX = 7;
        // groundspeed:
        public static readonly int GROUNDSPEED_INDEX = 8;
        // planned_aircraft:
        public static readonly int PLANNED_AIRCRAFT_INDEX = 9;
        // planned_tascruise:
        public static readonly int PLANNED_TASCRUISE_INDEX = 10;
        // planned_depairport:
        public static readonly int PLANNED_DEPAIRPORT_INDEX = 11;
        // planned_altitude:
        public static readonly int PLANNED_ALTITUDE_INDEX = 12;
        // planned_destairport:
        public static readonly int PLANNED_DESTAIRPORT_INDEX = 13;
        // server:
        public static readonly int SERVER_INDEX = 14;
        // protrevision:
        public static readonly int PROTREVISION_INDEX = 15;
        // rating:
        public static readonly int RATING_INDEX = 16;
        // transponder:
        public static readonly int TRANSPONDER_INDEX = 17;
        // facilitytype:
        public static readonly int FACILITYTYPE_INDEX = 18;
        // visualrange:
        public static readonly int VISUALRANGE_INDEX = 19;
        // planned_revision:
        public static readonly int PLANNED_REVISION_INDEX = 20;
        // planned_flighttype:
        public static readonly int PLANNED_FLIGHTTYPE_INDEX = 21;
        // planned_deptime:
        public static readonly int PLANNED_DEPTIME_INDEX = 22;
        // planned_actdeptime:
        public static readonly int PLANNED_ACTDEPTIME_INDEX = 23;
        // planned_hrsenroute:
        public static readonly int PLANNED_HRSENROUTE_INDEX = 24;
        // planned_minenroute:
        public static readonly int PLANNED_MINENROUTE_INDEX = 25;
        // planned_hrsfuel:
        public static readonly int PLANNED_HRSFUEL_INDEX = 26;
        // planned_minfuel:
        public static readonly int PLANNED_MINFUEL_INDEX = 27;
        // planned_altairport:
        public static readonly int PLANNED_ALTAIRPORT_INDEX = 28;
        // planned_remarks:
        public static readonly int PLANNED_REMARKS_INDEX = 29;
        // planned_route:
        public static readonly int PLANNED_ROUTE_INDEX = 30;
        // planned_depairport_lat:
        public static readonly int PLANNED_DEPAIRPORT_LAT_INDEX = 31;
        // planned_depairport_lon:
        public static readonly int PLANNED_DEPAIRPORT_LON_INDEX = 32;
        // planned_destairport_lat:
        public static readonly int PLANNED_DESTPAIRPORT_LAT_INDEX = 33;
        // planned_destairport_lon:
        public static readonly int PLANNED_DESTAIRPORT_LON_INDEX = 34;
        // atis_message:
        public static readonly int ATIS_MESSAGE_INDEX = 35;
        // time_last_atis_received:
        public static readonly int TIME_LAST_ATIS_RECEIVED_INDEX = 36;
        // time_logon:
        public static readonly int TIME_LOGON_INDEX = 37;
        // heading:
        // QNH_iHg:
        // QNH_Mb:        

        /* Sample fields and data */
        /*
        callsign:DLH1988:
        cid:1306122:
        realname:Thales Toledo SBST:
        clienttype:PILOT:
        frequency::
        latitude:-21.38394:
        longitude:-41.93211:
        altitude:37716:
        groundspeed:307:
        planned_aircraft:H/B78X/L:
        planned_tascruise:445:
        planned_depairport:EDDF:
        planned_altitude:38000:
        planned_destairport:SBGL:
        server:GERMANY-1:
        protrevision:100:
        rating:1:
        transponder:3436:
        facilitytype:0:
        visualrange:0:
        planned_revision:2:
        planned_flighttype:I:
        planned_deptime:201:
        planned_actdeptime:0:
        planned_hrsenroute:11:
        planned_minenroute:17:
        planned_hrsfuel:13:
        planned_minfuel:33:
        planned_altairport:SBGR:
        planned_remarks:PBN/A1B1C1D1L1O1S2 DOF/201007 REG/DAIHC EET/EDUU0013 LSAS0022 LFFF0035 LECM0121 GMMM0226 GCCC0322 GOOO0455 GVSC0500 GOOO0548 SBAO0713 SBRE0806 SBCW1035 OPR/DLH PER/D RMK/TCAS SIMBRIEF /v/:
        planned_route:ANEKI9F ANEKI Y163 HERBI Y164 MOPAN/N0471F310 Y164 OLBEN/N0492F350 UN869 ZAR UZ245 CJN/N0487F370 UN10 SVL UN857 DEREV/N0488F380 UN857 ERETU/N0484F400 UN857 MOLSU UTBOM2A:
        planned_depairport_lat:0:
        planned_depairport_lon:0:
        planned_destairport_lat:0:
        planned_destairport_lon:0:
        atis_message::
        time_last_atis_received:20201007021853:
        time_logon:20201007021853:
        heading:209:
        QNH_iHg:29.94:
        QNH_Mb:1014:
        */

        public string Callsign { get; set; }
        public string Cid { get; set; }
        public string Realname { get; set; }
        public string Clienttype { get; set; }
        public string Frequency { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Altitude { get; set; }
        public string Groundspeed { get; set; }
        public string PlannedAircraft { get; set; }
        public string PlannedTascruise { get; set; }
        public string PlannedDepairport { get; set; }
        public string PlannedAltitude { get; set; }
        public string PlannedDestairport { get; set; }
        public string Server { get; set; }
        public string Protrevision { get; set; }
        public string Rating { get; set; }
        public string Transponder { get; set; }
        public string Facilitytype { get; set; }
        public string Visualrange { get; set; }
        public string PlannedRevision { get; set; }
        public string PlannedFlighttype { get; set; }
        public string PlannedDeptime { get; set; }
        public string PlannedActdeptime { get; set; }
        public string PlannedHrsenroute { get; set; }
        public string PlannedMinenroute { get; set; }
        public string PlannedHrsfuel { get; set; }
        public string PlannedMinfuel { get; set; }
        public string PlannedAltairport { get; set; }
        public string PlannedRemarks { get; set; }
        public string PlannedRoute { get; set; }
        public string PlannedDepairportLat { get; set; }
        public string PlannedDepairportLon { get; set; }
        public string PlannedDestairportLat { get; set; }
        public string PlannedDestairportLon { get; set; }
        public string AtisMessage { get; set; }
        public string TimeLastAtisReceived { get; set; }
        public string TimeLogon { get; set; }
        public string Heading { get; set; }
        public string QNH_iHg { get; set; }
        public string QNH_Mb { get; set; }

        public static VatsimClientRecord GetVatsimClientRecord(string line)
        {

            VatsimClientRecord record = new VatsimClientRecord();

            string[] parts = line.Split(FIELD_DELIMITER);

            // callsign
            record.Callsign = parts[0];
            // cid
            record.Cid = parts[1];
            // realname
            record.Realname = parts[2];
            // clienttype
            record.Clienttype = parts[3];
            // frequency
            record.Frequency = parts[4];
            // latitude
            record.Latitude = parts[5];
            // longitude
            record.Longitude = parts[6];
            // altitude
            record.Altitude = parts[7];
            // groundspeed
            record.Groundspeed = parts[8];
            // planned_aircraft
            record.PlannedAircraft = parts[9];
            // planned_tascruise
            record.PlannedTascruise = parts[10];
            // planned_depairport
            record.PlannedDepairport = parts[11];
            // planned_altitude
            record.PlannedAltitude = parts[12];
            // planned_destairport
            record.PlannedDepairport = parts[13];
            // server
            record.Server = parts[14];
            // protrevision
            record.Protrevision = parts[15];
            // rating
            record.Rating = parts[16];
            // transponder
            record.Transponder = parts[17];
            // facilitytype
            record.Facilitytype = parts[18];
            // visualrange
            record.Visualrange = parts[19];
            // planned_revision
            record.PlannedRevision = parts[20];
            // planned_flighttype
            record.PlannedFlighttype = parts[21];
            // planned_deptime
            record.PlannedDeptime = parts[22];
            // planned_actdeptime
            record.PlannedActdeptime = parts[23];
            // planned_hrsenroute
            record.PlannedHrsenroute = parts[24];
            // planned_minenroute
            record.PlannedMinenroute = parts[25];
            // planned_hrsfuel
            record.PlannedHrsfuel = parts[26];
            // planned_minfuel
            // planned_altairport
            // planned_remarks
            // planned_route
            // planned_depairport_lat
            // planned_depairport_lon
            // planned_destairport_lat
            // planned_destairport_lon
            // atis_message
            // time_last_atis_received
            // time_logon
            // heading
            // QNH_iHg
            // QNH_Mb


            return null;
        }
    }
}
