using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace LePalaisBonbonGenerator
{
    class Randomizer
    {
        string[] queryData = new string[15];
        Random rNumber = new Random();
        int i;
        int idCarton = 0; //idCarton 
        int idCmd = 0;                       //IdCommande 
        int idContenu = 0;
        DateTime start;  //dateCommande
        StreamWriter queryfile;
        int fileCount = 1;
        public int dayMax = 5;
        public int startYear = 2010;
        public int nDayPercent =60;
        public int nbCmdMax = 300;
        public Randomizer()
        {
            start = new DateTime(startYear, 1, 1);
        }

        public void randomize()
        {          
            this.randomCmd();
        }

        private void randomCmd()
        {


            idCmd++;                       //IdCommande 
            int qtCarton = rNumber.Next(1, nbCmdMax); //qtCommande
            int idPays = rNumber.Next(1, 34);     //idPays
            this.RandomDate();
            //dateCommande

            this.queryData[0] = idCmd.ToString();
            this.queryData[1] = qtCarton.ToString();
            this.queryData[2] = idPays.ToString();
            this.queryData[3] = start.Year + "-" + start.Month + "-" + start.Day + " " + start.TimeOfDay;

          //  System.Diagnostics.Debug.WriteLine("INSERT INTO \"SYSTEM\".\"COMMANDE\" (ID_COMMANDE, QT_COMMANDE, ID_PAYS, DATE_COMMANDE) VALUES (\'"+ this.queryData[0] + "\', \'" + this.queryData[1] + "', \'" + this.queryData[2] + "\', TO_DATE(\'" + this.queryData[3] + "\', \'YYYY-MM-DD HH24:MI:SS\'));");
            queryfile.WriteLine("INSERT INTO \"SYSTEM\".\"COMMANDE\" (ID_COMMANDE, QT_COMMANDE, ID_PAYS, DATE_COMMANDE) VALUES (\'" + this.queryData[0] + "\', \'" + this.queryData[1] + "', \'" + this.queryData[2] + "\', TO_DATE(\'" + this.queryData[3] + "\', \'YYYY-MM-DD HH24:MI:SS\'));");
            for (int i = 0; i < qtCarton; i++)
            {
                this.randomCarton();

            }


        }

        private void randomCarton()
        {
            idCarton++; //idCarton **
            int qtMax;
            int condCarton = rNumber.Next(1, 4); //idConditionement
            int qtCond; //qt 

            this.queryData[4] = idCarton.ToString();
            this.queryData[5] = idCmd.ToString();
            this.queryData[6] = condCarton.ToString();
            this.queryData[7] = "1";
            switch (condCarton)
            {
                case 1:
                    qtMax = 11;
                    break;
                case 2:
                    qtMax = 26;
                    break;
                case 3:
                    qtMax = 201;
                    break;
                default:
                    qtMax = 11;
                    break;
            }
          //  System.Diagnostics.Debug.WriteLine("INSERT INTO \"SYSTEM\".\"CARTON\" (ID_CARTON, ID_COMMANDE, ID_CONDITIONNEMENT, QT_CARTONS) VALUES ('" + this.queryData[4] + "', '" + this.queryData[5] + "', '" + this.queryData[6] + "', '" + this.queryData[7] + "');");
            queryfile.WriteLine("INSERT INTO \"SYSTEM\".\"CARTON\" (ID_CARTON, ID_COMMANDE, ID_CONDITIONNEMENT, QT_CARTONS) VALUES ('" + this.queryData[4] + "', '" + this.queryData[5] + "', '" + this.queryData[6] + "', '" + this.queryData[7] + "');");

            for (int i = 1; i <= qtMax; i++) {
                qtCond = rNumber.Next(1, qtMax);
                
               
               

                if ((qtCond + i) >= qtMax) {
                    qtCond = qtMax - i;
                    i = qtMax;
                }
                else {
                    i = i + qtCond - 1;
                }
                this.queryData[14] = qtCond.ToString();
                this.randomRef();
            }

        }


        private void randomRef()
        {
            idContenu++; //idContenu **
            int bonbon = rNumber.Next(1, 27); //idBonbon
            int couleur = rNumber.Next(1, 8); //idCouleur
            int texture = rNumber.Next(1, 2); //idTexture
            int variante = rNumber.Next(1, 3); //idVariante

            this.queryData[8] = idContenu.ToString();
            this.queryData[9] = idCarton.ToString();
            this.queryData[10] = bonbon.ToString();
            this.queryData[11] = couleur.ToString();
            this.queryData[12] = texture.ToString();
            this.queryData[13] = variante.ToString();
           // System.Diagnostics.Debug.WriteLine("INSERT INTO \"SYSTEM\".\"CONTENU_CARTONS\" (ID_CONTENU, ID_CARTON, ID_BONBON, ID_COULEUR, ID_TEXTURE, ID_VARIANTE, QUANTITE) VALUES ('" + this.queryData[8] + "', '" + this.queryData[4] + "', '" + this.queryData[10] + "', '" + this.queryData[11] + "', '" + this.queryData[12] + "', '" + this.queryData[13] + "', '" + this.queryData[14] + "');");
            queryfile.WriteLine("INSERT INTO \"SYSTEM\".\"CONTENU_CARTONS\" (ID_CONTENU, ID_CARTON, ID_BONBON, ID_COULEUR, ID_TEXTURE, ID_VARIANTE, QUANTITE) VALUES ('" + this.queryData[8] + "', '" + this.queryData[4] + "', '" + this.queryData[10] + "', '" + this.queryData[11] + "', '" + this.queryData[12] + "', '" + this.queryData[13] + "', '" + this.queryData[14] + "');");
        }

   

      

       private void RandomDate()
        {

            if (rNumber.Next(0,100) < nDayPercent)
             {
            start = this.start.AddDays(rNumber.Next(0, dayMax));
            }
            
        }

        public void closefile()
        {
            queryfile.Close();
        }

        public void openFile()
        {
            queryfile = new StreamWriter("donnee V." + fileCount.ToString() + ".sql");
            fileCount++;
        }
    
}


}
