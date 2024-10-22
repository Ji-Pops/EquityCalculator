using Microsoft.AspNetCore.Mvc;
using System;
using EquityCalculator.Models;

namespace EquityCalculator.Controllers
{
    [Route("api/[controller]")]
    public class EquityCalculatorController : Controller
    {
        [HttpGet]
        public IActionResult CalculateEquity(decimal sellingPrice, DateTime reservationDate, int equityTerm)
        {
            if (equityTerm <= 0)
            {
                return BadRequest("Equity term must be greater than zero.");
            }

            var startDate = reservationDate.AddMonths(1);
            var monthlyAmount = sellingPrice / equityTerm;
            var balance = sellingPrice;
            var dueDate = startDate;
            var term = 1;

            var equitySchedule = new EquitySchedule();

            while (balance > 0)
            {
                decimal interest = 0.05m * balance;
                decimal insurance = 0.01m * monthlyAmount;
                decimal total = monthlyAmount + interest + insurance;

                decimal paymentAmount = Math.Min(monthlyAmount, balance);
                balance -= paymentAmount;

                var header = new EquitySchedule.Header
                {
                    Balance = Math.Max(balance, 0),
                    Duedate = dueDate.ToString("d"),
                    Term = term
                };

                var paymentInfo = new EquitySchedule.PaymentInfo
                {
                    Amount = paymentAmount,
                    Interest = interest,
                    Insurance = insurance,
                    Total = total
                };

                equitySchedule.MonthlySchedules.Add(new EquitySchedule.MonthlySchedule
                {
                    Header = header,
                    PaymentInfo = paymentInfo
                });

                dueDate = dueDate.AddMonths(1);
                term++;
            }

            return Ok(equitySchedule);
        }

        [HttpGet("calculate")]
        public IActionResult CalculateEquityView()
        {
            return View("CalculateEquity");
        }
    }
}