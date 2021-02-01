using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleAndSql
{
    class Program3
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
        public int UpdateWithSp()
        {
            try
            {
                Console.WriteLine("Enter empId which you have to update");
                var eId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter empName ");
                var eName = Console.ReadLine();
                Console.WriteLine("Enter salary");
                var esal = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter deptNo");
                var dno = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=.;Initial Catalog=WFADotNet;Integrated Security=True");
                cmd = new SqlCommand("sp_UpdateEmp", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@empName", SqlDbType.VarChar, 20).Value = eName;
                cmd.Parameters.Add("@esal", SqlDbType.Float).Value = esal;
                cmd.Parameters.Add("@DeptId", SqlDbType.Int).Value = dno;
                cmd.Parameters.Add("@empId", SqlDbType.Int).Value = eId;
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

        public int InsertWithSp()
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
                cmd = new SqlCommand("sp_InsertEmp", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ename", SqlDbType.VarChar, 20).Value = ename;
                cmd.Parameters.Add("@sal", SqlDbType.Float).Value = esal;
                cmd.Parameters.Add("@dno", SqlDbType.Int).Value = dno;
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

        public int DeleteWithSp()
        {
            try
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Enter EmpId to delete the data of employee ");
                var empId = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source =.; Initial Catalog = WFADotNet; Integrated Security = True");
                cmd = new SqlCommand("Sp_DeleteEmp", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@eId", SqlDbType.Int).Value = empId;
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
    }
    class UsingStoredProcedures
    {
        static void Main()
        {
            Console.WriteLine("Enter 1 to Insert a row with StoredProcedure");
            Console.WriteLine("Enter 2 to Delete a row with StoredProcedure");
            Console.WriteLine("Enter 3 to Update a row with StoredProcedure");
            Console.WriteLine("Enter 4 to Exit");
            Program3 p3 = new Program3();
            int n = Convert.ToInt32(Console.ReadLine());

            switch (n)
            {
                case 1:
                    p3.InsertWithSp();
                    Main();
                    break;

                case 2:
                    p3.DeleteWithSp();
                    Main();
                    break;

                case 3:
                    p3.UpdateWithSp();
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
