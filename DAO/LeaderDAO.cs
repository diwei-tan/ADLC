using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using System.Data.SqlClient;

namespace WebApplication1.DAO
{
    public class LeaderDAO
    {
        public static bool getLeader(string name, out TourLeader leader)
        {
            bool exist = false;
            leader = null; //initial
            string connectionString = "Server=LAPTOP-4CBSFNAO;" + "Database=FSTA;" + "Integrated Security=true";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string cmdtext = @"SELECT * FROM TourLeader 
                                    LEFT JOIN FullTimeLead ON TourLeader.Id = FullTimeLead.LeadId
                                    LEFT JOIN PartTimeLead ON TourLeader.Id = PartTimeLead.LeadId
                                    WHERE TourLeader.Name = '" + name + "'";
                SqlCommand cmd = new SqlCommand(cmdtext, conn);
                SqlDataReader sdr = cmd.ExecuteReader();

                //Definitely only returns one tour leader, assuming leader name is unique
                if (!sdr.HasRows)
                {
                    return exist;
                }
                else
                {
                    while (sdr.Read())
                    {
                        if ((string)sdr["Role"] == "PT")
                        {
                            PartTimeLead partTimeLead = new PartTimeLead();
                            partTimeLead.Id = (int)sdr["Id"];
                            partTimeLead.Name = (string)sdr["Name"];
                            partTimeLead.Email = (string)sdr["Email"];
                            partTimeLead.Phone = (int)sdr["Phone"];
                            partTimeLead.Role = (string)sdr["Role"];
                            partTimeLead.Salary = (double)sdr["Salary"];
                            leader = partTimeLead;
                        }
                        else
                        {
                            FullTimeLead fullTimeLead = new FullTimeLead();
                            fullTimeLead.Id = (int)sdr["Id"];
                            fullTimeLead.Name = (string)sdr["Name"];
                            fullTimeLead.Email = (string)sdr["Email"];
                            fullTimeLead.Phone = (int)sdr["Phone"];
                            fullTimeLead.Role = (string)sdr["Role"];
                            fullTimeLead.Ranking = (string)sdr["Ranking"];
                            leader = fullTimeLead;
                        }
                    }
                }
            }
            exist = true;
            return exist;
        }
        public static List<TourLeader> getAvailableLeaders(string DesCode)
        {
            List<TourLeader> leaders = new List<TourLeader>();
            string connectionString = "Server=LAPTOP-4CBSFNAO;" + "Database=FSTA;" + "Integrated Security=true";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string cmdtext = @"SELECT * FROM TourLeader
                                    FULL OUTER JOIN FullTimeLead ON TourLeader.Id = FullTimeLead.LeadId
                                    FULL OUTER JOIN PartTimeLead ON TourLeader.Id = PartTimeLead.LeadId
                                    FULL OUTER JOIN DestinationOpted ON PartTimeLead.LeadId = DestinationOpted.PartTimeId
                                    WHERE ROLE = 'FT' OR Destination = '" + DesCode + "'";
                SqlCommand cmd = new SqlCommand(cmdtext, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    if ((string)sdr["Role"] == "PT")
                    {
                        PartTimeLead partTimeLead = new PartTimeLead();
                        partTimeLead.Id = (int)sdr["Id"];
                        partTimeLead.LeadId = (int)sdr["Id"];
                        partTimeLead.Name = (string)sdr["Name"];
                        partTimeLead.Email = (string)sdr["Email"];
                        partTimeLead.Phone = (int)sdr["Phone"];
                        partTimeLead.Role = (string)sdr["Role"];
                        partTimeLead.Salary = (double)sdr["Salary"];
                        leaders.Add(partTimeLead);
                    }
                    else
                    {
                        FullTimeLead fullTimeLead = new FullTimeLead();
                        fullTimeLead.Id = (int)sdr["Id"];
                        fullTimeLead.LeadId = (int)sdr["Id"];
                        fullTimeLead.Name = (string)sdr["Name"];
                        fullTimeLead.Email = (string)sdr["Email"];
                        fullTimeLead.Phone = (int)sdr["Phone"];
                        fullTimeLead.Role = (string)sdr["Role"];
                        fullTimeLead.Ranking = (string)sdr["Ranking"];
                        leaders.Add(fullTimeLead);
                    }
                }
            }
            return leaders;
        }
    }

}