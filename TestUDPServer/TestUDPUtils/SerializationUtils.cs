using System;
using System.IO;

namespace TestUDPUtils
{
    public static class SerializationUtils
    {
        public static byte[] ToByteArray<T>(T obj)
        {
            if(obj == null)
                return null;
            
            using(var ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public static T FromByteArray<T>(byte[] data)
        {
            if(data == null)
                return default(T);
            
            using(var ms = new MemoryStream(data))
            {
                return ProtoBuf.Serializer.Deserialize<T>(ms);
            }
        }
    }
}