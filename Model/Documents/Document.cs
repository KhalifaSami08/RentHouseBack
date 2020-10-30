using System;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;

namespace Backend_RentHouse_Khalifa_Sami.Model.Documents
{
    class Document
    {
        
        private Word.Application wordApp;
        
        private Client client;
        private TYPECONTRACT type;

        public string fileDestPath = "C:\\Users\\Saaam\\Desktop\\RentHouse_Project_Khalifa_Sami\\DocumentsWord\\";
        private string filesTemplateLink = "C:\\Users\\Saaam\\Desktop\\RentHouse_Project_Khalifa_Sami\\DocumentsWord\\Templates\\";

        public Document(Client client, TYPECONTRACT type)
        {
            this.client = client;
            this.type = type;
            
            fileDestPath += client.name+"_"+client.surname+"_"+type+".docx";
            filesTemplateLink += "TEMPLATE_"+type+".docx";

            // Console.WriteLine(fileDestPath);
            // Console.WriteLine(filesTemplateLink);
        }

        public void GenerateDocument(Property.Property p,Contract c)
        {
            wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc;

            if (File.Exists(filesTemplateLink))
            {
                object readOnly = true;
                myWordDoc = wordApp.Documents.Open(filesTemplateLink, ref missing, ref readOnly);
                myWordDoc.Activate();
                GetDocument(p,c);

            }
            else
            {
                throw new Exception("TEMPLATE not Found!");
            }

            myWordDoc.SaveAs2(fileDestPath);
            myWordDoc.Close();
            wordApp.Quit();
        }

        private void GetDocument(Property.Property p,Contract c)
        {

            //find and replace
            FindAndReplace(wordApp, "<client_name>", client.name);
            FindAndReplace(wordApp, "<client_surname>", client.surname);
            FindAndReplace(wordApp, "<client_adress>", client.adress);
            FindAndReplace(wordApp, "<client_postalcode>", client.postalCode);
            FindAndReplace(wordApp, "<client_city>", client.city);
            FindAndReplace(wordApp, "<property_id>", p.idProperty);
            FindAndReplace(wordApp, "<property_adress>", p.adress);
            FindAndReplace(wordApp, "<date>", DateTime.Now.ToShortDateString());

            switch (type)
            {
                case TYPECONTRACT.BAIL:
                    GetBail(p,c);
                    break;
                
                case TYPECONTRACT.GARANT:
                    GetGarant(c);
                    break;

                case TYPECONTRACT.LIEU_ENTRE:
                    GetLieuentre(c);
                    break;

                case TYPECONTRACT.LIEU_SORTIE:
                    GetLieusortie(c);
                    break;

                case TYPECONTRACT.RESILIATION_ANTICIPE:
                    getRESIANTIP(c);
                    break;

                case TYPECONTRACT.CONGE_BAIL:
                    getCONGEBAIL(c);
                    break;

                default:
                    throw new Exception("Le type n'est pas valide ! ");
            }

        }

        private void GetBail(Property.Property p, Contract c)
        {
            
            FindAndReplace(wordApp, "<contrat_rentcost>", p.rentCost);
            FindAndReplace(wordApp, "<contrat_fixedcharges>", p.fixedChargesCost);
            FindAndReplace(wordApp, "<begin_contract>", c.beginContract);
            FindAndReplace(wordApp, "<end_contract>", c.endContract);
            FindAndReplace(wordApp, "<duration>", c.duration);
            FindAndReplace(wordApp, "<signature_date>", c.signatureDate);
        }
        
        private void GetGarant(Contract c)
        {
            FindAndReplace(wordApp, "<contract_garanteeAmount>", c.garanteeAmount);
            FindAndReplace(wordApp, "<contract_isGaranteePaidDate>", c.isGuaranteePaid);
            FindAndReplace(wordApp, "<contract_garanteePaidDate>", c.garanteePaidDate);
            FindAndReplace(wordApp, "<contract_isFirstMountPaid>", c.isFirstMountPaid);
        }

        private void GetLieuentre(Contract c)
        {
            FindAndReplace(wordApp, "<contrat_eau>", c.beginIndexWater);
            FindAndReplace(wordApp, "<contrat_electricite>", c.beginIndexElectricity);
            FindAndReplace(wordApp, "<contrat_gaz>", c.beginIndexGaz);
            FindAndReplace(wordApp, "<entry_date>", c.entryDate);
        }

        private void GetLieusortie(Contract c)
        {
            FindAndReplace(wordApp, "<contrat_eau>", c.endIndexWater);
            FindAndReplace(wordApp, "<contrat_electricite>", c.endIndexElectricity);
            FindAndReplace(wordApp, "<contrat_gaz>", c.endIndexGaz);
            FindAndReplace(wordApp, "<release_date>", c.releaseDate);
        }

        private void getRESIANTIP(Contract c)
        {
            FindAndReplace(wordApp, "<contract_endDate>", c.endContract);
        }

        private void getCONGEBAIL(Contract c)
        {
            FindAndReplace(wordApp, "<begin_contract>", c.beginContract);
            FindAndReplace(wordApp, "<end_contract>", c.endContract);
        }

        //Find and Replace Method
        private void FindAndReplace(Word.Application wordAppli, object toFindText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllforms = false;
            object forward = true;
            object format = false;
            object wrap = 1;
            
                wordAppli.Selection.Find.Execute(ref toFindText,
                ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundLike,
                ref nmatchAllforms, ref forward,
                ref wrap, ref format, ref replaceWithText);
        }

    }
}