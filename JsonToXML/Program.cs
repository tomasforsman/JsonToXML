/*
MIT License

Copyright (c) 2018 tomasforsman

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
*/

using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml;

namespace JsonToXML
{


    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string jsonSEB = File.ReadAllText(@"seb-accounts.json").ToString();
                AccountsSEB accountsSEB = JsonConvert.DeserializeObject<AccountsSEB>(jsonSEB);

                string jsonSwedbank = File.ReadAllText(@"swedbank-accounts.json").ToString();
                AccountsSwedbank accountsSwedbank = JsonConvert.DeserializeObject<AccountsSwedbank>(jsonSwedbank);

                using (XmlWriter writer = XmlWriter.Create("merged-accounts.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Accounts");

                    SerializeSEB(writer, accountsSEB);
                    SerializeSwedbank(writer, accountsSwedbank);

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }


            }

            catch (Exception ex)
            {
                Console.Write(ex.Message.ToString());
                throw ex;
            }
            Console.WriteLine("merged-accounts.xml created, press any key to continue...");
            Console.ReadKey();
        }

        private static void SerializeSEB(XmlWriter writer, AccountsSEB accountsSEB)
        {
            foreach (var account in accountsSEB.ActiveAccounts)
            {
                writer.WriteStartElement("Account");
                writer.WriteAttributeString("id", account.Id.ToString());
                writer.WriteAttributeString("active", "true");
                writer.WriteElementString("iban", account.Iban);
                writer.WriteElementString("bic", "ESSESESS");
                writer.WriteElementString("currency", account.CurrencyCode);
                writer.WriteElementString("accountType", account.AccountType.Text);
                writer.WriteElementString("accountName", account.CustomName);
                writer.WriteElementString("customerName", account.PrimaryAccountOwner.Name);
                writer.WriteElementString("customerId", account.PrimaryAccountOwner.PersonalIdentityNumber);
                writer.WriteElementString("clearingNumber", "N/A");
                writer.WriteElementString("accountNumber", "N/A");
                writer.WriteElementString("currentBalance", account.Balance.Amount);
                writer.WriteElementString("currentCurrency", account.Balance.CurrencyCode);
                writer.WriteElementString("availableBlanace", account.DisposableAmount.Amount);
                writer.WriteElementString("availableCurrency", account.DisposableAmount.CurrencyCode);
                writer.WriteElementString("creditBalance", account.ApprovedCreditAmount.Amount);
                writer.WriteElementString("creditCurrency", account.ApprovedCreditAmount.CurrencyCode);
                writer.WriteStartElement("availableActions","test");
                if (account.Actions.Withdrawal == false)
                {
                    writer.WriteAttributeString("withdrawal", "false");
                }
                else
                {
                    writer.WriteAttributeString("withdrawal", "true");
                }
                if (account.Actions.Withdrawal == false)
                {
                    writer.WriteAttributeString("deposit", "false");
                }
                else
                {
                    writer.WriteAttributeString("deposit", "true");
                }
                if (account.Actions.Withdrawal == false)
                {
                    writer.WriteAttributeString("payment", "false");
                }
                else
                {
                    writer.WriteAttributeString("payment", "true");
                }

                writer.WriteEndElement();
                writer.WriteEndElement();
            }
            foreach(var account in accountsSEB.TerminatedAccounts)
            {
                writer.WriteStartElement("Account");
                writer.WriteAttributeString("id", account.Id.ToString());
                writer.WriteAttributeString("active", "false");
                writer.WriteElementString("iban", account.Iban);

                writer.WriteEndElement();
            }

        }

        private static void SerializeSwedbank(XmlWriter writer, AccountsSwedbank accountsSwedbank)
        {
            foreach (var account in accountsSwedbank.AccountList)
            {
                if (account.Balances != null)
                {
                    writer.WriteStartElement("Account");
                    writer.WriteAttributeString("id", account.Id.ToString());
                    writer.WriteAttributeString("active", "true");
                    writer.WriteElementString("iban", account.Iban);
                    writer.WriteElementString("bic", account.Bic);
                    writer.WriteElementString("currency", account.Currency);
                    writer.WriteElementString("accountType", account.Product);
                    writer.WriteElementString("accountName", account.Product);
                    writer.WriteElementString("customerName", "N/A");
                    writer.WriteElementString("customerId", "N/A");
                    writer.WriteElementString("clearingNumber", account.Clearingnumber);
                    writer.WriteElementString("accountNumber", account.AccountNumber);
                    foreach (var balance in account.Balances)
                    {
                        writer.WriteElementString("currentBalance", balance.Booked.Amount.Content.ToString());
                        writer.WriteElementString("currentCurrency", balance.Booked.Amount.Currency);
                        writer.WriteElementString("availableBlanace", balance.Booked.Amount.Content.ToString());
                        writer.WriteElementString("availableCurrency", balance.Booked.Amount.Currency);
                        writer.WriteElementString("creditBalance", "N/A");
                        writer.WriteElementString("creditCurrency", "N/A");
                    }
                    writer.WriteStartElement("availableActions", "test");
                    writer.WriteAttributeString("withdrawal", "true");
                    writer.WriteAttributeString("deposit", "true");
                    writer.WriteAttributeString("payment", "true");
                

                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                else
                {
                    writer.WriteStartElement("Account");
                    writer.WriteAttributeString("id", account.Id.ToString());
                    writer.WriteAttributeString("active", "false");
                    writer.WriteElementString("iban", account.Iban);
                    writer.WriteElementString("bic", account.Bic);
                    writer.WriteElementString("currency", account.Currency);
                    writer.WriteElementString("accountType", account.Product);
                    writer.WriteElementString("accountName", account.Product);
                    writer.WriteElementString("customerName", "N/A");
                    writer.WriteElementString("customerId", "N/A");
                    writer.WriteElementString("clearingNumber", account.Clearingnumber);
                    writer.WriteElementString("accountNumber", account.AccountNumber);

                    writer.WriteEndElement();
                }
            }
            }
        }

    }