namespace RSMEnterpriseIntegrationsAPI.Application.Services
{
    using AutoMapper;
    using FluentValidation;
    using RSMEnterpriseIntegrationsAPI.Application.DTOs;
    using RSMEnterpriseIntegrationsAPI.Application.Exceptions;
    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IValidator<CreateDepartmentDto> _createDepartmentValidator;
        private readonly IValidator<UpdateDepartmentDto> _updateDepartmentValidator;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository repository, IValidator<CreateDepartmentDto> createDepartmentValidator, IValidator<UpdateDepartmentDto> updateDepartmentValidator, IMapper mapper)
        {
            _departmentRepository = repository;
            _createDepartmentValidator = createDepartmentValidator;
            _updateDepartmentValidator = updateDepartmentValidator;
            _mapper = mapper;
        }

        public async Task<int> CreateDepartment(CreateDepartmentDto departmentDto)
        {
            var validationResult = _createDepartmentValidator.Validate(departmentDto);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Department info is not valid. " + string.Join(" ", validationResult.Errors.Select(error => error.ErrorMessage)));
            }

            var department = _mapper.Map<Department>(departmentDto);

            return await _departmentRepository.CreateDepartment(department);
        }

        public async Task<int> DeleteDepartment(int id)
        {

            if (id <= 0)
            {
                throw new BadRequestException("Id is not valid.");
            }

            var department = await _departmentRepository.GetDepartmentById(id);

            if (department == null) throw new NotFoundException($"Department with Id: {id} was not found.");

            return await _departmentRepository.DeleteDepartment(department);
        }

        public async Task<IEnumerable<GetDepartmentDto>> GetAll()
        {
            var departments = await _departmentRepository.GetAllDepartments();
            return _mapper.Map<IEnumerable<GetDepartmentDto>>(departments);

        }

        public async Task<GetDepartmentDto?> GetDepartmentById(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("DepartmentId is not valid");
            }

            var department = await _departmentRepository.GetDepartmentById(id);

            if (department == null) throw new NotFoundException($"Department with Id: {id} was not found.");

            department = await _departmentRepository.GetDepartmentById(id);
            return _mapper.Map<GetDepartmentDto>(department);
        }

        public async Task<int> UpdateDepartment(UpdateDepartmentDto departmentDto)
        {
            var department = await _departmentRepository.GetDepartmentById(departmentDto.DepartmentId);

            if (department == null) throw new NotFoundException($"Department with Id: {departmentDto.DepartmentId} was not found.");

            var validationResult = _updateDepartmentValidator.Validate(departmentDto);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Department info is not valid. " + string.Join(" ", validationResult.Errors.Select(error => error.ErrorMessage)));
            }

            department = _mapper.Map<Department>(departmentDto);

            return await _departmentRepository.UpdateDepartment(department);
        }

    }
}
