using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.DatabaseRepository.Abastractions;
using Template.DatabaseRepository.Context;
using Template.Domain.Entities;
using Template.Domain.Interface.IRepositories;

namespace Template.DatabaseRepository.Repositories
{
    public class CorretorRepository : AuditRepository<Corretor, long>, ICorretorRepository
    {
        public CorretorRepository(TemplateContext context) : base(context)
        {
        }
    }
}
