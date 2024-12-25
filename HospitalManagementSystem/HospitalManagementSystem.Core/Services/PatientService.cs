using HospitalManagementSystem.Core.Domain.Entites;
using HospitalManagementSystem.Core.Domain.RepositoryContracts;
using HospitalManagementSystem.Core.DTO;
using HospitalManagementSystem.Core.Helpers;
using HospitalManagementSystem.Core.ServiceContracts;
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

		public PatientService(IPatientRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<Patient>> GetAllAsync()
		{
			return await _repository.GetAllAsync();
		}

		public async Task<Patient> GetByIdAsync(Guid id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public async Task AddAsync(Patient patient)
		{
			await _repository.AddAsync(patient);
		}

		public async Task<PatientDTO> UpdatePatient(PatientDTO? patientDTO)
		{
			if (patientDTO == null)
				throw new ArgumentNullException(nameof(patientDTO));

			// Validation
			ValidationHelper.ModelValidation(patientDTO);

			// Get matching patient object to update
			Patient? matchingPatient = await _repository.GetByIdAsync(patientDTO.PatientID);
			if (matchingPatient == null)
			{
				throw new ArgumentException("Given patient id doesn't exist");
			}

			// Update all details
			matchingPatient.PatientID = patientDTO.PatientID;
			matchingPatient.FirstName = patientDTO.FirstName;
			matchingPatient.LastName = patientDTO.LastName;
			matchingPatient.Gender = patientDTO.Gender;
			matchingPatient.Email = patientDTO.Email;
			matchingPatient.DateOfBirth = patientDTO.DateOfBirth;
			matchingPatient.PhoneNumber = patientDTO.PhoneNumber;
			matchingPatient.Address = patientDTO.Address;

			await _repository.UpdatePatient(matchingPatient);

			// Convert back to DTO and return
			var updatedPatientDTO = new PatientDTO
			{
				PatientID = matchingPatient.PatientID,
				FirstName = matchingPatient.FirstName,
				LastName = matchingPatient.LastName,
				Gender = matchingPatient.Gender,
				Email = matchingPatient.Email,
				DateOfBirth = matchingPatient.DateOfBirth,
				PhoneNumber = matchingPatient.PhoneNumber,
				Address = matchingPatient.Address
			};

			return updatedPatientDTO;
		}


		public async Task DeleteAsync(Guid id)
		{
			await _repository.DeleteAsync(id);
		}
	}
}
