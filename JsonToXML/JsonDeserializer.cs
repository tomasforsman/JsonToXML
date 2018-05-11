using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace JsonToXML
{
    class JsonDeserializer
    {
        public static Accounts Deserialize(string arg)
        {


            string json = File.ReadAllText(arg).ToString();
            Accounts accounts = JsonConvert.DeserializeObject<Accounts>(json);

            return (accounts);
            
        }

    }
}
