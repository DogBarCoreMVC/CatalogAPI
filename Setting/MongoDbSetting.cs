namespace CatelogVS.Setting
{
    public class MongoDbSetting
    {//ประกาศการตั้งค่าจาก MongoDbSetting flie appsettings.json
        public string Host { get; set; }
        public int Port {get; set; }
        public string connectionString 
        {
            get
            {
                return $"mongodb://{Host}:{Port}";
            }
        }
    }
}