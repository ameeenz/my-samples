using Driving.Model;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Driving.HUB
{
    public class DreamHub:Hub
    {
        public void InsertData()
        {
            string Result = "";
            using (DataContext context = new DataContext())
            {
                int[] Months = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
                List<int> Counter = new List<int>();
                string Numbers = "[";
                foreach (int item in Months)
                {
                    Counter.Add(context.Visits.Where(it => it.CreateDate.Month == item).Count());
                    Numbers += context.Visits.Where(it => it.CreateDate.Month == item).Count() + ",";
                }
                Numbers = Numbers.TrimEnd(',');
                Numbers += "]";
                Result = Numbers;
            }
            Clients.All.ChangeChart(Result);
        }
    }
}