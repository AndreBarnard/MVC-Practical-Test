using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticalTest.Models;
using System.IO;

namespace PracticalTest.Controllers
{
    public class NumberSeriesController : Controller
    {
        // GET: NumberSeries
        [Route("NumberSeries")]
        public ActionResult Index()
        {
            var numberSeries = getNumbers();
            return View(numberSeries);
        }

        private List<NumberSeries> getNumbers()
        {
            List<NumberSeries> numberlist = new List<NumberSeries>();

            string path = $@"{AppDomain.CurrentDomain.BaseDirectory}Files\NumberSeries.txt";

            StreamReader myStreamReader = new StreamReader(path);
            int outNum = 0;
            while (!myStreamReader.EndOfStream)
            {
                string[] Line = myStreamReader.ReadLine().Split(',');
                outNum = sumArray(Line);
                NumberSeries myNumSeries = new NumberSeries();
                myNumSeries.OutNumber = outNum;
                numberlist.Add(myNumSeries);
            }

            numberlist.OrderBy(o => o.OutNumber);
            writeToFile(numberlist);
            return numberlist;
        }

        private int sumArray(string[] line)
        {
            int sum = 0;
            for (int i = 0; i < line.Length; i++)
            {
                int intValue;
                int.TryParse(line[i], out intValue);
                sum += intValue;
            }
            return sum;
        }

        private void writeToFile(List<NumberSeries> numberlist)
        {
            string path = $@"{AppDomain.CurrentDomain.BaseDirectory}Files\NumberSeriesOut.txt";

            System.IO.StreamWriter file = new System.IO.StreamWriter(path);

            foreach (NumberSeries item in numberlist)
            {
                file.WriteLine(item.OutNumber.ToString());
            }

            file.Close();
        }
    }
}
