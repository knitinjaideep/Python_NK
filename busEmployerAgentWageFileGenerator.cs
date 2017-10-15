using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;

using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace NeosuranceWageFilegenerator
{
    public class busEmployerAgentWageFileGenerator
    {
        #region Properties
        //protected static utlPassInfo iobjUnitTestPassInfo = null;
        /// <summary>
        /// Tax- Gets or sets User type as employer or agent
        /// </summary>
        public string istrUserType { get; set; }

        /// <summary>
        /// Tax- Gets or sets type of a file e.g. XML,EFW2,ICESA,CSV
        /// </summary>
        public string istrFileType { get; set; }

        /// <summary>
        /// Tax - Gets or sets employer unique identification number
        /// </summary>
        public string iintEAN { get; set; }

        /// <summary>
        /// Tax - Gets or sets employer federal  identification number
        /// </summary>
        public string istrFEIN { get; set; }

        /// <summary>
        /// Tax - Gets or sets report quarter
        /// </summary>
        public string istrReportQuarter { get; set; }

        /// <summary>
        /// Tax - Gets or sets report year
        /// </summary>
        public string istrReportYear { get; set; }

        /// <summary>
        /// Tax - Gets or sets report year
        /// </summary>
        public string istrEANCount { get; set; }

        /// <summary>
        /// Tax - Gets or sets number of SSN
        /// </summary>
        public string istrSSNCount { get; set; }


        /// <summary>
        /// Tax - Gets or sets agent federal  identification number
        /// </summary>
        public string istrAgentFEIN { get; set; }

        /// <summary>
        /// Tax - Gets or sets Collection of agent data for file generation
        /// </summary>
        public Collection<busWageFileGeneratorEmployerData> iclbAgentData { get; set; }

        /// <summary>
        /// Tax - Gets or sets Collection of agent data for file generation
        /// </summary>
        public Stack<busAgentFileDataItems> iclbAgentFileData { get; set; }

        /// <summary>
        /// Tax - Gets or sets wage file header data
        /// </summary>
        //public doWageFileHeader icdoWageFileHeader { get; set; }

        /// <summary>
        /// Tax - Gets or sets full name of file to be generated
        /// </summary>
        public string istrFullFileName { get; set; }

        /// <summary>
        /// Tax - Gets or sets  name of file to be generated
        /// </summary>
        public string istrDocumentName { get; set; }

        /// <summary>
        /// Tax - Private field for file data string
        /// </summary>
        StringBuilder istrFileText = new StringBuilder();

        /// <summary>
        /// Tax - Private field for employer account number,quarter,year and number of SSN
        /// </summary>
        int iintEANumber, iintQuarter, iintYear, iintSSNCounts;

        /// <summary>
        /// Tax - Private field for FEIN and agents FEIN
        /// </summary>
        long iintFEINs, iintAgentFEIN;

        /// <summary>
        /// Tax - Private field for Random number
        /// </summary>
        static Random irndRandon = new Random();

        /// <summary>
        /// Tax - Gets or sets  name of employer or agent
        /// </summary>
        public string istrEmployerAgentName { get; set; }



        #endregion Properties

        #region Private Methods


        /// <summary>
        /// Tax - Validates all the data entered by user on form
        /// </summary>
        private void ValidateForm()
        {
            if (string.IsNullOrEmpty(iintEAN) || !int.TryParse(iintEAN, out iintEANumber))
            {
                //lutlError = AddError(0, "Please enter a valid EAN");
                //this.iarrErrors.Add(lutlError);
            }

            istrEmployerAgentName = GenRandomFirstName() + " Inc.";
            long.TryParse(istrFEIN, out iintFEINs);

            if (string.IsNullOrEmpty(istrReportQuarter) || !int.TryParse(istrReportQuarter, out iintQuarter))
            {
                //lutlError = AddError(0, "Please select a reporting quarter");
                //this.iarrErrors.Add(lutlError);
            }
            if (string.IsNullOrEmpty(istrReportYear) || !int.TryParse(istrReportYear, out iintYear) || iintYear < 2000 || iintYear > 2050)
            {
                //lutlError = AddError(0, "Please enter a valid reporting year between 2000 and 2050");
                //this.iarrErrors.Add(lutlError);
            }
            if (string.IsNullOrEmpty(istrSSNCount) || !int.TryParse(istrSSNCount, out iintSSNCounts))
            {
                //lutlError = AddError(0, "Please enter a valid SNN count");
                //this.iarrErrors.Add(lutlError);
            }
        }

        #endregion Private Methods

        #region Public Methods

        /// <summary>
        /// Tax - Generates random string using random key
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public string RandomString(int length)
        {
            const string lcharKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(lcharKey, length)
              .Select(s => s[irndRandon.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Tax - Generates random last name using random key
        /// </summary>
        /// <returns></returns>
        public static string GenRandomLastName()
        {
            List<string> lst = new List<string>();
            string str = string.Empty;
            lst.Add("Smith");
            lst.Add("Johnson");
            lst.Add("Williams");
            lst.Add("Jones");
            lst.Add("Brown");
            lst.Add("Davis");
            lst.Add("Miller");
            lst.Add("Wilson");
            lst.Add("Moore");
            lst.Add("Taylor");
            lst.Add("Anderson");
            lst.Add("Thomas");
            lst.Add("Jackson");
            lst.Add("White");
            lst.Add("Harris");
            lst.Add("Martin");
            lst.Add("Thompson");
            lst.Add("Garcia");
            lst.Add("Martinez");
            lst.Add("Robinson");
            lst.Add("Clark");
            lst.Add("Rodriguez");
            lst.Add("Lewis");
            lst.Add("Lee");
            lst.Add("Walker");
            lst.Add("Hall");
            lst.Add("Allen");
            lst.Add("Young");
            lst.Add("Hernandez");
            lst.Add("King");
            lst.Add("Wright");
            lst.Add("Lopez");
            lst.Add("Hill");
            lst.Add("Scott");
            lst.Add("Green");
            lst.Add("Adams");
            lst.Add("Baker");
            lst.Add("Gonzalez");
            lst.Add("Nelson");
            lst.Add("Carter");
            lst.Add("Mitchell");
            lst.Add("Perez");
            lst.Add("Roberts");
            lst.Add("Turner");
            lst.Add("Phillips");
            lst.Add("Campbell");
            lst.Add("Parker");
            lst.Add("Evans");
            lst.Add("Edwards");
            lst.Add("Collins");
            lst.Add("Stewart");
            lst.Add("Sanchez");
            lst.Add("Morris");
            lst.Add("Rogers");
            lst.Add("Reed");
            lst.Add("Cook");
            lst.Add("Morgan");
            lst.Add("Bell");
            lst.Add("Murphy");
            lst.Add("Bailey");
            lst.Add("Rivera");
            lst.Add("Cooper");
            lst.Add("Richardson");
            lst.Add("Cox");
            lst.Add("Howard");
            lst.Add("Ward");
            lst.Add("Torres");
            lst.Add("Peterson");
            lst.Add("Gray");
            lst.Add("Ramirez");
            lst.Add("James");
            lst.Add("Watson");
            lst.Add("Brooks");
            lst.Add("Kelly");
            lst.Add("Sanders");
            lst.Add("Price");
            lst.Add("Bennett");
            lst.Add("Wood");
            lst.Add("Barnes");
            lst.Add("Ross");
            lst.Add("Henderson");
            lst.Add("Coleman");
            lst.Add("Jenkins");
            lst.Add("Perry");
            lst.Add("Powell");
            lst.Add("Long");
            lst.Add("Patterson");
            lst.Add("Hughes");
            lst.Add("Flores");
            lst.Add("Washington");
            lst.Add("Butler");
            lst.Add("Simmons");
            lst.Add("Foster");
            lst.Add("Gonzales");
            lst.Add("Bryant");
            lst.Add("Alexander");
            lst.Add("Russell");
            lst.Add("Griffin");
            lst.Add("Diaz");
            lst.Add("Hayes");

            str = lst.OrderBy(xx => irndRandon.Next()).First();
            return str;
        }

        /// <summary>
        /// Tax - Generates random first name using random key
        /// </summary>
        /// <returns></returns>
        public static string GenRandomFirstName()
        {
            List<string> lst = new List<string>();
            string str = string.Empty;
            lst.Add("Aiden");
            lst.Add("Jackson");
            lst.Add("Mason");
            lst.Add("Liam");
            lst.Add("Jacob");
            lst.Add("Jayden");
            lst.Add("Ethan");
            lst.Add("Noah");
            lst.Add("Lucas");
            lst.Add("Logan");
            lst.Add("Caleb");
            lst.Add("Caden");
            lst.Add("Jack");
            lst.Add("Ryan");
            lst.Add("Connor");
            lst.Add("Michael");
            lst.Add("Elijah");
            lst.Add("Brayden");
            lst.Add("Benjamin");
            lst.Add("Nicholas");
            lst.Add("Alexander");
            lst.Add("William");
            lst.Add("Matthew");
            lst.Add("James");
            lst.Add("Landon");
            lst.Add("Nathan");
            lst.Add("Dylan");
            lst.Add("Evan");
            lst.Add("Luke");
            lst.Add("Andrew");
            lst.Add("Gabriel");
            lst.Add("Gavin");
            lst.Add("Joshua");
            lst.Add("Owen");
            lst.Add("Daniel");
            lst.Add("Carter");
            lst.Add("Tyler");
            lst.Add("Cameron");
            lst.Add("Christian");
            lst.Add("Wyatt");
            lst.Add("Henry");
            lst.Add("Eli");
            lst.Add("Joseph");
            lst.Add("Max");
            lst.Add("Isaac");
            lst.Add("Samuel");
            lst.Add("Anthony");
            lst.Add("Grayson");
            lst.Add("Zachary");
            lst.Add("David");
            lst.Add("Christopher");
            lst.Add("John");
            lst.Add("Isaiah");
            lst.Add("Levi");
            lst.Add("Jonathan");
            lst.Add("Oliver");
            lst.Add("Chase");
            lst.Add("Cooper");
            lst.Add("Tristan");
            lst.Add("Colton");
            lst.Add("Austin");
            lst.Add("Colin");
            lst.Add("Charlie");
            lst.Add("Dominic");
            lst.Add("Parker");
            lst.Add("Hunter");
            lst.Add("Thomas");
            lst.Add("Alex");
            lst.Add("Ian");
            lst.Add("Jordan");
            lst.Add("Cole");
            lst.Add("Julian");
            lst.Add("Aaron");
            lst.Add("Carson");
            lst.Add("Miles");
            lst.Add("Blake");
            lst.Add("Brody");
            lst.Add("Adam");
            lst.Add("Sebastian");
            lst.Add("Adrian");
            lst.Add("Nolan");
            lst.Add("Sean");
            lst.Add("Riley");
            lst.Add("Bentley");
            lst.Add("Xavier");
            lst.Add("Hayden");
            lst.Add("Jeremiah");
            lst.Add("Jason");
            lst.Add("Jake");
            lst.Add("Asher");
            lst.Add("Micah");
            lst.Add("Jace");
            lst.Add("Brandon");
            lst.Add("Josiah");
            lst.Add("Hudson");
            lst.Add("Nathaniel");
            lst.Add("Bryson");
            lst.Add("Ryder");
            lst.Add("Justin");
            lst.Add("Bryce");

            //—————female

            lst.Add("Sophia");
            lst.Add("Emma");
            lst.Add("Isabella");
            lst.Add("Olivia");
            lst.Add("Ava");
            lst.Add("Lily");
            lst.Add("Chloe");
            lst.Add("Madison");
            lst.Add("Emily");
            lst.Add("Abigail");
            lst.Add("Addison");
            lst.Add("Mia");
            lst.Add("Madelyn");
            lst.Add("Ella");
            lst.Add("Hailey");
            lst.Add("Kaylee");
            lst.Add("Avery");
            lst.Add("Kaitlyn");
            lst.Add("Riley");
            lst.Add("Aubrey");
            lst.Add("Brooklyn");
            lst.Add("Peyton");
            lst.Add("Layla");
            lst.Add("Hannah");
            lst.Add("Charlotte");
            lst.Add("Bella");
            lst.Add("Natalie");
            lst.Add("Sarah");
            lst.Add("Grace");
            lst.Add("Amelia");
            lst.Add("Kylie");
            lst.Add("Arianna");
            lst.Add("Anna");
            lst.Add("Elizabeth");
            lst.Add("Sophie");
            lst.Add("Claire");
            lst.Add("Lila");
            lst.Add("Aaliyah");
            lst.Add("Gabriella");
            lst.Add("Elise");
            lst.Add("Lillian");
            lst.Add("Samantha");
            lst.Add("Makayla");
            lst.Add("Audrey");
            lst.Add("Alyssa");
            lst.Add("Ellie");
            lst.Add("Alexis");
            lst.Add("Isabelle");
            lst.Add("Savannah");
            lst.Add("Evelyn");
            lst.Add("Leah");
            lst.Add("Keira");
            lst.Add("Allison");
            lst.Add("Maya");
            lst.Add("Lucy");
            lst.Add("Sydney");
            lst.Add("Taylor");
            lst.Add("Molly");
            lst.Add("Lauren");
            lst.Add("Harper");
            lst.Add("Scarlett");
            lst.Add("Brianna");
            lst.Add("Victoria");
            lst.Add("Liliana");
            lst.Add("Aria");
            lst.Add("Kayla");
            lst.Add("Annabelle");
            lst.Add("Gianna");
            lst.Add("Kennedy");
            lst.Add("Stella");
            lst.Add("Reagan");
            lst.Add("Julia");
            lst.Add("Bailey");
            lst.Add("Alexandra");
            lst.Add("Jordyn");
            lst.Add("Nora");
            lst.Add("Carolin");
            lst.Add("Mackenzie");
            lst.Add("Jasmine");
            lst.Add("Jocelyn");
            lst.Add("Kendall");
            lst.Add("Morgan");
            lst.Add("Nevaeh");
            lst.Add("Maria");
            lst.Add("Eva");
            lst.Add("Juliana");
            lst.Add("Abby");
            lst.Add("Alexa");
            lst.Add("Summer");
            lst.Add("Brooke");
            lst.Add("Penelope");
            lst.Add("Violet");
            lst.Add("Kate");
            lst.Add("Hadley");
            lst.Add("Ashlyn");
            lst.Add("Sadie");
            lst.Add("Paige");
            lst.Add("Katherine");
            lst.Add("Sienna");
            lst.Add("Piper");

            str = lst.OrderBy(xx => irndRandon.Next()).First();
            return str;
        }

        /// <summary>
        /// Tax -Adds a employer quarter data in agent list to create file
        /// </summary>
        /// <returns></returns>
        public ArrayList AddEmployerToAgentList()
        {
            ArrayList larrResult = new ArrayList();
            ValidateForm();
            iclbAgentData = new Collection<busWageFileGeneratorEmployerData>();
            busWageFileGeneratorEmployerData lbusWageFileGeneratorEmployerData = new busWageFileGeneratorEmployerData();
            busAgentFileDataItems lbusAgentFileDataItem = iclbAgentFileData.Pop();
            lbusWageFileGeneratorEmployerData.istrEAN = lbusAgentFileDataItem.istrEAN;
            lbusWageFileGeneratorEmployerData.istrFEIN = lbusAgentFileDataItem.istrFEIN;
            int.TryParse(lbusAgentFileDataItem.istrReportQuarter, out iintQuarter);
            lbusWageFileGeneratorEmployerData.iintReportQuarter = iintQuarter;
            int.TryParse(lbusAgentFileDataItem.istrReportYear, out iintYear);
            lbusWageFileGeneratorEmployerData.iintReportYear = iintYear;
            int.TryParse(lbusAgentFileDataItem.istrSSNCounts, out iintSSNCounts);
            lbusWageFileGeneratorEmployerData.iintSSNCounts = iintSSNCounts;
            lbusWageFileGeneratorEmployerData.istrEmployerName = istrEmployerAgentName;
            iclbAgentData.Add(lbusWageFileGeneratorEmployerData);
            istrReportYear = istrReportQuarter = istrSSNCount = iintEAN = istrFEIN = string.Empty;
            return larrResult;
        }
		
        /// <summary>
        /// Tax - Generates actual file based on user type ,data and file type
        /// </summary>
        /// <returns></returns>
        public ArrayList GenerateFile()
        {

            long lintfileRecordCount = 0;
            istrFileText = new StringBuilder();
            ArrayList larrResult = new ArrayList();
            string lstrSSN = irndRandon.Next(100000000, 999999999).ToString();
            string lstrFirstName = GenRandomFirstName(); //RandomString(10);
            string lstrLastName = GenRandomLastName(); // RandomString(12); 
            string lstrWage;
            string lstrHours = irndRandon.Next(111, 500).ToString();
            long lstrWageSum = 0;
            long TotlstrWageSum = 0;
            List<int> list = new List<int>();
			
            if (istrUserType == "employer")
            {
                ValidateForm();
            }
			
            #region Employer File Processing

            //Names to be replaced with actual employer Names and contact details 
            Random randNum = new Random();
            for (int j = 0; j < iintSSNCounts; j++)
            {
                list.Add(randNum.Next(9999, 99999));
                lstrWageSum += list[j];

            }
            if (istrUserType == "employer")
            {
                lintfileRecordCount = iintSSNCounts;
                switch (istrFileType)
                {
                    case "CSV":
                        istrFileText.Append("0," + iintFEINs.ToString().PadLeft(9, '0') + "," + istrEmployerAgentName + ",940 Madison Ave,Baltimore,24,21201,,John Smith,8712029210,,sagitecdllr@gmail.com,,," + Environment.NewLine);
                        istrFileText.Append("1," + iintEANumber.ToString().PadLeft(9, '0') + "," + (iintQuarter * 3) + iintYear.ToString() + "," + lstrWageSum + "," + lstrWageSum + "," + "0," + iintSSNCounts + "," + iintSSNCounts + "," + iintSSNCounts + ",1,,,,," + Environment.NewLine);
                        for (int i = 1; i <= iintSSNCounts; i++)
                        {
                            lstrSSN = irndRandon.Next(100000000, 999999999).ToString();
                            lstrFirstName = GenRandomFirstName();
                            lstrLastName = GenRandomLastName();
                            lstrWage = list[i - 1].ToString();
                            lstrHours = irndRandon.Next(111, 500).ToString();
                            istrFileText.Append("2," + iintEANumber + "," + (iintQuarter * 3) + iintYear.ToString() + "," + lstrSSN + "," + lstrFirstName + ",," + lstrLastName + "," + lstrWage + ",0," + lstrHours + ",1,1,1,0,0" + Environment.NewLine);
                        }
                        istrFileText.Append("3," + iintSSNCounts + "," + lstrWageSum + ",,,,,,,,,,,," + Environment.NewLine);
                        break;
                    case "EFW2":
                        istrFileText.Append("RA" + iintFEINs.ToString().PadLeft(9, '0').PadRight(26, ' ') + "0        " + istrEmployerAgentName.PadRight(57, ' ') + "101 St Andrews Road".PadRight(44, ' ') + "Columbia".PadRight(22, ' ') + "SC29210".PadRight(56, ' ') + "John Miller".PadRight(57, ' ') + "101 St Andrews Road".PadRight(44, ' ') + "Columbia".PadRight(22, ' ') + "SC29210".PadRight(56, ' ') + "John Miller".PadRight(27, ' ') + "8712029210".PadRight(23, ' ') + "sagitecdllr@gmail.com".PadRight(67, ' ') + Environment.NewLine);
                        istrFileText.Append("RV" + iintEANumber.ToString().PadLeft(15, '0') + ((iintQuarter * 3) + iintYear.ToString()).PadLeft(6, '0') + "          " + lstrWageSum.ToString().PadLeft(20, '0') + lstrWageSum.ToString().PadLeft(20, '0') + "00000000000000000000          " + iintSSNCounts.ToString().PadLeft(5, '0') + iintSSNCounts.ToString().PadLeft(5, '0') + iintSSNCounts.ToString().PadLeft(5, '0') + "1" + " ".PadRight(393) + Environment.NewLine);
                        for (int i = 1; i <= iintSSNCounts; i++)
                        {
                            lstrSSN = irndRandon.Next(100000000, 999999999).ToString();
                            lstrFirstName = GenRandomFirstName();
                            lstrLastName = GenRandomLastName();
                            lstrWage = list[i - 1].ToString();
                            lstrHours = irndRandon.Next(111, 500).ToString();
                            istrFileText.Append("RS" + "       " + lstrSSN.PadRight(9, '0') + lstrFirstName.PadRight(30, ' ') + lstrLastName.PadRight(21, ' ') + " ".PadRight(125, ' ') + "00" + ((iintQuarter * 3) + iintYear.ToString()).PadLeft(6, '0') + lstrWage.PadLeft(11, '0') + "00000000000" + "                       " + iintEANumber.ToString().PadLeft(21, ' ') + "                                                                      " + "  0" + lstrHours.PadRight(34, ' ') + " ".PadRight(137) + Environment.NewLine);
                        }
                        istrFileText.Append("RF" + "     " + iintSSNCounts.ToString().PadLeft(9, '0') + lstrWageSum.ToString().PadLeft(20, '0').PadRight(496, ' '));
                        break;
                    case "ICESA":
                        istrFileText.Append("A    " + istrFEIN.ToString().PadLeft(9, '0') + "         " + istrEmployerAgentName.PadRight(50, ' ') + "4058 Minnesota Ave NE                   WASHINGTON               24             21201     Dennis Lillee                 4444444440    " + " ".PadRight(68, ' ') + Environment.NewLine);
                        istrFileText.Append("E" + iintYear.ToString() + istrFEIN.ToString().PadLeft(9, '0') + "         " + istrEmployerAgentName.PadRight(50, ' ') + "4058 Minnesota Ave NE                   WASHINGTON               MD        21209             UTAX24" + iintEANumber.ToString().PadRight(15, ' ') + (iintQuarter * 3).ToString().PadLeft(2, '0') + "1".PadRight(86, ' ') + Environment.NewLine);
                        for (int i = 1; i <= iintSSNCounts; i++)
                        {
                            lstrSSN = irndRandon.Next(100000000, 999999999).ToString();
                            lstrFirstName = GenRandomFirstName();
                            lstrLastName = GenRandomLastName();
                            lstrWage = list[i - 1].ToString();
                            lstrHours = irndRandon.Next(111, 500).ToString();
                            istrFileText.Append("S" + lstrSSN.PadRight(9, '0') + lstrLastName.PadRight(20, ' ') + lstrFirstName.PadRight(12, ' ') + " 45".PadRight(21, ' ') + lstrWage.PadLeft(14, '0').PadRight(68, ' ') + lstrHours.PadRight(15, ' ') + iintEANumber.ToString().PadLeft(15, ' ').PadRight(63, ' ') + "0 111" + ((Convert.ToInt16(iintQuarter) * 3) + iintYear.ToString()).PadLeft(6, '0') + "            " + "0000000000000000" + " ".PadRight(27) + Environment.NewLine);
                        }
                        istrFileText.Append("T" + iintSSNCounts.ToString().PadLeft(7, '0').PadRight(25, ' ') + lstrWageSum.ToString().PadLeft(14, '0') + "0000000000000" + lstrWageSum.ToString().PadLeft(14, '0') + "             " + ((iintQuarter * 3) + iintYear.ToString()).PadLeft(6, '0').PadRight(145, ' ') + "000000100000010000001".PadRight(50, ' ') + Environment.NewLine);
                        istrFileText.Append("F" + iintSSNCounts.ToString().PadLeft(10, '0').PadRight(39, ' ') + lstrWageSum.ToString().PadLeft(15, '0').PadRight(235, ' '));
                        break;
                    case "XML":
                        istrFileText.Append("<?xml version='1.0' encoding='utf - 8'?><root>" + Environment.NewLine);
                        istrFileText.Append("<Submitter><FEIN>" + iintFEINs + "</FEIN> <BusinessName>" + istrEmployerAgentName + "</BusinessName><Address>101 St andrews Road</Address><City>Columbia</City><State>SC</State><ZIP>29210</ZIP><ZIP4></ZIP4><Contact>John Markus</Contact><Phone>8038075872</Phone><Extension></Extension><Email>john.markus@test.com</Email></Submitter>" + Environment.NewLine);
                        istrFileText.Append("<Wage><WageRecord>" + Environment.NewLine);

                        for (int i = 1; i <= iintSSNCounts; i++)
                        {
                            lstrSSN = irndRandon.Next(100000000, 999999999).ToString();
                            //lstrFirstName = RandomString(10);
                            //lstrLastName = RandomString(12);
                            lstrFirstName = GenRandomFirstName();
                            lstrLastName = GenRandomLastName();
                            lstrWage = list[i - 1].ToString();
                            lstrHours = irndRandon.Next(111, 500).ToString();
                            istrFileText.Append("<Employee><EmployerID>" + iintEANumber + "</EmployerID><Period>" + (iintQuarter * 3) + iintYear.ToString() + "</Period><SSN>" + lstrSSN + "</SSN><LastName>" + lstrLastName + "</LastName><FirstName>" + lstrFirstName + "</FirstName><MI></MI><StateGrossWages>" + lstrWage + "</StateGrossWages><OutofStateTaxableWages>0</OutofStateTaxableWages><HrsWkd>" + lstrHours + "</HrsWkd><OwnerRel>0</OwnerRel><EmployMon1>1</EmployMon1><EmployMon2>1</EmployMon2><EmployMon3>1</EmployMon3><AdjCode>0</AdjCode><Reason></Reason></Employee>" + Environment.NewLine);
                        }
                        istrFileText.Append("</WageRecord>" + Environment.NewLine);
                        istrFileText.Append("<Totals><EmployerID>" + iintEANumber + "</EmployerID><Period>" + (iintQuarter * 3) + iintYear.ToString() + "</Period><NoWageIndicator>1</NoWageIndicator><TotalWages>" + lstrWageSum + "</TotalWages><TaxableWages>" + lstrWageSum + "</TaxableWages><ExcessWages>0</ExcessWages><Month1>1</Month1><Month2>1</Month2><Month3>1</Month3></Totals>" + Environment.NewLine);
                        istrFileText.Append("</Wage></root>" + Environment.NewLine);
                        break;
                }
            }
            #endregion

            #region Agent File Processing

            else if (istrUserType == "agent")
            {
                //AddEmployerToAgentList();

                switch (istrFileType)
                {
                    case "CSV":

                        istrFileText.Append("0," + iintAgentFEIN.ToString().PadLeft(9, '0') + "," + istrEmployerAgentName + ", 101 St Andrews Road, Maryland, 45, 29210, ,John Miller, 8712029210, , sagitecdllr@gmail.com" + Environment.NewLine);

                        while (iclbAgentFileData.Count() != 0)
                        {
                            AddEmployerToAgentList();
                            foreach (busWageFileGeneratorEmployerData lbusWageFileGeneratorEmployerData in iclbAgentData)
                            {
                                for (int k = 0; k < lbusWageFileGeneratorEmployerData.iintSSNCounts; k++)
                                {
                                    list.Add(100000);
                                    lstrWageSum += list[k];
                                }

                                istrFileText.Append("1," + lbusWageFileGeneratorEmployerData.istrEAN + "," + (lbusWageFileGeneratorEmployerData.iintReportQuarter * 3) + lbusWageFileGeneratorEmployerData.iintReportYear + "," + lstrWageSum + "," + lstrWageSum + "," + "0," + lbusWageFileGeneratorEmployerData.iintSSNCounts + "," + lbusWageFileGeneratorEmployerData.iintSSNCounts + "," + lbusWageFileGeneratorEmployerData.iintSSNCounts + ",1,1,1" + Environment.NewLine);

                                for (int j = 1; j <= lbusWageFileGeneratorEmployerData.iintSSNCounts; j++)
                                {
                                    lstrSSN = irndRandon.Next(100000000, 999999999).ToString();
                                    lstrFirstName = GenRandomFirstName();
                                    lstrLastName = GenRandomLastName();
                                    lstrWage = list[j - 1].ToString();
                                    lstrHours = irndRandon.Next(111, 500).ToString();
                                    istrFileText.Append("2, " + lbusWageFileGeneratorEmployerData.istrEAN + "," + (lbusWageFileGeneratorEmployerData.iintReportQuarter * 3) + lbusWageFileGeneratorEmployerData.iintReportYear.ToString() + "," + lstrSSN + "," + lstrFirstName + ",," + lstrLastName + "," + lstrWage + ",0," + lstrHours + ",1,1,1,0,0" + Environment.NewLine);
                                }
                                TotlstrWageSum = TotlstrWageSum + lstrWageSum;
                                lstrWageSum = 0;
                                lintfileRecordCount = lintfileRecordCount + lbusWageFileGeneratorEmployerData.iintSSNCounts;
                                lbusWageFileGeneratorEmployerData.istrStatus = "Processed";
                            }
                        }
                        istrFileText.Append("3, " + lintfileRecordCount + "," + TotlstrWageSum);
                        break;
                    case "EFW2":
                        istrFileText.Append("RA" + iintAgentFEIN.ToString().PadLeft(9, '0').PadRight(26, ' ') + "0        " + istrEmployerAgentName.PadRight(57, ' ') + "101 St Andrews Road".PadRight(44, ' ') + "Columbia".PadRight(22, ' ') + "SC29210".PadRight(56, ' ') + "John Miller".PadRight(57, ' ') + "101 St Andrews Road".PadRight(44, ' ') + "Columbia".PadRight(22, ' ') + "MD29210".PadRight(74, ' ') + "John Miller".PadRight(14, ' ') + "8712029210".PadRight(38, ' ') + "sagitecdllr@gmail.com".PadRight(47, ' ') + Environment.NewLine);
                        while (iclbAgentFileData.Count() != 0)
                        {
                            AddEmployerToAgentList();

                            foreach (busWageFileGeneratorEmployerData lbusWageFileGeneratorEmployerData in iclbAgentData)
                            {
                                for (int k = 0; k < lbusWageFileGeneratorEmployerData.iintSSNCounts; k++)
                                {

                                    list.Add(100000);
                                    lstrWageSum += list[k];
                                }
                                istrFileText.Append("RV" + lbusWageFileGeneratorEmployerData.istrEAN.ToString().PadLeft(15, '0') + ((lbusWageFileGeneratorEmployerData.iintReportQuarter * 3) + lbusWageFileGeneratorEmployerData.iintReportYear.ToString()).PadLeft(6, '0') + "          " + lstrWageSum.ToString().PadLeft(20, '0') + lstrWageSum.ToString().PadLeft(20, '0') + "00000000000000000000          " + lbusWageFileGeneratorEmployerData.iintSSNCounts.ToString().PadLeft(5, '0') + lbusWageFileGeneratorEmployerData.iintSSNCounts.ToString().PadLeft(5, '0') + lbusWageFileGeneratorEmployerData.iintSSNCounts.ToString().PadLeft(5, '0') + "1" + " ".PadRight(393) + Environment.NewLine);
                                for (int i = 1; i <= lbusWageFileGeneratorEmployerData.iintSSNCounts; i++)
                                {
                                    lstrSSN = irndRandon.Next(100000000, 999999999).ToString();


                                    lstrFirstName = GenRandomFirstName();
                                    lstrLastName = GenRandomLastName();
                                    lstrWage = list[i - 1].ToString();
                                    lstrHours = irndRandon.Next(111, 500).ToString();

                                    istrFileText.Append("RS" + "       " + lstrSSN.PadRight(9, '0') + lstrFirstName.PadRight(30, ' ') + lstrLastName.PadRight(21, ' ') + " ".PadRight(125, ' ') + "00" + ((lbusWageFileGeneratorEmployerData.iintReportQuarter * 3) + lbusWageFileGeneratorEmployerData.iintReportYear.ToString()).PadLeft(6, '0') + lstrWage.PadLeft(11, '0') + "00000000000" + "                       " + iintEANumber.ToString().PadLeft(21, ' ') + "                                                                      " + "  0" + lstrHours.PadRight(34, ' ') + " ".PadRight(137) + Environment.NewLine);
                                }
                                TotlstrWageSum = 0;
                                TotlstrWageSum = TotlstrWageSum + lstrWageSum;
                                lstrWageSum = 0;
                                lintfileRecordCount = lintfileRecordCount + lbusWageFileGeneratorEmployerData.iintSSNCounts;
                                lbusWageFileGeneratorEmployerData.istrStatus = "Processed";
                                istrFileText.Append("RF" + "     " + lbusWageFileGeneratorEmployerData.iintSSNCounts.ToString().PadLeft(9, '0') + TotlstrWageSum.ToString().PadLeft(20, '0').PadRight(496, ' ') + Environment.NewLine);
                            }
                        }


                        break;
                    case "ICESA":

                        istrFileText.Append("A".PadRight(5, ' ') + iintAgentFEIN.ToString().PadLeft(9, '0') + "         " + istrEmployerAgentName.PadRight(41, ' ') + "         101 St Andrews Road                     Columbia                 45             29210     John Miller                   8712029210    " + "                       ".PadRight(68, ' ') + Environment.NewLine);
                        while (iclbAgentFileData.Count() != 0)
                        {
                            AddEmployerToAgentList();
                            foreach (busWageFileGeneratorEmployerData lbusWageFileGeneratorEmployerData in iclbAgentData)
                            {
                                for (int k = 0; k < lbusWageFileGeneratorEmployerData.iintSSNCounts; k++)
                                {

                                    list.Add(100000);
                                    lstrWageSum += list[k];
                                }

                                istrFileText.Append("E" + lbusWageFileGeneratorEmployerData.iintReportYear + iintAgentFEIN.ToString().PadRight(18, ' ') + lbusWageFileGeneratorEmployerData.istrEmployerName.PadRight(41, ' ') + "         101 St Andrews Road                     Columbia                 SC        29210             UTAX45" + lbusWageFileGeneratorEmployerData.istrEAN.ToString().PadRight(15, ' ') + (Convert.ToInt16(lbusWageFileGeneratorEmployerData.iintReportQuarter) * 3).ToString().PadLeft(2, '0') + "1".PadRight(86, ' ') + Environment.NewLine);

                                for (int j = 1; j <= lbusWageFileGeneratorEmployerData.iintSSNCounts; j++)
                                {
                                    lstrSSN = irndRandon.Next(100000000, 999999999).ToString();
                                    //lstrFirstName = RandomString(10);
                                    //lstrLastName = RandomString(12);
                                    lstrFirstName = GenRandomFirstName();
                                    lstrLastName = GenRandomLastName();
                                    lstrWage = list[j - 1].ToString();
                                    lstrHours = irndRandon.Next(111, 500).ToString();
                                    istrFileText.Append("S" + lstrSSN.PadRight(9, '0') + lstrLastName.PadRight(20, ' ') + lstrFirstName.PadRight(12, ' ') + "45".PadRight(21, ' ') + lstrWage.PadLeft(14, '0').PadRight(68, ' ') + lstrHours.PadRight(15, ' ') + lbusWageFileGeneratorEmployerData.istrEAN.ToString().PadRight(15, ' ').PadRight(63, ' ') + "0 111" + ((Convert.ToInt16(lbusWageFileGeneratorEmployerData.iintReportQuarter) * 3) + lbusWageFileGeneratorEmployerData.iintReportYear.ToString()).PadLeft(6, '0').PadRight(19, ' ') + "000000000000000".PadRight(42, ' ') + Environment.NewLine);
                                }
                                TotlstrWageSum = 0;
                                TotlstrWageSum = TotlstrWageSum + lstrWageSum;
                                //TotlstrWageSum = 0;
                                lintfileRecordCount = lintfileRecordCount + lbusWageFileGeneratorEmployerData.iintSSNCounts;
                                lbusWageFileGeneratorEmployerData.istrStatus = "Processed";
                                istrFileText.Append("T" + lbusWageFileGeneratorEmployerData.iintSSNCounts.ToString().PadLeft(7, '0') + "                  " + TotlstrWageSum.ToString().PadLeft(14, '0') + "0000000000000" + TotlstrWageSum.ToString().PadLeft(14, '0') + "              " + ((Convert.ToInt16(lbusWageFileGeneratorEmployerData.iintReportQuarter) * 3) + lbusWageFileGeneratorEmployerData.iintReportYear.ToString()).PadLeft(6, '0').PadRight(145, ' ') + lbusWageFileGeneratorEmployerData.iintSSNCounts.ToString().PadLeft(7, '0') + lbusWageFileGeneratorEmployerData.iintSSNCounts.ToString().PadLeft(7, '0') + lbusWageFileGeneratorEmployerData.iintSSNCounts.ToString().PadLeft(7, '0') + " ".PadRight(28) + Environment.NewLine);
                            }
                        }
                        istrFileText.Append("F" + lintfileRecordCount.ToString().PadLeft(10, '0').PadRight(39, ' ') + TotlstrWageSum.ToString().PadLeft(15, '0').PadRight(235, ' '));

                        break;
                    case "XML":

                        istrFileText.Append("<?xml version='1.0' encoding='utf - 8'?><root>");
                        istrFileText.Append("<Submitter><FEIN>" + iintAgentFEIN + "</FEIN><BusinessName>" + istrEmployerAgentName + "</BusinessName><Address>101 St andrews Road</Address><City>Columbia</City><State>SC</State><ZIP>29210</ZIP><ZIP4></ZIP4><Contact>John Markus</Contact><Phone>8038075872</Phone><Extension></Extension><Email>john.markus@test.com</Email></Submitter>" + Environment.NewLine);
                        while (iclbAgentFileData.Count() != 0)
                        {
                            AddEmployerToAgentList();
                            foreach (busWageFileGeneratorEmployerData lbusWageFileGeneratorEmployerData in iclbAgentData)
                            {

                                istrFileText.Append("<Wage>" + "<WageRecord>" + Environment.NewLine);
                                for (int k = 0; k < lbusWageFileGeneratorEmployerData.iintSSNCounts; k++)
                                {

                                    list.Add(100000);
                                    lstrWageSum += list[k];
                                }

                                for (int j = 1; j <= lbusWageFileGeneratorEmployerData.iintSSNCounts; j++)
                                {
                                    lstrSSN = irndRandon.Next(100000000, 999999999).ToString();
                                    lstrFirstName = GenRandomFirstName();
                                    lstrLastName = GenRandomLastName();
                                    lstrWage = list[j - 1].ToString();
                                    lstrHours = irndRandon.Next(111, 500).ToString();
                                    istrFileText.Append("<Employee><EmployerID>" + lbusWageFileGeneratorEmployerData.istrEAN + "</EmployerID><Period>" + (lbusWageFileGeneratorEmployerData.iintReportQuarter * 3) + lbusWageFileGeneratorEmployerData.iintReportYear.ToString() + "</Period><SSN>" + lstrSSN + "</SSN><LastName>" + lstrLastName + "</LastName><FirstName>" + lstrFirstName + "</FirstName><MI></MI><StateGrossWages>" + lstrWage + "</StateGrossWages><OutofStateTaxableWages>0</OutofStateTaxableWages><HrsWkd>" + lstrHours + "</HrsWkd><OwnerRel>0</OwnerRel><EmployMon1>1</EmployMon1><EmployMon2>1</EmployMon2><EmployMon3>1</EmployMon3><AdjCode>0</AdjCode><Reason></Reason></Employee>" + Environment.NewLine);
                                }
                                lintfileRecordCount = lintfileRecordCount + lbusWageFileGeneratorEmployerData.iintSSNCounts;
                                lbusWageFileGeneratorEmployerData.istrStatus = "Processed";
                                istrFileText.Append("</WageRecord>" + Environment.NewLine);
                                istrFileText.Append("<Totals><EmployerID>" + lbusWageFileGeneratorEmployerData.istrEAN + "</EmployerID><Period>" + (lbusWageFileGeneratorEmployerData.iintReportQuarter * 3) + lbusWageFileGeneratorEmployerData.iintReportYear.ToString() + "</Period><NoWageIndicator>1</NoWageIndicator><TotalWages>" + lstrWageSum + "</TotalWages><TaxableWages>0</TaxableWages><ExcessWages>0</ExcessWages><Month1>1</Month1><Month2>1</Month2><Month3>1</Month3></Totals>" + Environment.NewLine);
                                lstrWageSum = 0;
                                istrFileText.Append("</Wage>" + Environment.NewLine);
                            }
                        }

                        istrFileText.Append("</root>");

                        break;
                }
            }
            #endregion


            if (lintfileRecordCount > 0)
            {
                string lstrGenericPath = "D:\\Wage Files";
                bool lblnexists = System.IO.Directory.Exists(lstrGenericPath);
                int iintQuarters = iintQuarter * 3;
                if (!lblnexists)
                    System.IO.Directory.CreateDirectory(lstrGenericPath);
                istrDocumentName = string.Empty;

                switch (istrFileType)
                {
                    case "CSV":
                        if (istrUserType == "employer")
                            istrDocumentName = iintEANumber.ToString() + "_" + iintQuarters.ToString() + iintYear.ToString() + ".csv";
                        else
                            istrDocumentName = iintAgentFEIN + "_" + iintQuarters.ToString() + iintYear.ToString() + ".csv";
                        break;
                    case "XML":
                        if (istrUserType == "employer")
                            istrDocumentName = iintEANumber.ToString() + "_" + iintQuarters.ToString() + iintYear.ToString() + ".xml";
                        else
                            istrDocumentName = iintAgentFEIN + "_" + iintQuarters.ToString() + iintYear.ToString() + ".xml";
                        break;
                    case "ICESA":
                        if (istrUserType == "employer")
                            istrDocumentName = iintEANumber + "_" + "ICESA" + "_" + iintQuarters.ToString() + iintYear.ToString() + ".txt";
                        else
                            istrDocumentName = iintAgentFEIN + "_" + "ICESA" + "_" + iintQuarters.ToString() + iintYear.ToString() + ".txt";
                        break;
                    case "EFW2":
                        if (istrUserType == "employer")
                            istrDocumentName = iintEANumber + "_" + "EFW2" + "_" + iintQuarters.ToString() + iintYear.ToString() + ".txt";
                        else
                            istrDocumentName = iintAgentFEIN + "EFW2" + "_" + iintQuarters.ToString() + iintYear.ToString() + ".txt";
                        break;
                }
                istrFullFileName = Path.Combine(lstrGenericPath, istrDocumentName);

                System.IO.StreamWriter file = new System.IO.StreamWriter(istrFullFileName);
                file.WriteLine(istrFileText.ToString());
                file.Close();
            }

            return larrResult;
        }

        #endregion Public Methods

    }

    /// <summary>
    /// Tax- This class holds properties of employer like identification number,year quarter
    /// </summary>
    [Serializable]
    public class busWageFileGeneratorEmployerData
    {
        /// <summary>
        /// Tax- Gets or sets employer unique identification number
        /// </summary>
        public string istrEAN { get; set; }

        /// <summary>
        /// Tax - Gets or sets employer federal identification number
        /// </summary>
        public string istrFEIN { get; set; }

        /// <summary>
        /// Tax - Gets or sets employer name
        /// </summary>
        public string istrEmployerName { get; set; }

        /// <summary>
        /// Tax - Gets or sets report quarter
        /// </summary>
        public int iintReportQuarter { get; set; }

        /// <summary>
        /// Tax - Gets or sets report year
        /// </summary>
        public int iintReportYear { get; set; }

        /// <summary>
        /// Tax - Gets or sets number of SSN
        /// </summary>
        public long iintSSNCounts { get; set; }

        /// <summary>
        /// Tax - Gets or sets status of employer
        /// </summary>
        public string istrStatus { get; set; }

        /// <summary>
        /// Tax - Gets or sets message or comment
        /// </summary>
        public string istrMessages { get; set; }
    }

    public class busAgentFileDataItems
    {
        /// <summary>
        /// Tax- Gets or sets employer unique identification number
        /// </summary>
        public string istrEAN { get; set; }

        /// <summary>
        /// Tax - Gets or sets employer federal identification number
        /// </summary>
        public string istrFEIN { get; set; }

        /// <summary>
        /// Tax- Gets or sets employer unique identification number
        /// </summary>
        public string istrReportQuarter { get; set; }

        /// <summary>
        /// Tax - Gets or sets employer federal identification number
        /// </summary>
        public string istrReportYear { get; set; }


        /// <summary>
        /// Tax - Gets or sets report quarter
        /// </summary>
        public int iintReportQuarter { get; set; }

        /// <summary>
        /// Tax - Gets or sets report year
        /// </summary>
        public int iintReportYear { get; set; }

        /// <summary>
        /// Tax - Gets or sets number of SSN
        /// </summary>
        public long iintSSNCounts { get; set; }

        /// <summary>
        /// Tax - Gets or sets status of employer
        /// </summary>
        public string istrSSNCounts { get; set; }
    }
}
