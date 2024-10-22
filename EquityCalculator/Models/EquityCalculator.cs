using System;
using System.Collections.Generic;

namespace EquityCalculator.Models
{
    public class EquitySchedule
    {
        public class Header
        {
            public decimal Balance { get; set; }
            public string Duedate { get; set; }
            public int Term { get; set; }
        }

        public class PaymentInfo
        {
            public decimal Amount { get; set; }
            public decimal Interest { get; set; }
            public decimal Insurance { get; set; }
            public decimal Total { get; set; }
        }

        public class MonthlySchedule
        {
            public Header Header { get; set; }
            public PaymentInfo PaymentInfo { get; set; }
        }

        public List<MonthlySchedule> MonthlySchedules { get; set; } = new List<MonthlySchedule>();
    }
}