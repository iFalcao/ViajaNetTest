using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common.Helpers
{
    public static class ObjectUtils
    {
        // Convert an object to a byte array
        public static byte[] ObjectToByteArray(this Object obj)
        {
            if (obj == null)
                return null;

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, obj);
                return memoryStream.ToArray();
            }
        }

        // Convert a byte array to an Object
        public static T ByteArrayToObject<T>(this byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                return (T)binaryFormatter.Deserialize(memStream);
            }
        }
    }
}
