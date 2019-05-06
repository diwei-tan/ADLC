using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WebApplication1.Models;
using System.Data;

namespace WebApplication1.DAO
{
    public class TourDAO
    {
        public static void AssignTourLeader(string TourId, string TourLeaderId)
        {
            Tour tour = new Tour();
            string connectionString = "Server=LAPTOP-4CBSFNAO;" + "Database=FSTA;" + "Integrated Security=true";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string cmdtext = @"SELECT * FROM Tour";
                SqlDataAdapter da = new SqlDataAdapter(cmdtext, conn);

                DataSet ds = new DataSet();
                da.Fill(ds, "FSTA");
                DataTable tblTour = ds.Tables[0];

                foreach(DataRow r in tblTour.Rows)
                {
                    if (Convert.ToString(r["Id"]) == TourId)
                    {
                        r["AssignedLeadId"] = int.Parse(TourLeaderId);
                        break;
                    }
                }
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                da.Update(ds, "FSTA");
            }
        }
        public static List<Tour> getTours()
        {
            List<Tour> tours = new List<Tour>();
            Tour temptour;
            string connectionString = "Server=LAPTOP-4CBSFNAO;" + "Database=FSTA;" + "Integrated Security=true";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string cmdtext = @"SELECT * FROM TOUR";
                SqlCommand cmd = new SqlCommand(cmdtext, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    temptour = new Tour();
                    temptour.Id = (int)sdr["Id"];
                    temptour.Destination = (string)sdr["Destination"];
                    temptour.DesCode = (string)sdr["DesCode"];
                    temptour.NumDays = (int)sdr["NumDays"];
                    temptour.StartDate = (DateTime)sdr["StartDate"];
                    temptour.EndDate = (DateTime)sdr["EndDate"];
                    if (DBNull.Value.Equals(sdr["AssignedLeadId"]))
                    {
                        temptour.AssignedLeadId = 0;
                    }
                    else
                    {
                        temptour.AssignedLeadId = (int)sdr["AssignedLeadId"];
                    }
                    tours.Add(temptour);
                }
            }
            return tours;
        }
    }
}