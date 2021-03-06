﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace ASPathe_Applicatie
{
    public class DatabaseKoppeling
    {
        //Fields
        private List<Bioscoop> bioscopen = new List<Bioscoop>();
        private List<Acteur> acteurs = new List<Acteur>();
        private List<Film> films = new List<Film>();
        private List<Persoon> personen = new List<Persoon>();
        private Persoon nuIngelogdePersoon = null;
        private OracleConnection conn;
        private OracleCommand command;
        string user = "Pathe";
        string pw = "Fontys18Oracle";

        //Propertie
        public Persoon NuIngelogdePersoon
        {
            get { return nuIngelogdePersoon; }
            set { nuIngelogdePersoon = value; }
        }

        //Constructor
        public DatabaseKoppeling()
        {
            conn = new OracleConnection();
            command = conn.CreateCommand();
            conn.ConnectionString = "User Id="+user+";Password="+pw+";Data Source="+"//localhost:1521/xe"+";";
        }

        //Methodes
        //Deze methode checkt of de gebruikersnaam bestaat en retourneert de persoon die gevonden is
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

        public bool TestConnectie()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        //Hieronder beginnen de VoegToe methodes
        //Deze methode voegt een bioscoop toe
        public bool VoegBioscoopToe(string bioscoopnaam, string plaats, string adres, string postcode)
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO BIOSCOOP(Bioscoopnaam, Plaats, Adres, Postcode, DoordeweekseOpeningstijd, DoordeweekseSluitingstijd, WeekendOpeningstijd, WeekendSluitingstijd, bereikbaarheid) VALUES('" + bioscoopnaam + "', '" + plaats + "', '" + adres + "', '" + postcode + "', '10:45', '22:30', '10:30', '23:00', '')";
                command = new OracleCommand(query, conn);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();

            }
            return false;
        }

        //Deze methode voegt een acteur toe
        public bool VoegActeurToe(int id, string voornaam, string achternaam, string geboortedatum)
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO ACTEUR(ID, Voornaam, Achternaam, Geboortedatum) VALUES(" + id + ", '" + voornaam + "', '" + achternaam + "', '" + geboortedatum + "')";
                command = new OracleCommand(query, conn);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();

            }
            return false;
        }

        public bool VoegFilmToe(int id, string titel, string genre, int tijdsduur, string regisseur, string taalversie, string ondertiteling, int leeftijd)
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO FILM(ID, Titel, Genre, Tijdsduur, Regisseur, Taalversie, Ondertiteling, Leeftijd, Trailer, Poster, Foto) VALUES(" + id + ", '" + titel + "', '" + genre + "', " + tijdsduur + ", '" + regisseur + "', '" + taalversie + "', '" + ondertiteling + "', '" + leeftijd + "', '', '', '')";
                command = new OracleCommand(query, conn);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();

            }
            return false;
        }

        //Deze methode voegt een nieuwe persoon toe
        public bool VoegPersoonToe(int id, string voornaam, string tussenvoegsel, string achternaam, string geboortedatum, string geslacht, string wachtwoord, string email)
        {
            try
            {
                if (tussenvoegsel != "")
                {
                    conn.Open();
                    string query = "INSERT INTO PERSOON(ID, Voornaam, Tussenvoegsel, Achternaam, Geboortedatum, Geslacht, Mailadres, Wachtwoord, WilWekelijkseNiewsbrief, Foto) VALUES(" + id + ", '" + voornaam + "', '" + tussenvoegsel + "', '" + achternaam + "', '" + geboortedatum + "', '" + geslacht + "', '" + email + "', '" + wachtwoord + "', 'nee', '')";
                    command = new OracleCommand(query, conn);
                    command.ExecuteNonQuery();
                }
                else
                {
                    conn.Open();
                    string query = "INSERT INTO PERSOON(ID, Voornaam, Tussenvoegsel, Achternaam, Geboortedatum, Geslacht, Mailadres, Wachtwoord, WilWekelijkseNiewsbrief, Foto) VALUES(" + id + ", '" + voornaam + "', '', '" + achternaam + "', '" + geboortedatum + "', '" + geslacht + "', '" + email + "', '" + wachtwoord + "', 'nee', '')";
                    command = new OracleCommand(query, conn);
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        //Jieronder beginnen de VraagHoogsteIDOp methodes
        //Deze methode vraagt het hoogste id op van een achteur
        public int VraagHoogsteActeurIDOp()
        {
            int hoogsteID = 0;

            try
            {
                conn.Open();
                string query = "SELECT * FROM ACTEUR WHERE ID = (SELECT MAX(ID) FROM ACTEUR)";
                command = new OracleCommand(query, conn);
                OracleDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    hoogsteID = Convert.ToInt32(datareader["ID"]);
                }
                return hoogsteID;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }

        public int VraagHoogsteFilmIDOp()
        {
            int hoogsteID = 0;

            try
            {
                conn.Open();
                string query = "SELECT * FROM FILM WHERE ID = (SELECT MAX(ID) FROM FILM)";
                command = new OracleCommand(query, conn);
                OracleDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    hoogsteID = Convert.ToInt32(datareader["ID"]);
                }
                return hoogsteID;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }

        //Deze methode geeft het hoogste id van een persoon terug
        public int VraagHoogstePersoonIDOp()
        {
            int hoogsteID = 0;

            try
            {
                conn.Open();
                string query = "SELECT * FROM PERSOON WHERE ID = (SELECT MAX(ID) FROM PERSOON)";
                command = new OracleCommand(query, conn);
                OracleDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    hoogsteID = Convert.ToInt32(datareader["ID"]);
                }
                return hoogsteID;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }

        //Hieronder staan de HaalOp methodes
        //Deze methode haalt alle bioscopen op uit de database en geeft ze terug in een lijst
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
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        //Deze methode haalt alle acteurs op en geeft ze terug in een lijst
        public List<Acteur> HaalActeursOp()
        {
            try
            {
                conn.Open();
                string query = "SELECT Voornaam, Achternaam, Geboortedatum FROM ACTEUR";
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string voornaam = Convert.ToString(dataReader["Voornaam"]);
                    string achternaam = Convert.ToString(dataReader["Achternaam"]);
                    string geboortedatum = Convert.ToString(dataReader["Geboortedatum"]);
                    Acteur a = new Acteur(voornaam, achternaam, geboortedatum);
                    acteurs.Add(a);
                }
                return acteurs;
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

        //Deze methode haalt alle films op en geeft ze terug in een lijst
        public List<Film> HaalFilmsOp()
        {
            try
            {
                conn.Open();
                string query = "SELECT Titel, Genre, Tijdsduur, Regisseur, Ondertiteling FROM FILM";
                command = new OracleCommand(query, conn);
                OracleDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string titel = Convert.ToString(dataReader["Titel"]);
                    string genre = Convert.ToString(dataReader["Genre"]);
                    int tijdsduur = Convert.ToInt32(dataReader["Tijdsduur"]);
                    string regisseur = Convert.ToString(dataReader["Regisseur"]);
                    string ondertiteling = Convert.ToString(dataReader["Ondertiteling"]);
                    Film f = new Film (titel, genre, tijdsduur, regisseur, ondertiteling);
                    films.Add(f);
                }
                return films;
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

        //Deze methode haalt alle personen op uit de database en geeft ze terug in een lijst
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
        }

        //Hieronder staan de Wijzig methodes
        //Deze methode wijzigd van een bioscoop hetgene wat in de desbetreffende textbox staat
        public bool WijzigBioscoop(string geselecteerdeBioscoop, string bioscoopnaam, string plaats, string adres, string postcode)
        {
            bool gewijzigd = false;
            try
            {
                if (bioscoopnaam != "")
                {
                    conn.Open();
                    string query = "UPDATE BIOSCOOP SET Bioscoopnaam = '" + bioscoopnaam + "' WHERE Bioscoopnaam = '" + geselecteerdeBioscoop + "'";
                    command = new OracleCommand(query, conn);
                    command.ExecuteNonQuery();
                }

                if (plaats != "")
                {
                    conn.Open();
                    string query = "UPDATE BIOSCOOP SET Plaats = '" + plaats + "' WHERE Bioscoopnaam = '" + geselecteerdeBioscoop + "'";
                    command = new OracleCommand(query, conn);
                    command.ExecuteNonQuery();
                }

                if (adres != "")
                {
                    conn.Open();
                    string query = "UPDATE BIOSCOOP SET Adres = '" + adres + "' WHERE Bioscoopnaam = '" + geselecteerdeBioscoop + "";
                    command = new OracleCommand(query, conn);
                    command.ExecuteNonQuery();
                }

                if (postcode != "")
                {
                    conn.Open();
                    string query = "UPDATE BIOSCOOP SET Postcode = '" + postcode + "' WHERE Bioscoopnaam = '" + geselecteerdeBioscoop + "";
                    command = new OracleCommand(query, conn);
                    command.ExecuteNonQuery();
                }
                gewijzigd = true;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return gewijzigd;
        }

        //Deze methode wijzigd van een acteur hetgene wat in de desbetreffende textbox staat
        public bool WijzigActeur(string geselecteerdeActeur, string voornaam, string achternaam, string geboortedatum)
        {
            bool gewijzigd = false;
            try
            {
                if (voornaam != "")
                {
                    conn.Open();
                    string query = "UPDATE ACTEUR SET Voornaam = '" + voornaam + "' WHERE Voornaam = '" + geselecteerdeActeur + "'";
                    command = new OracleCommand(query, conn);
                    command.ExecuteNonQuery();
                }

                if (achternaam != "")
                {
                    conn.Open();
                    string query = "UPDATE ACTEUR SET Achternaam = '" + achternaam + "' WHERE Voornaam = '" + geselecteerdeActeur + "'";
                    command = new OracleCommand(query, conn);
                    command.ExecuteNonQuery();
                }

                if (geboortedatum != "")
                {
                    conn.Open();
                    string query = "UPDATE ACTEUR SET Geboortedatum = '" + geboortedatum + "' WHERE Voornaam = '" + geselecteerdeActeur + "'";
                    command = new OracleCommand(query, conn);
                    command.ExecuteNonQuery();
                }
                gewijzigd = true;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return gewijzigd;
        }

        //Deze methode wijzigd van een film hetgene wat in de desbetreffende textbox staat
        public bool WijzigFilm(string geselecteerdeFilm, string titel, string genre, string tijdsduur, string regisseur, string taalversie, string ondertiteling, string leeftijd)
        {
            bool gewijzigd = false;
            try
            {
                if (titel != "")
                {
                    conn.Open();
                    string query = "UPDATE FILM SET Titel = '" + titel + "' WHERE Titel = '" + geselecteerdeFilm + "'";
                    command = new OracleCommand(query, conn);
                    command.ExecuteNonQuery();
                }

                if (genre != "")
                {
                    conn.Open();
                    string query = "UPDATE FILM SET Genre = '" + genre + "' WHERE Titel = '" + geselecteerdeFilm + "'";
                    command = new OracleCommand(query, conn);
                    command.ExecuteNonQuery();
                }

                if (tijdsduur != "")
                {
                    int tijd = Convert.ToInt32(tijdsduur);
                    conn.Open();
                    string query = "UPDATE FILM SET Tijdsduur = '" + tijd + "' WHERE Titel = '" + geselecteerdeFilm + "'";
                    command = new OracleCommand(query, conn);
                    command.ExecuteNonQuery();
                }

                if (regisseur != "")
                {
                    conn.Open();
                    string query = "UPDATE FILM SET Regisseur = '" + regisseur + "' WHERE Titel = '" + geselecteerdeFilm + "'";
                    command = new OracleCommand(query, conn);
                    command.ExecuteNonQuery();
                }

                if (taalversie != "")
                {
                    conn.Open();
                    string query = "UPDATE FILM SET Taalversie = '" + taalversie + "' WHERE Titel = '" + geselecteerdeFilm + "'";
                    command = new OracleCommand(query, conn);
                    command.ExecuteNonQuery();
                }

                if (ondertiteling != "")
                {
                    conn.Open();
                    string query = "UPDATE FILM SET Ondertiteling = '" + ondertiteling + "' WHERE Titel = '" + geselecteerdeFilm + "'";
                    command = new OracleCommand(query, conn);
                    command.ExecuteNonQuery();
                }

                if (leeftijd != "")
                {
                    int age = Convert.ToInt32(leeftijd);
                    conn.Open();
                    string query = "UPDATE FILM SET Leeftijd = '" + age + "' WHERE Titel = '" + geselecteerdeFilm + "'";
                    command = new OracleCommand(query, conn);
                    command.ExecuteNonQuery();
                }
                gewijzigd = true;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return gewijzigd;
        }

        //Hieronder beginnen de Verwijder methodes
        //Deze methode verwijderd een bioscoop uit de database
        public bool VerwijderBioscoop(string geselecteerdeBioscoop)
        {
            bool verwijderd = false;
            try
            {
                conn.Open();
                string query = "DELETE FROM BIOSCOOP WHERE Bioscoopnaam = '" + geselecteerdeBioscoop + "'";
                command = new OracleCommand(query, conn);
                command.ExecuteNonQuery();
                verwijderd = true;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return verwijderd;
        }

        //Deze methode verwijderd een acteur uit de database
        public bool VerwijderActeur(string geselecteerdeActeur)
        {
            bool verwijderd = false;
            try
            {
                conn.Open();
                string query = "DELETE FROM ACTEUR WHERE Voornaam = '" + geselecteerdeActeur + "'";
                command = new OracleCommand(query, conn);
                command.ExecuteNonQuery();
                verwijderd = true;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return verwijderd;
        }

        //Deze methode verwijderd een film uit de database
        public bool VerwijderFilm(string geselecteerdeFilm)
        {
            bool verwijderd = false;
            try
            {
                conn.Open();
                string query = "DELETE FROM FILM WHERE Titel = '" + geselecteerdeFilm + "'";
                command = new OracleCommand(query, conn);
                command.ExecuteNonQuery();
                verwijderd = true;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return verwijderd;
        }
    }
}