using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.UnitTests.Fixture;

namespace Template.UnitTests.Entities
{
    public class CorretorTest
    {
        

        [Fact(DisplayName = "Validar se o nome é nulo ou vazio")]
        [Trait("Corretor", "Validar se o nome é nulo")]
        public void Validate_Name_WhenNull_ShouldReturnFalse()
        {
            var corretor = new PessoaFixture().CriarCorretor();
            corretor.Nome = null;
            var result = corretor.Validate();

            Assert.False(result);
            Assert.Equal(corretor.Errors?.Count(), 1);
            Assert.True(corretor.Errors?.ElementAt(0).Equals("O campo nome é obrigatório."));
        }
    }
}
