using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities;

namespace Template.UnitTests.Fixture
{
    public class PessoaFixture
    {
        public PessoaFixture() { }

        public Pessoa CriarPessoaFisica()
        {
            Faker faker = new Faker();

            return new Pessoa()
            {
                CpfCnpj = "123456",
                Email = faker.Person.Email,
                Nome = faker.Person.FirstName,
                Telefone = faker.Person.Phone,
                TipoPessoa = TipoPessoa.Fisica
            };
        }

        public Pessoa CriarPessoaJuridica()
        {
            Faker faker = new Faker();

            return new Pessoa()
            {
                CpfCnpj = "123456",
                Email = faker.Person.Email,
                Nome = faker.Company.CompanyName(),
                Telefone = faker.Person.Phone,
                TipoPessoa = TipoPessoa.Juridica
            };
        }

        public Corretor CriarCorretor()
        {
            Faker faker = new Faker();
            Corretor corretor =   new Corretor()
            {
                CpfCnpj = "123456",
                Email = faker.Person.Email,
                Nome = faker.Company.CompanyName(),
                Telefone = faker.Person.Phone,
                TipoPessoa = TipoPessoa.Juridica,
                Comissao = 10,

            };
            
            return corretor;
        }
    }
}
