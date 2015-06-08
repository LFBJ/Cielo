﻿namespace Cielo.Responses
{
    public class CreateTransactionResponse : CieloResponse<CreateTransactionResponse>
    {
        public CreateTransactionResponse(string content)
            : base(content)
        {
            Map(c => c.Tid, "tid");
            Map(c => c.Pan, "pan");
            Map(c => c.AuthenticationUrl, "url-autenticacao");
        }

        public string Tid { get; set; }
        public string AuthenticationUrl { get; set; }
        public string Pan { get; set; }

        public override string ToString()
        {
            return string.Format("Tid: {0}, Pan: {1}", Tid, Pan);
        }
    }
}