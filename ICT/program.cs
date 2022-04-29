using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingManagement //DO NOT change the namespace name
{
    public class Program    //DO NOT change the class name
    {
        public static void Main(string[] args)  //DO NOT change the 'Main' method signature
        {
            //Implement code here
            bool flag = true;
            while (flag)
            {
                int option;
                Console.WriteLine("1.Add shipping details");
                Console.WriteLine("2.Get shipping details by shipping id");
                Console.WriteLine("3.Calculate shipping charges");
                Console.WriteLine("4.Exit");
                option = Convert.ToInt32(Console.ReadLine());
                if (option == 1)
                {
                    Console.WriteLine("Enter shipping id");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter start location");
                    string slocation = Console.ReadLine();
                    Console.WriteLine("Enter end location");
                    string elocation = Console.ReadLine();
                    Console.WriteLine("Enter distance");
                    int distance = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter start date");
                    DateTime sdate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                    Console.WriteLine("Enter end date");
                    DateTime ddate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                    Console.WriteLine("Enter priority");
                    string priority = Console.ReadLine();
                    ShippingDetails obj = new ShippingDetails(id, slocation, elocation, distance, sdate, ddate, priority);
                    ShippingUtility suObj = new ShippingUtility();
                    suObj.InsertShippingDetails(obj);
                }
                else if (option == 2)
                {
                    ShippingUtility suObj = new ShippingUtility();
                    ShippingDetails obj = new ShippingDetails();
                    Console.WriteLine("Enter shipping id");
                    int id = Convert.ToInt32(Console.ReadLine());
                    obj = suObj.GetShippingDetailsByShippingId(id);
                    Console.WriteLine("ShippingId\tStartLocation\tEndLocation\tDistance\tStartDate\tDeliveryDate\tPriority");
                    Console.WriteLine(obj.ShippingId + "\t" + obj.StartLocation + "\t" + obj.EndLocation + "\t" + obj.Distance + "\t" + obj.StartDate + "\t" + obj.DeliveryDate + "\t" + obj.Priority);
                }
                else if (option == 3)
                {
                    Console.WriteLine("Enter weight");
                    int weight = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter distance");
                    int distance = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter priority");
                    string priority = Console.ReadLine();
                    ShippingUtility suObj = new ShippingUtility();
                    double charges = suObj.CalculateShippingCharges(weight, distance, priority);
                    Console.WriteLine("Shipping charges : " + charges);

                }
                else
                {
                    flag = false;
                }
            }

        }
    }

}
