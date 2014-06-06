using Microsoft.WindowsAzure.Mobile.Service;
using System;

namespace littleleagueService.DataObjects
{
    public class Activity : EntityData
    {
        public string ActivityName { get; set; }

        public DateTime Date { get; set; }

        public User Player1 { get; set; }
        public User Player2 { get; set; }

        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
    }
}