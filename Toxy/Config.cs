using System;
using System.IO;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Toxy
{
    class Config : Dictionary<string, dynamic>
    {
        private Config() { }
        private static Config instance;

        public static Config Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Config();

                    //just filling the config with some default values
                    instance["typing_detection"] = true;
                    instance["enable_encryption"] = false;
                    instance["form_style"] = 3;
                    instance["form_color"] = 2;
                }

                return instance;
            }
        }

        public bool Save(string loc)
        {
            try
            {
                JObject obj = new JObject();

                foreach (string key in Keys)
                    obj.Add(key, this[key]);

                string s = obj.ToString();
                StreamWriter writer = new StreamWriter(loc, false);
                writer.Write(s);
                writer.Close();

                return true;
            }
            catch { return false; }
        }

        public bool Load(string loc)
        {
            try
            {
                StreamReader reader = new StreamReader(loc);
                string conf = reader.ReadToEnd();
                reader.Close();

                JObject obj = (JObject)JsonConvert.DeserializeObject(conf);
                foreach (JProperty prop in obj.Properties())
                {
                    if (!this.ContainsKey(prop.Name))
                        Console.WriteLine("Option {0} is not recognized, ignoring...", prop.Name);
                    else
                        this[prop.Name] = prop.Value.ToObject(this[prop.Name].GetType());
                }

                return true;
            }
            catch { return false; }
        }
    }
}
