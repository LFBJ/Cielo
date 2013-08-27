﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Awesomely.Extensions;
using Cielo;
using Cielo.Configuration;
using Cielo.Enums;
using Cielo.Requests;
using DynamicBuilder;
using FluentAssertions;
using NUnit.Framework;

namespace CieloTests
{
    public class RequisicaoTransacaoTests
    {
        private const string ExpectedXml = @"<?xml version=""1.0"" encoding=""utf-8""?>
                                <requisicao-transacao id=""b646a02f-9983-4df8-91b9-75b48345715a"" versao=""1.3.0"">
                                    <dados-ec>
                                        <numero>1001734898</numero>
                                        <chave>e84827130b9837473681c2787007da5914d6359947015a5cdb2b8843db0fa832</chave>
                                    </dados-ec>
                                    <dados-pedido>
                                        <numero>624726783</numero>
                                        <valor>1000</valor>
                                        <moeda>986</moeda>
                                        <data-hora>2013-02-18T16:45:12</data-hora>
                                        <descricao>[origem:172.16.34.66]</descricao>
                                        <idioma>PT</idioma>
                                        <soft-descriptor/>
                                    </dados-pedido>
                                    <forma-pagamento>
                                        <bandeira>visa</bandeira>
                                        <produto>1</produto>
                                        <parcelas>1</parcelas>
                                    </forma-pagamento>
                                    <url-retorno>http://localhost:7001/lojaexemplo-2.1/retorno.jsp</url-retorno>
                                    <autorizar>3</autorizar>
                                    <capturar>false</capturar>
                                    <gerar-token>false</gerar-token>
                                </requisicao-transacao>";

        [Test]
        public void ToXml_ShouldGenerateAXmlAsExpected()
        {
            var transactionRequest = new RequisicaoTransacao(
                    new FormaPagamento(Bandeira.Visa, TipoVenda.CreditoAVista),
                    new RequisicaoTransacaoOpcoes(TipoAutorizacao.AutorizarSemPassarPorAutenticacao, capturar: false),
                    new ConfiguratioFake());

            transactionRequest
                        .ToXml(indent: false)
                        .RemoveNewLinesAndSpaces()
                        .Should()
                        .Be(ExpectedXml.RemoveNewLinesAndSpaces());
        }
    }
}
