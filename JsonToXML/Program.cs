/*
MIT License

Copyright (c) 2018 tomasforsman

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
*/

using Newtonsoft.Json;
using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace JsonToXML
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Accounts accounts = new Accounts();
                JObject ot = new JObject();
                JObject o = new JObject();
                string saveName = "";
                for (int i = 0; i < args.Length; i++)
                {
                    AddJson(args, ref ot, o, i);
                    saveName = saveName + SaveName(args, i);
                }
                accounts = JsonConvert.DeserializeObject<Accounts>(o.ToString());
                accounts.SaveXML(saveName + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml");

            }

            catch (Exception ex)
            {
                Console.Write(ex.Message.ToString());
                Environment.Exit(1);
            }
        }

        private static string SaveName(string[] args, int i)
        {
            return args[i].Replace(".json", "_");
        }

        private static void AddJson(string[] args, ref JObject ot, JObject o, int i)
        {
                ot = JObject.Parse(File.ReadAllText(args[i]));
                o.Merge(ot, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Union });
        }
    }
}