﻿using Application.Interfaces;
using AutoMapper;
using Infrastructure.Profiles;

namespace Infrastructure.Services
{
    public class MapperService : IMapperService
    {
        private readonly IMapper _mapper;

        public MapperService()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfiles(LoadProfiles()));
            _mapper = config.CreateMapper();
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            try
            {
                return _mapper.Map<TSource, TDestination>(source);
            }
            catch (Exception exception)
            {
                throw new Exception($"Mapping error: {exception.Message}");
            }
        }

        public IEnumerable<TDestination> MapList<TSource, TDestination>(IEnumerable<TSource> source)
        {
            try
            {
                return _mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source);
            }
            catch (Exception exception)
            {
                throw new Exception($"Mapping error: {exception.Message}");
            }
        }

        private IEnumerable<Profile> LoadProfiles()
        {
            return
            [
                new UsuarioProfile(),
                new AutenticacaoProfile(),
                new PlanoProfile(),
                new AlunoProfile()
            ];
        }
    }
}
