//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BetApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bet
    {
        public int ID { get; set; }
        public int MatchID { get; set; }
        public int UserID { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public int Winner { get; set; }
        public Nullable<int> Points { get; set; }
    }
}
