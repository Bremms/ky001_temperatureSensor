using Ky001.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ky001
{
    public class Ky001_temperatureSensor
    {
        private string _dev_path = @"/sys/bus/w1/devices/";
        private string _file_name = null;
        private string _regexSearchPattern = @"^[1-9][1-9]-[A-Za-z0-9]*$";
        public Ky001_temperatureSensor()
        {

        }
        public void AutoFetchSensor()
        {
            foreach (var item in Directory.GetDirectories(_dev_path))
            {
                if (Regex.Match(new DirectoryInfo(item).Name, _regexSearchPattern).Success)
                {
                    _file_name = item;
                    return;
                }
            }
        }
        public string SenseRaw()
        {
            if (string.IsNullOrWhiteSpace(_file_name)) throw new Exception("Temperature not found or isn't installed correctly");

            return File.ReadAllText(Path.Combine(Path.Combine(_dev_path, _file_name), "w1_slave"));
        }

        public Temperature Sense()
        {
            var txt = SenseRaw();

            var tempC = double.Parse(txt.Split("t=")[1].Trim()) / 1000;
            return new Temperature(tempC);

        }
    }
}
