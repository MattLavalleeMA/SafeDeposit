// Copyright (c) Matt Lavallee
// Licensed under the MIT License.
// See License.txt in the project root for more license information.

using System;
using System.IO;
using CommandLine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SafeDeposit.Extensions;
using SafeDeposit.Options;

namespace SafeDeposit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ParserResult<object> result = Parser.Default.ParseArguments<PushOptions, PullOptions>(args);

            Console.WriteLine(JsonConvert.SerializeObject(result));

            using (StreamReader r = new StreamReader("C:\\Users\\mlavallee\\AppData\\Roaming\\Microsoft\\UserSecrets\\f1303aa4-8bfc-4f03-aa57-2d496f845351\\secrets.json"))
            {
                string json = r.ReadToEnd();
                var result2 = JToken.Parse(json);

                foreach (var val in result2.GetLeafValues())
                {
                    Console.WriteLine($"{val.Path} = {val.Value}");
                }
            }
        }
    }
}
