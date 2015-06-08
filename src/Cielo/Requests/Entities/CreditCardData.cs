using Cielo.Configuration;
using Cielo.Enums;
using DynamicBuilder;

namespace Cielo.Requests.Entities
{
    public class CreditCardData : ICieloPartialRequest
    {
        private readonly CreditCardExpiration _expiration;

        public CreditCardData(string creditCardNumber,
            CreditCardExpiration expiration,
            SecurityCodeIndicator indicator,
            string securityCode)
        {
            _expiration = expiration;
            CreditCardNumber = creditCardNumber;
            Indicator = indicator;
            SecurityCode = securityCode;
        }

        public string CreditCardNumber { get; private set; }

        public string Expiration
        {
            get { return _expiration.ToString(); }
        }

        public SecurityCodeIndicator Indicator { get; private set; }
        public string SecurityCode { get; private set; }

        public void ToXml(dynamic xmlParent, IConfiguration configuration = null)
        {
            xmlParent.dados_portador(Xml.Fragment(c =>
            {
                c.numero(CreditCardNumber);
                c.validade(Expiration);
                c.indicador((int) Indicator);
                c.codigo_seguranca(SecurityCode);
                c.token(string.Empty); //not supported yet :P
            }));
        }
    }
}