
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    public static class BinarySerializer
    {
        public static void Serialize(string _path, object _data)
        {
            using (FileStream _stream = new FileStream(_path, FileMode.OpenOrCreate))
            {
                BinaryFormatter _formatter = new BinaryFormatter();
                _formatter.Serialize(_stream, _data);
            }
        }

        public static T Deserialize<T>(string _path)
        {
            using (FileStream _stream = new FileStream(_path, FileMode.Open))
            {
                BinaryFormatter _formatter = new BinaryFormatter();
                T _data = (T) _formatter.Deserialize(_stream);
                return _data;
            }
        }
        
    }