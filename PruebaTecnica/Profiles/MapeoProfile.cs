using AutoMapper;
using PruebaTecnica.DTOs;
using PruebaTecnica.Models;

namespace PruebaTecnica.Profiles
{
    public class MapeoProfile : Profile
    {
        public MapeoProfile() { 
            CreateMap<EscuelaModel,EscuelaDTO>().IncludeBase<RegistroModel,RegistroDTO>();
            CreateMap<ProfesorModel, ProfesorDTO>().IncludeBase<RegistroModel, RegistroDTO>();
            CreateMap<EstudianteModel, EstudianteDTO>().IncludeBase<RegistroModel, RegistroDTO>();
            CreateMap<ProfesorEstudianteModel, ProfesorEstudianteDTO>().IncludeBase<RegistroModel, RegistroDTO>();
            CreateMap<EstudianteEscuelaModel, EstudianteEscuelaDTO>().IncludeBase<RegistroModel, RegistroDTO>();
            CreateMap<RegistroModel, RegistroDTO>();
        }
    }
}
