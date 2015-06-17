using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace ASPathe_Applicatie
{
    public class DatabaseKoppeling
    {
        private List<Bioscoop> bioscopen;
        private List<Persoon> personen = new List<Persoon>();
        private Persoon nuIngelogdePersoon = null;
        private OracleConnection conn;
        private OracleCommand command;
        string user = "Pathe";
        string pw = "Fontys18Oracle";

        public DatabaseKoppeling()
        {
            bioscopen = new List<Bioscoop>();
            conn = new OracleConnection();
            command = conn.CreateCommand();
            conn.ConnectionString = "User Id="+user+";Password="+pw+";Data Source="+"//localhost:1521/xe"+";";
        }

        public Persoon NuIngelogdePersoon
        {
            get { return nuIngelogdePersoon; }
            set { nuIngelogdePersoon = value; }
        }

        public List<Persoon> HaalAllePersonenOp()
        {
            List<Persoon> tempPersonen = new List<Persoon>();

            try
            {
                conn.Open();
                string query = "SELECT * FROM PERSOON";
                command = new OracleCommand(query, conn);
                OracleDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    string voornaam = Convert.ToString(datareader["voornaam"]);
                    string achternaam = Convert.ToString(datareader["achternaam"]);
                    string gebruikersnaam = Convert.ToString(datareader["voornaam"]); //De voornaam en achternaam gebruik ik als
                    string wachtwoord = Convert.ToString(datareader["achternaam"]); //als gebruikersnaam en wachtwoord voor het gemak
                    string email = Convert.ToString(datareader["mailadres"]);
                    tempPersonen.Add(new Persoon(voornaam, achternaam, gebruikersnaam, wachtwoord, email));
                }
                return tempPersonen;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
            personen = tempPersonen;
        }

        public Persoon CheckGebruikersnaam(string naam)
        {
            foreach (Persoon p in HaalAllePersonenOp())
            {
                if (naam == p.Gebruikersnaam)
                {
                    return p;
                }
            }
            return null;
        }

        public string VraagHoogsteIDOp()
        {
            string hoogsteID = "";

            try
            {
                conn.Open();
                string query = "SELECT * FROM PERSOON";
                command = new OracleCommand(query, conn);
                OracleDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    string id = Convert.ToString(datareader["MAX(ID)"]);
                    hoogsteID = id;
                }
                return hoogsteID;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Bioscoop> HaalBioscopenOp()
        {
            try
            {
                conn.Open();
                string query = "SELECT Bioscoopnaam, Plaats, Adres, Postcode FROM BIOSCOOP";
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string bioscoopnaam = Convert.ToString(dataReader["Bioscoopnaam"]);
                    string plaats = Convert.ToString(dataReader["Plaats"]);
                    string adres = Convert.ToString(dataReader["Adres"]);
                    string postcode = Convert.ToString(dataReader["Postcode"]);
                    Bioscoop b = new Bioscoop(bioscoopnaam, plaats, adres, postcode);
                    bioscopen.Add(b);
                }
                return bioscopen;
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public bool VoegBioscoopToe(string bioscoopnaam, string plaats, string adres, string postcode)
        {
            foreach (Bioscoop b in bioscopen)
            {
                if (bioscoopnaam == b.Bioscoopnaam)
                {
                    return false;
                }
            }
            bioscopen.Add(new Bioscoop(bioscoopnaam, plaats, adres, postcode));
            return true;
        }
    }
}