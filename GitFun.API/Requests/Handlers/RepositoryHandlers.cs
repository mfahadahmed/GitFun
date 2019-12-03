using AutoMapper;
using GitFun.API.DTOs;
using GitFun.API.Models;
using GitFun.API.Repositories;
using GitFun.API.Requests.Commands;
using GitFun.API.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GitFun.API.Requests.Handlers
{
    public class CreateRepoCommandHandler : IRequestHandler<CreateRepoCommand, string>
    {
        private readonly IRepoRepository _repoRepository;

        public CreateRepoCommandHandler(IRepoRepository repoRepository)
        {
            _repoRepository = repoRepository;
        }

        public async Task<string> Handle(CreateRepoCommand request, CancellationToken cancellationToken)
        {
            var existingRepo = await _repoRepository.GetById(request.Repository.Id);
            if (existingRepo != null)
                throw new Exception("Repository alreay exists. Creation failed.");

            request.Repository.LastUpdated = DateTime.Now;
            await _repoRepository.Create(request.Repository);
            return request.Repository.Id;
        }
    }

    public class UpdateRepoCommandHandler : IRequestHandler<UpdateRepoCommand>
    {
        private readonly IRepoRepository _repoRepository;

        public UpdateRepoCommandHandler(IRepoRepository repoRepository)
        {
            _repoRepository = repoRepository;
        }

        public async Task<Unit> Handle(UpdateRepoCommand request, CancellationToken cancellationToken)
        {
            var existingRepo = await _repoRepository.GetById(request.Id);
            if (existingRepo == null)
                throw new Exception("Repository not found. Update failed");

            request.Repository.Id = existingRepo.Id;
            request.Repository.LastUpdated = DateTime.Now;
            await _repoRepository.Update(existingRepo.Id, request.Repository);

            return Unit.Value;
        }
    }

    public class DeleteRepoCommandHandler : IRequestHandler<DeleteRepoCommand>
    {
        private readonly IRepoRepository _repoRepository;

        public DeleteRepoCommandHandler(IRepoRepository repoRepository)
        {
            _repoRepository = repoRepository;
        }

        public async Task<Unit> Handle(DeleteRepoCommand request, CancellationToken cancellationToken)
        {
            var existingRepo = await _repoRepository.GetById(request.Id);
            if (existingRepo == null)
                throw new Exception("Repository not found. Delete failed.");

            await _repoRepository.Remove(request.Id);
            return Unit.Value;
        }
    }

    public class GetReposQueryHandler : IRequestHandler<GetReposQuery, List<RepoListDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepoRepository _repoRepository;

        public GetReposQueryHandler(IRepoRepository repoRepository, IMapper mapper)
        {
            _repoRepository = repoRepository;
            _mapper = mapper;
        }

        public async Task<List<RepoListDTO>> Handle(GetReposQuery request, CancellationToken cancellationToken)
        {
            var reposList = await _repoRepository.GetList();
            if (reposList == null)
                throw new Exception("No repository found. Failed to get list.");

            var repoDTOList = _mapper.Map<List<Repository>, List<RepoListDTO>>(reposList);
            return repoDTOList;
        }
    }

    public class GetRepoDetailsQueryHandler : IRequestHandler<GetRepoDetailsQuery, RepoDetailsDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IRepoRepository _repoRepository;
        public GetRepoDetailsQueryHandler(IUserRepository userRepository, IRepoRepository repoRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _repoRepository = repoRepository;
            _mapper = mapper;
        }

        public async Task<RepoDetailsDTO> Handle(GetRepoDetailsQuery request, CancellationToken cancellationToken)
        {
            var repo = await _repoRepository.GetById(request.Id);
            if (repo == null)
                throw new Exception("Repository not found. Failed to get details.");

            var repoDetails = _mapper.Map<Repository, RepoDetailsDTO>(repo);

            repoDetails.Owner = await _userRepository.GetRepoOwner(repo.Id);
            return repoDetails;
        }
    }
}
