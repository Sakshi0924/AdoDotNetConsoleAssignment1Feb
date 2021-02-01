using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace ConsoleAndSql
{
    class Program1
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;

        public int ShowData()
        {
            try
            {

                Console.WriteLine("Data from Table after dml command");
                Console.WriteLine("------------------------------------");
                cn = new SqlConnection("Data Source=.;Initial Catalog=WFADotNet;Integrated Security=True");
                cmd = new SqlCommand("Select * from EmployeeTable", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["EmpId"]}\t{dr["EmpName"]}\t{dr["salary"]}\t{dr["deptno"]}");
                }
                return 1;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }

        }

        public int InsertOneRow()
        {
            try
            {
                Console.WriteLine("Enter Employee name");
                var ename = Console.ReadLine();
                Console.WriteLine("Enter employee salary");
                var esal = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter Employee deptNo");
                var dno = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=.;Initial Catalog=WFADotNet;Integrated Security=True");
                cmd = new SqlCommand("insert into EmployeeTable values('" + ename + "'," + esal + "," + dno + ")", cn);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row added to the table............");
                ShowData();
                return i;


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }

        public int DeleteOneRow()
        {
            try
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Enter EmpId to delete the data of employee ");
                var empId = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source =.; Initial Catalog = WFADotNet; Integrated Security = True");
                cmd = new SqlCommand("delete from EmployeeTable where empId=" + empId + "", cn);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row deleted....");
                ShowData();
                return i;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }

        public int UpdateOneRow()
        {
            try
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Enter empId which you have to update");
                var empId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Employee Name");
                var empName = Console.ReadLine();
                Console.WriteLine("Enter Employee Salary");
                var esal = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter Employee DeptId");
                var deptId = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=.;Initial Catalog=WFADotNet;Integrated Security=True");
                cmd = new SqlCommand("update employeeTable set EmpName='" + empName + "',Salary=" + esal + ",DeptNo="+deptId+" where empId=" + empId + "", cn);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row Updated....");
                ShowData();
                return i;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return 1;
            }
        }
    }
    class WithoutSqlParameters
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1 to Insert one Row ");
            Console.WriteLine("Enter 2 to Delete one Row");
            Console.WriteLine("Enter 3 to Update one Row");
            Console.WriteLine("Enter 4 to exit");
            int n = Convert.ToInt32(Console.ReadLine());
            Program1 p1= new Program1();
            switch (n)
            {
                case 1:
                    p1.InsertOneRow();
                    Main(null);
                    break;
                                        
                case 2:
                    p1.DeleteOneRow();
                    Main(null);
                    break;
                    
                case 3:
                    p1.UpdateOneRow();
                    Main(null);
                    break;
                   
                case 4:
                    Console.WriteLine("Thank you......");
                    break;
                default:
                    Console.WriteLine("Please enter Correct Choice");
                    Main(null);
                    break;
                    

            }
        }
    }
}
