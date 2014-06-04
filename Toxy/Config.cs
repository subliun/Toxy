using System;
using System.IO;
using System.Collections.Generic;
using System.Dynamic;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

using SharpTox;

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
                    instance["form_style"] = 1;
                    instance["form_color"] = 3;
                    instance["close_to_tray"] = false;

                    instance["device_output"] = 0;
                    instance["device_input"] = 0;

                    /* check https://wiki.tox.im/Nodes for a list of up-to-date nodes */
                    instance["nodes"] = new ToxNode[] {
                        new ToxNode("192.254.75.98", 33445, "951C88B7E75C867418ACDB5D273821372BB5BD652740BCDF623A4FA293E75D2F", false),
                        new ToxNode("37.187.46.132", 33445, "A9D98212B3F972BD11DA52BEB0658C326FCCC1BFD49F347F9C2D3D8B61E1B927", false),
                        new ToxNode("54.199.139.199", 33445, "7F9C31FE850E97CEFD4C4591DF93FC757C7C12549DDD55F8EEAECC34FE76C029", false)
                    };
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
                {
                    if (this[key].GetType() == typeof(ToxNode[]))
                    {
                        dynamic[] nodes = new dynamic[this[key].Length];

                        for (int i = 0; i < this[key].Length; i++)
                        {
                            dynamic node = new ExpandoObject();
                            node.address = this[key][i].Address;
                            node.port = this[key][i].Port;
                            node.ipv6_enabled = this[key][i].Ipv6Enabled;
                            node.public_key = this[key][i].PublicKey;

                            nodes[i] = node;
                        }

                        obj.Add(key, JToken.FromObject(nodes));
                    }
                    else
                    {
                        obj.Add(key, this[key]);
                    }
                }

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
