﻿using Azure.Core;
using Bogus;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Commands.Request;
using Template.Domain.Commands.Response;
using Template.Domain.Entities;
using Template.Integration.Tests.Fixture;

namespace Template.Integration.Tests.Controllers
{
    public class CorretorTest: IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        public CorretorTest(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Validate_SaveCorretor_ShuldBeTrue()
        {

            Faker faker = new Faker();
            NewCorretorRequest corretor = new NewCorretorRequest()
            {
                CpfCnpj = "99999999999",
                Email = faker.Person.Email,
                Nome = faker.Company.CompanyName(),
                Telefone = faker.Person.Phone,
                TipoPessoa = TipoPessoa.Juridica,
                Comissao = 10,

            };

            // Act
            var content = ContentHelper.GetStringContent(corretor);
            var response = await _client.PostAsync("/corretores", content);

            var result = JsonConvert.DeserializeObject<GenericResponse>(response.Content.ReadAsStringAsync().Result);

            Assert.NotNull(result);
            Assert.True(result.Success);


        }

        [Fact]
        public async Task Validate_SaveCorretorWithoutCpfCnpj_ShouldBeFalse()
        {

            Faker faker = new Faker();
            NewCorretorRequest corretor = new NewCorretorRequest()
            {
                
                Email = faker.Person.Email,
                Nome = faker.Company.CompanyName(),
                Telefone = faker.Person.Phone,
                TipoPessoa = TipoPessoa.Juridica,
                Comissao = 10,

            };

            // Act
            var content = ContentHelper.GetStringContent(corretor);
            var response = await _client.PostAsync("/corretores", content);

            var result = JsonConvert.DeserializeObject<GenericResponse>(response.Content.ReadAsStringAsync().Result);

            Assert.NotNull(result);
            Assert.False(result.Success);



        }
    }
}
