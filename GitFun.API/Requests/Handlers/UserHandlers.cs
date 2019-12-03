using AutoMapper;
using GitFun.API.DTOs;
using GitFun.API.Models;
using GitFun.API.Repositories;
using GitFun.API.Requests.Commands;
using GitFun.API.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GitFun.API.Requests.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByUsername(request.User.Username);
            if (existingUser != null)
                throw new Exception("User alreay exists. Creation failed.");

            await _userRepository.Create(request.User);
            return request.User.Id;
        }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetById(request.Id);
            if (existingUser == null)
                throw new Exception("User not found. Update failed");

            request.User.Id = existingUser.Id;
            await _userRepository.Update(existingUser.Id, request.User);

            return Unit.Value;
        }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetById(request.Id);
            if (existingUser == null)
                throw new Exception("User not found. Delete failed.");

            await _userRepository.Remove(request.Id);
            return Unit.Value;
        }
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserListDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserListDTO>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var usersList = await _userRepository.GetList();
            if (usersList == null)
                throw new Exception("No user found. Failed to get list.");

            var userDTOList = _mapper.Map<List<User>, List<UserListDTO>>(usersList);
            return userDTOList;
        }
    }

    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IRepoRepository _repoRepository;
        public GetUserDetailsQueryHandler(IUserRepository userRepository, IRepoRepository repoRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _repoRepository = repoRepository;
            _mapper = mapper;
        }

        public async Task<UserDetailsDTO> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.UserId);
            if (user == null)
                throw new Exception("User not found. Failed to get details.");

            var userDetailsDTO = _mapper.Map<User, UserDetailsDTO>(user);

            userDetailsDTO.Repositories = await _repoRepository.GetList(user.Repositories);
            return userDetailsDTO;
        }
    }
}
