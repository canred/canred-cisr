﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IST.DB
{
    public abstract class iTable
    {
        public enum Status
        {
            Defined, Table
        }
        public enum CurrentDataStats { 
            Defined,
            FromTable,
            New,
            Update
        }
        //public Status Stats = Status.Defined;
        public CurrentDataStats DataStatus = CurrentDataStats.Defined;
    }
}
