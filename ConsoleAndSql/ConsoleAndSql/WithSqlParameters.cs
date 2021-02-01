using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleAndSql
{
    class Program2
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
        public int InsertWithParameters()
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
                cmd = new SqlCommand("insert into EmployeeTable values(@ename,@esal,@Deptno)", cn);
                cmd.Parameters.Add("@ename", SqlDbType.VarChar, 20).Value = ename;
                cmd.Parameters.Add("@esal", SqlDbType.Float).Value = esal;
                cmd.Parameters.Add("@Deptno", SqlDbType.Int).Value = dno;
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

        public int DeleteWithParameters()
        {
            try
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Enter EmpId to delete the data of employee ");
                var empId = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source =.; Initial Catalog = WFADotNet; Integrated Security = True");
                cmd = new SqlCommand("delete from EmployeeTable where empId=@empId", cn);
                cmd.Parameters.Add("@empId", SqlDbType.Int).Value = empId;
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

        public int UpdateWithParameters()
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
                cmd = new SqlCommand("update EmployeeTable set Empname=@ename,Salary=@esal,DeptNo=@dno where EmpId=@eid", cn);
                cmd.Parameters.Add("@eid", SqlDbType.Int).Value = empId;
                cmd.Parameters.Add("@ename", SqlDbType.VarChar, 20).Value = empName;
                cmd.Parameters.Add("@esal", SqlDbType.Float).Value = esal;
                cmd.Parameters.Add("@dno", SqlDbType.Int).Value = deptId;
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row Updated....");
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

    }
    class WithSqlParameters
    {
        static void Main()
        {
            Console.WriteLine("Enter 1 to Insert with SqlParameters");
            Console.WriteLine("Enter 2 to Delete with SqlParameters");
            Console.WriteLine("Enter 3 to Update with SqlParameters");
            Console.WriteLine("Enter 4 to Exit");
            Program2 p2 = new Program2();
            int n = Convert.ToInt32(Console.ReadLine());
            
            switch (n)
            {
                case 1:
                    p2.InsertWithParameters();
                    Main();
                    break;

                case 2:
                    p2.DeleteWithParameters();
                    Main();
                    break;

                case 3:
                    p2.UpdateWithParameters();
                    Main();
                    break;

                case 4:
                    Console.WriteLine("Thank you......");
                    break;
                default:
                    Console.WriteLine("Please enter Correct Choice");
                    Main();
                    break;
            }
        }
    }
}
