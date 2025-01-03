﻿using AutoMapper;
using HospitalManagementSystem.Core.Domain.Entites;
using HospitalManagementSystem.Core.Domain.RepositoryContracts;
using HospitalManagementSystem.Core.DTO;
using HospitalManagementSystem.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Services
{
	public class DoctorService : IDoctorService
	{
		private readonly IDoctorRepository _doctorRepository;
		private readonly IMapper _mapper;

		public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
		{
			_doctorRepository = doctorRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<DoctorDTO>> GetAllDoctorsAsync()
		{
			var doctors = await _doctorRepository.GetAllDoctorsAsync();
			/*			var doctorDTOs = doctors.Select(doctor => new DoctorDTO
						{
							DoctorID = doctor.DoctorID,
							FirstName = doctor.FirstName,
							LastName = doctor.LastName,
							DateOfBirth = doctor.DateOfBirth,
							Email = doctor.Email,
							PhoneNumber = doctor.PhoneNumber,
							Address = doctor.Address,
							Available = doctor.Availability,
							Gender = doctor.Gender,
							Department = doctor.Department.Name
						});*/
			var doctorDTOs = _mapper.Map<IEnumerable<DoctorDTO>>(doctors);
			return doctorDTOs;
		}

		public async Task<DoctorDTO?> GetDoctorByIdAsync(Guid doctorId)
		{
			var doctor = await _doctorRepository.GetDoctorByIdAsync(doctorId);
			return doctor == null ? null : _mapper.Map<DoctorDTO>(doctor);
		}

		public async Task AddDoctorAsync(DoctorDTO doctorDto)
		{
			/*var doctor = _mapper.Map<Doctor>(doctorDto);*/
			var doctor = new Doctor
			{
				DoctorID = new Guid(),
				FirstName = doctorDto.FirstName,
				LastName = doctorDto.LastName,
				DateOfBirth = doctorDto.DateOfBirth,
				Email = doctorDto.Email,
				PhoneNumber = doctorDto.PhoneNumber,
				Address = doctorDto.Address,
				Availability = doctorDto.Availability,
				Gender = doctorDto.Gender,
			};
			await _doctorRepository.AddDoctorAsync(doctor);
		}

		/*public async Task UpdateDoctorAsync(DoctorDTO doctorDto)
		{
			var doctor = _mapper.Map<Doctor>(doctorDto);
			await _doctorRepository.UpdateDoctorAsync(doctor);
		}*/
		public async Task UpdateDoctorAsync(DoctorDTO doctorDTO)
		{
			if (doctorDTO == null)
				throw new ArgumentNullException(nameof(doctorDTO));

			var doctor = new Doctor
			{
				DoctorID = doctorDTO.DoctorID,
				FirstName = doctorDTO.FirstName,
				LastName = doctorDTO.LastName,
				Gender = doctorDTO.Gender,
				Email = doctorDTO.Email,
				DateOfBirth = doctorDTO.DateOfBirth,
				PhoneNumber = doctorDTO.PhoneNumber,
				Address = doctorDTO.Address
			};

			// Cập nhật bệnh nhân
			await _doctorRepository.UpdateDoctorAsync(doctor);
		}

		public async Task DeleteDoctorAsync(Guid doctorId)
		{
			await _doctorRepository.DeleteDoctorAsync(doctorId);
		}
	}
}
