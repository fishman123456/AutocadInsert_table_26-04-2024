﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace AutocadInsert_table_26_04_2024
{
    public class Data
    {
        public string Poz { get; set; }
        public string Name { get; set; }
        public string Num { get; set; }
        public string Description { get; set; }

        public Data() { }
        public Data(string poz, string name, string num, string description)
        {
            this.Poz = poz;
            this.Name = name;
            this.Num = num;
            this.Description = description;
        }
        public Data(string poz, string name, string num)
        {
            this.Poz = poz;
            this.Name = name;
            this.Num = num;
            this.Description = "description";
        }
        public Data(string poz, string name)
        {
            this.Poz = poz;
            this.Name = name;
            this.Num = "num";
            this.Description = "description";
        }
        public Data(string poz)
        {
            this.Poz = poz;
            this.Name = "name";
            this.Num = "num";
            this.Description = "description";
        }
        public List<Data> razdel(string str)
        {
            List<Data> listData = new List<Data>();
            string patternNstr = "\n";
            string patternTab = ";";
            string[] strings = Regex.Split(str, patternNstr);
            try
            {
                // перебираем и заполняем пустые строки 06-12-2024
                foreach (string s in strings)
                {
                    string[] stringData = Regex.Split(s, patternTab);
                    Data data = new Data(" "," "," "," ");
                    data.Poz = stringData[0];
                    if (stringData.Length-1 > 1) { data.Name = stringData[1]; }
                    if (stringData.Length-1 > 2) {  data.Num = stringData[2]; }
                    if(stringData.Length- 1 > 3) { data.Description = stringData[3]; }
                    listData.Add(data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не хватает значений в строке" + "\n" + ex.ToString());
                //throw new Exception("Не хватает значений в строке");
            }
            return listData;
        }
    }
}
