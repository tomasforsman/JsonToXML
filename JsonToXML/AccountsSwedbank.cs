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

    public class AccountsSwedbank
    {
        [JsonProperty("account_list")]
        public List<AccountList> AccountList { get; set; }
    }

    public class AccountList
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("product")]
        public string Product { get; set; }

        [JsonProperty("account_type")]
        public string AccountType { get; set; }

        [JsonProperty("iban")]
        public string Iban { get; set; }

        [JsonProperty("bic")]
        public string Bic { get; set; }

        [JsonProperty("bban")]
        public string Bban { get; set; }

        [JsonProperty("clearingnumber")]
        public string Clearingnumber { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("balances", NullValueHandling = NullValueHandling.Ignore)]
        public List<Balance> Balances { get; set; }
    }

    public class Balance
    {
        [JsonProperty("booked")]
        public Booked Booked { get; set; }
    }

    public class Booked
    {
        [JsonProperty("amount")]
        public Amount Amount { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }
    }

    public class Amount
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("content")]
        public long Content { get; set; }
    }
}
