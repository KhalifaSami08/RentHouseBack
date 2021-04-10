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

            _fileName = $"{client.Name}_{client.Surname}_{type}.docx";
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
            FindAndReplace(_wordApp, "<client_name>", _client.Name);
            FindAndReplace(_wordApp, "<client_surname>", _client.Surname);
            FindAndReplace(_wordApp, "<client_address>", _client.Address);
            FindAndReplace(_wordApp, "<client_postalcode>", _client.PostalCode);
            FindAndReplace(_wordApp, "<client_city>", _client.City);
            FindAndReplace(_wordApp, "<property_id>", p.IdProperty);
            FindAndReplace(_wordApp, "<property_address>", p.Address);
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
            FindAndReplace(_wordApp, "<contract_rentCost>", p.RentCost);
            FindAndReplace(_wordApp, "<contract_fixedCharges>", p.FixedChargesCost);
            FindAndReplace(_wordApp, "<begin_contract>", c.BeginContract);
            FindAndReplace(_wordApp, "<end_contract>", c.EndContract);
            FindAndReplace(_wordApp, "<duration>", c.Duration);
            FindAndReplace(_wordApp, "<signature_date>", c.SignatureDate);
        }
        
        private void GetGuarantor(Contract c)
        {
            FindAndReplace(_wordApp, "<contract_guaranteeAmount>", c.GuaranteeAmount);
            FindAndReplace(_wordApp, "<contract_isGuaranteePaidDate>", c.IsGuaranteePaid);
            FindAndReplace(_wordApp, "<contract_guaranteePaidDate>", c.GaranteePaidDate);
            FindAndReplace(_wordApp, "<contract_isFirstMountPaid>", c.IsFirstMountPaid);
        }

        private void GetEntryState(Contract c)
        {
            FindAndReplace(_wordApp, "<contract_eau>", c.BeginIndexWater);
            FindAndReplace(_wordApp, "<contract_electricity>", c.BeginIndexElectricity);
            FindAndReplace(_wordApp, "<contract_gaz>", c.BeginIndexGaz);
            FindAndReplace(_wordApp, "<entry_date>", c.EntryDate);
        }

        private void GetExitInventory(Contract c)
        {
            FindAndReplace(_wordApp, "<contract_eau>", c.EndIndexWater);
            FindAndReplace(_wordApp, "<contract_electricity>", c.EndIndexElectricity);
            FindAndReplace(_wordApp, "<contract_gaz>", c.EndIndexGaz);
            FindAndReplace(_wordApp, "<release_date>", c.ReleaseDate);
        }

        private void GetEarlyTermination(Contract c)
        {
            FindAndReplace(_wordApp, "<contract_endDate>", c.EndContract);
        }

        private void GetLeaseCancellation(Contract c)
        {
            FindAndReplace(_wordApp, "<begin_contract>", c.BeginContract);
            FindAndReplace(_wordApp, "<end_contract>", c.EndContract);
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