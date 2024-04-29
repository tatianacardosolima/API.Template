using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Commands.Request;
using Template.Domain.Commands.Response;
using Template.Domain.Entities;
using Template.Domain.Interface.IRepositories;
using Template.Shared.Extensions;
using Template.Shared.Interfaces.IRepositories;
using Template.Shared.Interfaces.IResponse;

namespace Template.Domain.Handlers.Corretores
{
    public class AddNewCorretorHandler : IRequestHandler<NewCorretorRequest, IGenericResponse>
    {
        
        private readonly ICorretorRepository _repository;
        private readonly IMapper _mapper;

        public AddNewCorretorHandler(ICorretorRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IGenericResponse> Handle(NewCorretorRequest request, CancellationToken cancellationToken)
        {

            
            var entity = _mapper.Map<Corretor>(request);

            DomainException.ThrowWhenInvalidEntity(entity);
            ///if (a_repository.ExistsAsync)
            await _repository.InsertAsync(entity);
            await _repository.SaveChangesAsync();
            return new GenericResponse(true, "Corretor inserido com sucesso");        }
    }
}
