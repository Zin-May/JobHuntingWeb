﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobHunting.Models
{
    public class UserDocument
    {
        public string UserDocumentID { get; set; }
        public string UserID { get; set; }
        public string DocumentName { get; set; }
        public string DocumentType { get; set; }
        public string DocumentURL { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
    }
}