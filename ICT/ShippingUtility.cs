using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ShippingManagement        //DO NOT change the namespace name
{
    public class ShippingUtility    //DO NOT change the class name
    {
        //Implement code here
        public void InsertShippingDetails(ShippingDetails shippingdetailsobj)
        {
            DBConnection db = new DBConnection();
            using (SqlConnection con = db.GetConnection())
            {
                string query = "Insert into shipping(ShippingId,StartLocation,EndLocation,Distance,StartDate,DeliveryDate,Priority) values(@id,@slocation,@elocation,@distance,@sdate,@ddate,@priority)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", shippingdetailsobj.ShippingId);
                cmd.Parameters.AddWithValue("@slocation", shippingdetailsobj.StartLocation);
                cmd.Parameters.AddWithValue("@elocation", shippingdetailsobj.EndLocation);
                cmd.Parameters.AddWithValue("@distance", shippingdetailsobj.Distance);
                cmd.Parameters.AddWithValue("@sdate", shippingdetailsobj.StartDate);
                cmd.Parameters.AddWithValue("@ddate", shippingdetailsobj.DeliveryDate);
                cmd.Parameters.AddWithValue("@priority", shippingdetailsobj.Priority);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Console.WriteLine("Details Added Successfully");
                }
                con.Close();
            }
        }

        public ShippingDetails GetShippingDetailsByShippingId(int shippingId)
        {
            DBConnection db = new DBConnection();
            ShippingDetails obj = new ShippingDetails();
            using (SqlConnection con = db.GetConnection())
            {
                con.Open();
                string query = "Select * from Shipping where ShippingId = " + shippingId;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    obj.ShippingId = (int)reader[0];
                    obj.StartLocation = reader[1].ToString();
                    obj.EndLocation = reader[2].ToString();
                    obj.Distance = (int)reader[3];
                    obj.StartDate = Convert.ToDateTime(reader[4].ToString());
                    obj.DeliveryDate = Convert.ToDateTime(reader[5].ToString());
                    obj.Priority = reader[6].ToString();
                }
                con.Close();
            }
            return obj;
        }

        public double CalculateShippingCharges(int weight, int distance, string priority)
        {
            double charges = 0;
            double percentage = 0;
            if (priority.Equals("High"))
                percentage = 0.2;
            else if (priority.Equals("Medium"))
                percentage = 0.1;

else
                percentage = 0;
            if (weight <= 50)
            {
                if (distance <= 100)
                {
                    charges = 200 + 200 * percentage;
                }
                else if (distance > 100 && distance <= 350)
                {
                    charges = 400 + 400 * percentage;
                }
                else
                {
                    charges = 700 + 700 * percentage;
                }
            }
            else if (weight > 50 && weight <= 100)
            {
                if (distance <= 100)
                {
                    charges = 300 + 300 * percentage;
                }
                else if (distance > 100 && distance <= 350)
                {
                    charges = 600 + 600 * percentage;
                }
                else
                {
                    charges = 1050 + 1050 * percentage;
                }
            }
            else if (weight > 100 && weight <= 500)
            {
                if (distance <= 100)
                {
                    charges = 500 + 500 * percentage;
                }
                else if (distance > 100 && distance <= 350)
                {
                    charges = 1000 + 1000 * percentage;
                }
                else
                {
                    charges = 1750 + 1750 * percentage;
                }
            }
            else
            {
                if (distance <= 100)
                {
                    charges = 600 + 600 * percentage;
                }
                else if (distance > 100 && distance <= 350)
                {
                    charges = 1200 + 1200 * percentage;
                }
                else
                {
                    charges = 2100 + 2100 * percentage;
                }
            }
            return charges;
        }
    }

}
