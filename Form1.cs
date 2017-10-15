using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace NeosuranceWageFilegenerator
{
    public partial class Form1 : Form
    {
        busEmployerAgentWageFileGenerator objWageFileGenerator = new busEmployerAgentWageFileGenerator();

        static busAgentFileDataItems objAgentFileDataItems;

        public SqlConnection connection { get; set; }

        public SqlDataReader reader { get; set; }

        public Boolean dataExist { get; set; }

        public String FName { get; set; }

        public String DatabaseName { get; set; }

        public String DatabaseName1 { get; set; }

        public String DBConnectionString { get; set; }

        public const String MDSYSRGN = "Maryland System Test";
        public const String MDUATRGN = "Maryland UAT";
        public const String MDPRFRGN = "Maryland Performance";

        public const String WVSYSRGN = "West Virginia System Test";
        public const String WVUATRGN = "West Virginia UAT";
        public const String WVPRFRGN = "West Virginia Performance";


        public Form1()
        {
            InitializeComponent();
        }

        private void InitiliazeDataConnection()
        {
            switch (DatabaseName)
            {
                case MDSYSRGN:
                    DBConnectionString = "Data Source=UIMMD-NP-SQL01.UIMMDTEST.LOCAL;User ID=devuser;password=Sagitec11;Initial Catalog=UIM-MD-SYSTEST-DB;TimeOut=120;Max Pool Size = 3000;Persist Security Info=True;Asynchronous Processing=True;";
                    break;
                case MDUATRGN:
                    DBConnectionString = "Data Source=UIMMD-NP-SQL01.UIMMDTEST.LOCAL;User ID=devuser;password=Sagitec11;Initial Catalog=UIM-MD-UAT-DB;TimeOut=120;Max Pool Size = 3000;Persist Security Info=True;Asynchronous Processing=True;";
                    break;
                case MDPRFRGN:
                    DBConnectionString = "Data Source=UIMMD-NP-SQL02.UIMMDTEST.LOCAL;User ID=devuser;password=devuser123;Initial Catalog=UIM-MD-PERFTEST-DB;TimeOut=120;Max Pool Size = 3000;Persist Security Info=True;Asynchronous Processing=True;";
                    break;
                case WVSYSRGN:
                    DBConnectionString = "Data Source=UIMWV-NP-SQL01.UIMWVTEST.LOCAL;User ID=devuser;password=Sagitec11;Initial Catalog=UIM-WV-SYSTEST-DB;TimeOut=120;Max Pool Size = 3000;Persist Security Info=True;Asynchronous Processing=True;";
                    break;
                case WVUATRGN:
                    DBConnectionString = "Data Source=UIMWV-NP-SQL01.UIMWVTEST.LOCAL;User ID=devuser;password=Sagitec11;Initial Catalog=UIM-WV-UAT-DB;TimeOut=120;Max Pool Size = 3000;Persist Security Info=True;Asynchronous Processing=True;";
                    break;
                case WVPRFRGN:
                    DBConnectionString = "Data Source=UIMWV-NP-SQL02.UIMWVTEST.LOCAL;User ID=devuser;password=Sagitec11;Initial Catalog=UIM-WV-PERFTEST-DB;TimeOut=120;Max Pool Size = 3000;Persist Security Info=True;Asynchronous Processing=True;";
                    break;
                default:
  
                    break;
            }
            // 1. Instantiate the connection
            connection = new SqlConnection(DBConnectionString);
            reader = null;
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string[] strArr;
            InitiliazeDataConnection();
            connection.Open();
            objWageFileGenerator.iclbAgentFileData = new Stack<busAgentFileDataItems>();
            int i = 0, j = 0;
            // 1. Check if file is present and is not empty
            foreach (string line in File.ReadLines(FName))
            {
                if (i == 0)
                {
                    strArr = line.Split(',');
                    // 2. Check if first element matches one of the predefined file types
                    // 3. Check if second element matches one of the predefined user types (employer/agent)
                    objWageFileGenerator.istrFileType = strArr[0].ToUpper();
                    objWageFileGenerator.istrUserType = strArr[1].ToLower();
                        Array.Clear(strArr, 0, strArr.Length);
                        i++;
                }
                else if (objWageFileGenerator.istrUserType == "employer")
                {
                    // 4. Validate all the data.
                    strArr = line.Split(',');
                    objWageFileGenerator.iintEAN = strArr[0];
                    objWageFileGenerator.istrFEIN = strArr[1];
                    objWageFileGenerator.istrReportQuarter = strArr[2];
                    objWageFileGenerator.istrReportYear = strArr[3];
                    objWageFileGenerator.istrSSNCount = strArr[4];
                    dataExist = true;
                    using (SqlCommand command = new SqlCommand(
                            "select  employer_account_id, fein " +
                            "from sgt_employer where employer_account_id = @ean", connection))
                    {
                        //connection.Open();
                        command.Parameters.Add(new SqlParameter("ean", objWageFileGenerator.iintEAN));
                        reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if ((reader.GetInt32(0) != Int32.Parse(objWageFileGenerator.iintEAN)) || (reader.GetString(1) != objWageFileGenerator.istrFEIN))
                                {
                                    MessageBox.Show(objWageFileGenerator.iintEAN + " does not exist in the database");
                                    dataExist = false;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(objWageFileGenerator.iintEAN + " does not exist in the database");
                            dataExist = false;
                        }
                        reader.Close();
                    }
                    if (dataExist == true)
                    {
                        objWageFileGenerator.GenerateFile();
                        Thread.Sleep(2000);

                        Array.Clear(strArr, 0, strArr.Length);
                    }
                    else
                    {
                        dataExist = true;
                    }
                }
                else if (objWageFileGenerator.istrUserType == "agent")
                {
                    if (j == 0)
                    {
                        strArr = line.Split(',');
                        objWageFileGenerator.istrAgentFEIN = strArr[0];
                        objWageFileGenerator.istrEANCount = strArr[1];
                        Int32.TryParse(objWageFileGenerator.istrEANCount, out j);
                    }
                    else if (j > 0)
                    {
                        objAgentFileDataItems = new busAgentFileDataItems();
                        strArr = line.Split(',');
                        objAgentFileDataItems.istrEAN = strArr[0];
                        objAgentFileDataItems.istrReportQuarter = strArr[1];
                        objAgentFileDataItems.istrReportYear = strArr[2];
                        objAgentFileDataItems.istrSSNCounts = strArr[3];
                        objWageFileGenerator.iclbAgentFileData.Push(objAgentFileDataItems);
                        Array.Clear(strArr, 0, strArr.Length);
                        if (j == 1)
                        {
                            objWageFileGenerator.GenerateFile();
                            Thread.Sleep(2000);
                        }
                        j--;

                    }
                }
            }
            MessageBox.Show("Done");
            connection.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog() { Filter = "CSV files|*.csv", ValidateNames = true };
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FName = openFileDialog1.FileName;
                this.textBox1.Text = FName;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //this.textBox1.Text = FName;
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseName = comboBox1.Text.ToString();
            DatabaseName += " UAT";
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
    
}
