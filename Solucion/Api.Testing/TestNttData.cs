using System;
using Xunit;
using Application.Main;
using Application.DTO;
using Api.Testing.Helpers;
using Microsoft.Extensions.Options;
using Application.Interface;
using System.Collections.Generic;

namespace Api.Testing
{
    public class TestNttData
    {
        private readonly IClientApplication _clientApplication;
        private readonly IPersonApplication _personApplication;
        private readonly IAccountApplication _accountApplication;
        private readonly AppSettings _appSettings;

        public TestNttData(IClientApplication clientApplication, IPersonApplication personApplication, IAccountApplication accountApplication, IOptions<AppSettings> appSettings)
        {
            this._clientApplication = clientApplication;
            this._personApplication = personApplication;
            this._accountApplication = accountApplication;
            this._appSettings = appSettings.Value;
        }

        [Fact]
        public void CreacionUsuario()
        {
            bool afectadosP = false;
            bool afectadosC = false;

            List<PersonDTO> persons = new List<PersonDTO>();
            List<ClientDTO> clients = new List<ClientDTO>();
            PersonDTO p = new PersonDTO()
            {
                CodigoPersona = 0,
                Direccion = "Otavalo sn y principal",
                Edad = 30,
                Genero = "M",
                Identificacion = "1720079355",
                Nombre = "Jose Lema ",
                Telefono = "098254785"
            };
            persons.Add(p);

            p = new PersonDTO()
            {
                CodigoPersona = 0,
                Direccion = "Amazonas y  NNUU",
                Edad = 30,
                Genero = "M",
                Identificacion = "1720079355",
                Nombre = "Marianela Montalvo",
                Telefono = "097548965"
            };
            persons.Add(p);

            p = new PersonDTO()
            {
                CodigoPersona = 0,
                Direccion = "13 junio y Equinoccial",
                Edad = 30,
                Genero = "M",
                Identificacion = "1720079355",
                Nombre = "Juan Osorio",
                Telefono = "098874587"
            };
            persons.Add(p);

            ClientDTO c = new ClientDTO()
            {
                Clave = "1234",
                Clientid = 1122,
                CodigoCliente = 0,
            };
            clients.Add(c);
            c = new ClientDTO()
            {
                Clave = "5678",
                Clientid = 1123,
                CodigoCliente = 0,
            };
            clients.Add(c);

            c = new ClientDTO()
            {
                Clave = "1245",
                Clientid = 1124,
                CodigoCliente = 0,
            };
            clients.Add(c);

            var index = 0;
            foreach (var per in persons)
            {
                var afectadoPersona = _personApplication.Insert(per);
                afectadosP = afectadoPersona.IsSuccess;
                if (afectadoPersona.IsSuccess)
                {
                    var responsePersona = _personApplication.Get(per.Telefono);
                    clients[index].CodigoPersona = responsePersona.Data.CodigoPersona;

                    var afectadoCliente = _clientApplication.Insert(clients[index]);
                    afectadosC = afectadoCliente.IsSuccess;
                }
                index++;
            }

            
            Assert.True(afectadosP && afectadosC);
        }

        [Fact]
        public void CrearCuenta()
        {
            bool afectadoCuenta = false;
            List<AccountDTO> cuentas = new List<AccountDTO>();
            AccountDTO cuenta = new AccountDTO()
            {
                CodigoCuenta = 0,
                Estado = true,
                NumeroCuenta = "478758",
                SaldoInicial =2000,
                TipoCuenta = "Ahorro"
            };
            cuentas.Add(cuenta);

            cuenta = new AccountDTO()
            {
                CodigoCuenta = 0,
                Estado = true,
                NumeroCuenta = "225487",
                SaldoInicial = 100,
                TipoCuenta = "Corriente"
            };
            cuentas.Add(cuenta);

            cuenta = new AccountDTO()
            {
                CodigoCuenta = 0,
                Estado = true,
                NumeroCuenta = "495878",
                SaldoInicial = 0,
                TipoCuenta = "Ahorro"
            };
            cuentas.Add(cuenta);

            foreach (var account in cuentas)
            {
                var afectadoCuentas = _accountApplication.Insert(account);
                afectadoCuenta = afectadoCuentas.IsSuccess;
            }
            Assert.True(afectadoCuenta);
        }
    }
}
