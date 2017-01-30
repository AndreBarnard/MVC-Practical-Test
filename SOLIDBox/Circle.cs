using System;
using System.Data.SqlClient;

namespace SOLIDBox
{
    class Circle : Box
    {
        public int Radius { get; set; }

        public override double CalculateArea()
        {
            return Radius * Math.PI;
        }

        public override void Add()
        {
            {
                using (var con = new SqlConnection())
                {
                    con.ConnectionString = $"server={Properties.Settings.Default.ServerName};Trusted_Connection=yes;database={Properties.Settings.Default.Catalog};connection timeout={Properties.Settings.Default.ConnTimeout};APP= PracticalTest;";
                    SqlCommand cmd;

                    cmd = new SqlCommand($"insert into Box (BoxType,Radius,Area) values({_BoxType},{Radius},{CalculateArea()})", con);

                    con?.Dispose();
                    cmd?.Dispose();
                }
            }
        }
    }
}
