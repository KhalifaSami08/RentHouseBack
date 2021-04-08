using System;
using System.IO;
using System.Reflection;
using Microsoft.Office.Interop.Word;

namespace Backend_RentHouse_Khalifa_Sami.Model.Documents
{
    internal class Document
    {
        private Application _wordApp;
        
        private readonly Client _client;
        private readonly TypeContract _type;
        private readonly string _fileName;

        private readonly string _fileDestPath = Directory.GetCurrentDirectory()+"\\DocumentsWord\\";
        private readonly string _filesTemplateLink = Directory.GetCurrentDirectory()+"\\DocumentsWord\\Templates\\";

        
        public Document(Client client, TypeContract type)
        {
            _client = client;
            _type = type;

            _fileName = $"{client.name}_{client.surname}_{type}.docx";
            _fileDestPath += _fileName;
            _filesTemplateLink += $"TEMPLATE_{type}.docx";
        }

        public string GetFileName()
        {
            return _fileName;
        }

        public string GenerateDocument(Property p,Contract c)
        {
            _wordApp = new Application();
            object missing = Missing.Value;
            Microsoft.Office.Interop.Word.Document myWordDoc;

            if (File.Exists(_filesTemplateLink))
            {
                object readOnly = false;
                myWordDoc = _wordApp.Documents.Open(_filesTemplateLink, ref missing, ref readOnly);
                myWordDoc.Activate();
                GetDocument(p,c);
            }
            else
            {
                throw new Exception("TEMPLATE not Found!");
            }
            
            myWordDoc.SaveAs2(_fileDestPath);
            myWordDoc.Close();
            _wordApp.Quit();
            return _fileDestPath;
        }

        private void GetDocument(Property p,Contract c)
        {
            //find and replace
            FindAndReplace(_wordApp, "<client_name>", _client.name);
            FindAndReplace(_wordApp, "<client_surname>", _client.surname);
            FindAndReplace(_wordApp, "<client_address>", _client.address);
            FindAndReplace(_wordApp, "<client_postalcode>", _client.postalCode);
            FindAndReplace(_wordApp, "<client_city>", _client.city);
            FindAndReplace(_wordApp, "<property_id>", p.idProperty);
            FindAndReplace(_wordApp, "<property_address>", p.address);
            FindAndReplace(_wordApp, "<date>", DateTime.Now.ToShortDateString());

            switch (_type)
            {
                case TypeContract.Lease:
                    GetLease(p,c);
                    break;
                
                case TypeContract.Guarantor:
                    GetGuarantor(c);
                    break;

                case TypeContract.EntryState:
                    GetEntryState(c);
                    break;

                case TypeContract.ExitInventory:
                    GetExitInventory(c);
                    break;

                case TypeContract.EarlyTermination:
                    GetEarlyTermination(c);
                    break;

                case TypeContract.LeaseCancellation:
                    GetLeaseCancellation(c);
                    break;

                default:
                    throw new Exception("Type not valid ! ");
            }
        }

        private void GetLease(Property p, Contract c)
        {
            FindAndReplace(_wordApp, "<contract_rentCost>", p.rentCost);
            FindAndReplace(_wordApp, "<contract_fixedCharges>", p.fixedChargesCost);
            FindAndReplace(_wordApp, "<begin_contract>", c.beginContract);
            FindAndReplace(_wordApp, "<end_contract>", c.endContract);
            FindAndReplace(_wordApp, "<duration>", c.duration);
            FindAndReplace(_wordApp, "<signature_date>", c.signatureDate);
        }
        
        private void GetGuarantor(Contract c)
        {
            FindAndReplace(_wordApp, "<contract_guaranteeAmount>", c.guaranteeAmount);
            FindAndReplace(_wordApp, "<contract_isGuaranteePaidDate>", c.isGuaranteePaid);
            FindAndReplace(_wordApp, "<contract_guaranteePaidDate>", c.garanteePaidDate);
            FindAndReplace(_wordApp, "<contract_isFirstMountPaid>", c.isFirstMountPaid);
        }

        private void GetEntryState(Contract c)
        {
            FindAndReplace(_wordApp, "<contract_eau>", c.beginIndexWater);
            FindAndReplace(_wordApp, "<contract_electricity>", c.beginIndexElectricity);
            FindAndReplace(_wordApp, "<contract_gaz>", c.beginIndexGaz);
            FindAndReplace(_wordApp, "<entry_date>", c.entryDate);
        }

        private void GetExitInventory(Contract c)
        {
            FindAndReplace(_wordApp, "<contract_eau>", c.endIndexWater);
            FindAndReplace(_wordApp, "<contract_electricity>", c.endIndexElectricity);
            FindAndReplace(_wordApp, "<contract_gaz>", c.endIndexGaz);
            FindAndReplace(_wordApp, "<release_date>", c.releaseDate);
        }

        private void GetEarlyTermination(Contract c)
        {
            FindAndReplace(_wordApp, "<contract_endDate>", c.endContract);
        }

        private void GetLeaseCancellation(Contract c)
        {
            FindAndReplace(_wordApp, "<begin_contract>", c.beginContract);
            FindAndReplace(_wordApp, "<end_contract>", c.endContract);
        }

        //Find and Replace Method
        private static void FindAndReplace(_Application wordApp, object toFindText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllforms = false;
            object forward = true;
            object format = false;
            object wrap = 1;
            
            wordApp.Selection.Find.Execute(ref toFindText,
            ref matchCase, ref matchWholeWord,
            ref matchWildCards, ref matchSoundLike,
            ref nmatchAllforms, ref forward,
            ref wrap, ref format, ref replaceWithText);
        }

    }
}