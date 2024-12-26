using AutoMapper;
using HospitalManagementSystem.Core.Domain.Entites;
using HospitalManagementSystem.Core.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HospitalManagementSystem.Web.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Doctor, DoctorDTO>().ForMember(dest=>dest.Department, opt => opt.MapFrom(src => src.Department.Name)).ReverseMap();
			CreateMap<Patient, PatientDTO>().ReverseMap();
		}
	}
}
