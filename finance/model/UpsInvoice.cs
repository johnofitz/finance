﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace finance
{

    public class UpsInvoice
    {
        public string InvoiceDownLoadDate { get; set; }

        public string DeliveryDate { get; set; }
        public string? InvoiceNumber { get; set; }
        public int JobNumber { get; set; }
        public string? Parcels { get; set; }
        public string? BaseRate { get; set; }
    }

}