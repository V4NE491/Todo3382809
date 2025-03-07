﻿using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo3382809.Models
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string? Name { get; set; }    
        public string? Notes { get; set; } 
        public bool Done { get; set; }
    }
}
