using PracticalTest.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PracticalTest.Controllers
{
    public class PascalTrianglesController : Controller
    {
        // GET: PascalTriangles
        public ActionResult Index()
        {
            var PascalRows = getPascalTriangels(5);
            return View(PascalRows);
        }

        private List<PascalTriangles> getPascalTriangels(int rows)
        {
            List<PascalTriangles> myPascalTriangel = new List<PascalTriangles>();

            int pascalValue = 1;
            List<int> pascalValues = new List<int>();
            PascalTriangles pascalTriangle = new PascalTriangles();

            pascalValues.Add(pascalValue);
            pascalTriangle.PascalRows = pascalValues;
            myPascalTriangel.Add(pascalTriangle);

            for (int y = 1; y < rows; y++)
            {
                pascalValues = new List<int>();
                pascalTriangle = new PascalTriangles();
                for (int x = 0; x <= y; x++)
                {
                    pascalValue = pascal(y, x);
                    pascalValues.Add(pascalValue);
                }
                pascalTriangle.PascalRows = pascalValues;
                myPascalTriangel.Add(pascalTriangle);

            }

            return myPascalTriangel;
        }

        public int pascal(int row, int col)
        {
            if (col == 0 || col == row)
            {
                int value = 1;
                return value;
            }
            else
            {
                int value = pascal(row - 1, col - 1) + pascal(row - 1, col);
                return value;
            }
        }

    }
}
