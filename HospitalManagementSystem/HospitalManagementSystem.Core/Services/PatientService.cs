using AutoMapper;
using HospitalManagementSystem.Core.Domain.Entites;
using HospitalManagementSystem.Core.Domain.RepositoryContracts;
using HospitalManagementSystem.Core.DTO;
using HospitalManagementSystem.Core.Helpers;
using HospitalManagementSystem.Core.ServiceContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Services
{
	public class PatientService : IPatientService
	{
		private readonly IPatientRepository _repository;
		private readonly IMapper _mapper;
		public PatientService(IPatientRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<Patient>> GetAllAsync()
		{
			return await _repository.GetAllAsync();
		}

		public async Task<Patient> GetByIdAsync(Guid id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public async Task AddAsync(PatientDTO patientDto)
		{
			var patient = _mapper.Map<Patient>(patientDto);
			await _repository.AddAsync(patient);
		}

		public async Task UpdatePatient(PatientDTO patientDTO)
		{
			if (patientDTO == null)
				throw new ArgumentNullException(nameof(patientDTO));

			var patient = new Patient
			{
				PatientID = patientDTO.PatientID,
				FirstName = patientDTO.FirstName,
				LastName = patientDTO.LastName,
				Gender = patientDTO.Gender,
				Email = patientDTO.Email,
				DateOfBirth = patientDTO.DateOfBirth,
				PhoneNumber = patientDTO.PhoneNumber,
				Address = patientDTO.Address,
				Height = patientDTO.Height,
				Weight = patientDTO.Weight,
				BloodGroup = patientDTO.BloodGroup,
			};

			// Cập nhật bệnh nhân
			await _repository.UpdatePatient(patient);
		}


		public async Task DeleteAsync(Guid id)
		{
			await _repository.DeleteAsync(id);
		}
	}
}
