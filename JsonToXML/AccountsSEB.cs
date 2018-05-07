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
namespace JsonToXML
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class AccountsSEB
    {
        [JsonProperty("active_accounts")]
        public List<ActiveAccount> ActiveAccounts { get; set; }

        [JsonProperty("terminated_accounts")]
        public List<TerminatedAccount> TerminatedAccounts { get; set; }
    }

    public class ActiveAccount
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("bban")]
        public string Bban { get; set; }

        [JsonProperty("iban")]
        public string Iban { get; set; }

        [JsonProperty("primary_account_owner")]
        public PrimaryAccountOwner PrimaryAccountOwner { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("disposable_amount")]
        public ApprovedCreditAmount DisposableAmount { get; set; }

        [JsonProperty("balance")]
        public ApprovedCreditAmount Balance { get; set; }

        [JsonProperty("approved_credit_amount")]
        public ApprovedCreditAmount ApprovedCreditAmount { get; set; }

        [JsonProperty("reserved_amount")]
        public ApprovedCreditAmount ReservedAmount { get; set; }

        [JsonProperty("account_type")]
        public AccountType AccountType { get; set; }

        [JsonProperty("custom_name")]
        public string CustomName { get; set; }

        [JsonProperty("actions")]
        public Actions Actions { get; set; }
    }

    public class AccountType
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class Actions
    {
        [JsonProperty("withdrawal")]
        public bool Withdrawal { get; set; }

        [JsonProperty("deposit")]
        public bool Deposit { get; set; }

        [JsonProperty("payment")]
        public bool Payment { get; set; }
    }

    public class ApprovedCreditAmount
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }
    }

    public class PrimaryAccountOwner
    {
        [JsonProperty("personal_identity_number")]
        public string PersonalIdentityNumber { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class TerminatedAccount
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("iban")]
        public string Iban { get; set; }

        [JsonProperty("bban")]
        public string Bban { get; set; }

        [JsonProperty("termination_date")]
        public DateTimeOffset TerminationDate { get; set; }
    }
}
