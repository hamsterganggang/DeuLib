﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_support_system.Model
{
    public class UserModel
    {
        #region Properties
        public string User_Phone { get; set; }
        public string User_Name { get; set; }
        public string User_Birthdate { get; set; }
        public int User_Gender { get; set; } = 0;
        public string User_Mail { get; set; }
        public string User_Image { get; set; }
        public int User_WithDR { get; set; } = 1;
        #endregion
    }
}
