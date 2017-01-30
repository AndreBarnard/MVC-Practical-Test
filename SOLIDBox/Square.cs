using System.Data.SqlClient;

namespace SOLIDBox
{
    public class Square : Box
    {
        public int Width { get; set; }
        public int Height { get; set; }


        public override double CalculateArea()
        {
            return Width * Height;
        }

        public override void Add()
        {
            {
                using (var con = new SqlConnection())
                {
                    con.ConnectionString = $"server={Properties.Settings.Default.ServerName};Trusted_Connection=yes;database={Properties.Settings.Default.Catalog};connection timeout={Properties.Settings.Default.ConnTimeout};APP= PracticalTest;";
                    SqlCommand cmd;

                    cmd = new SqlCommand($"insert into Box (BoxType,Width,Height,Area) values({_BoxType},{Width},{Height},{CalculateArea()})", con);

                    con?.Dispose();
                    cmd?.Dispose();
                }
            }
        }
    }
}
