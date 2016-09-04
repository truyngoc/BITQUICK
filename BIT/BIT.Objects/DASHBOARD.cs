using System;
using System.Collections.Generic;

namespace BIT.Objects
{
    public class DASHBOARD
    {
        public string CodeId { get; set; }
        public decimal? R_Wallet { get; set; }
        public decimal? C_Wallet { get; set; }
        public decimal? B_Wallet { get; set; }
        public int? PIN_Wallet { get; set; }
        public int? Direct_Downline { get; set; }
        public int? Total_Downline { get; set; }
        public int? Total_PH { get; set; }
        public int? Total_GH { get; set; }
        public int? Total_Downline_Left { get; set; }
        public int? Total_Downline_Right { get; set; }
        public int? Total_GH_Downline_Left { get; set; }
        public int? Total_GH_Downline_Right { get; set; }

    }
}
