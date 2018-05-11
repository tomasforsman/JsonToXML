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
using System.Xml.Serialization;
using System.IO;

namespace JsonToXML
{
    public class Accounts
    {
        public Active_Accounts[] active_accounts { get; set; }
        public Terminated_Accounts[] terminated_accounts { get; set; }
        public Account_List[] account_list { get; set; }

        public void SaveXML(string saveName)
        {
            using (var stream = new FileStream(saveName, FileMode.Create))
            {
                XmlSerializer XML = new XmlSerializer(typeof(Accounts));
                XML.Serialize(stream, this);
            }
        }
    }

    public class Active_Accounts
    {
        public string id { get; set; }
        public string bban { get; set; }
        public string iban { get; set; }
        public Primary_Account_Owner primary_account_owner { get; set; }
        public string currency_code { get; set; }
        public Disposable_Amount disposable_amount { get; set; }
        public Balance balance { get; set; }
        public Approved_Credit_Amount approved_credit_amount { get; set; }
        public Reserved_Amount reserved_amount { get; set; }
        public Account_Type account_type { get; set; }
        public string custom_name { get; set; }
        public Actions actions { get; set; }
    }

    public class Primary_Account_Owner
    {
        public string personal_identity_number { get; set; }
        public string name { get; set; }
    }

    public class Disposable_Amount
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Balance
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Approved_Credit_Amount
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Reserved_Amount
    {
        public string amount { get; set; }
        public string currency_code { get; set; }
    }

    public class Account_Type
    {
        public string code { get; set; }
        public string text { get; set; }
    }

    public class Actions
    {
        public bool withdrawal { get; set; }
        public bool deposit { get; set; }
        public bool payment { get; set; }
    }

    public class Terminated_Accounts
    {
        public string id { get; set; }
        public string iban { get; set; }
        public string bban { get; set; }
        public string termination_date { get; set; }
    }

    public class Account_List
    {
        public string id { get; set; }
        public string currency { get; set; }
        public string product { get; set; }
        public string account_type { get; set; }
        public string iban { get; set; }
        public string bic { get; set; }
        public string bban { get; set; }
        public string clearingnumber { get; set; }
        public string account_number { get; set; }
        public Balance1[] balances { get; set; }
    }

    public class Balance1
    {
        public Booked booked { get; set; }
    }

    public class Booked
    {
        public Amount amount { get; set; }
        public string date { get; set; }
    }

    public class Amount
    {
        public string currency { get; set; }
        public int content { get; set; }
    }

}