using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Runtime.Serialization;

namespace Serialisation
{

    public class JsonHelper
    {
        public static string Serialize<MyTypeOf>(MyTypeOf obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(MyTypeOf));
                serializer.WriteObject(stream, obj);
                return Encoding.Default.GetString(stream.ToArray());
            }
        }

        public static MyTypeOf Deserialize<MyTypeOf>(string p_sJson)
        {
            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(p_sJson)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(MyTypeOf));
                return (MyTypeOf)serializer.ReadObject(stream);
            }
        }

        public static MyTypeOf Deserialize<MyTypeOf>(ref Stream p_oJson)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(MyTypeOf));
            return (MyTypeOf)serializer.ReadObject(p_oJson);
        }

    }

}