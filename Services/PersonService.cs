﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class PersonService
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }

        public async Task CreatePerson(PersonRequestDto personRequestDto)
        {
            var person = mapper.Map<Person>(personRequestDto);
            person.Status = true;
            await personRepository.Insert(person);
        }

        public async Task UpdatePerson(int id, PersonRequestDto personRequestDto)
        {
            var existingPerson = await personRepository.GetById(p => p.IdPerson == id);
            if (existingPerson == null)
            {
                throw new KeyNotFoundException("La persona no existe.");
            }
            else
            {
                var person = mapper.Map<Person>(personRequestDto);
                await personRepository.Update(person);
            }
        }

        public async Task<ActionResult<PersonResponseDto>> GetPersonById(int id)
        {
            var person = await personRepository.GetById(p => p.IdPerson == id);
            if (person == null)
            {
                throw new KeyNotFoundException("La persona no fue encontrada.");
            }
            else
            {
                return mapper.Map<PersonResponseDto>(person);
            }
        }

        public async Task<ActionResult<List<PersonResponseDto>>> GetAllPersons()
        {
            var persons = await personRepository.GetAll();
            if (persons == null)
            {
                throw new Exception("Personas no encontradas.");
            }
            else
            {
                return mapper.Map<List<PersonResponseDto>>(persons);
            }
        }

        public async Task DeletePerson(int id)
        {
            var person = await personRepository.GetById(p => p.IdPerson == id);
            if (person == null)
            {
                throw new KeyNotFoundException("La persona no fue encontrada.");
            }
            else
            {
                person.Status = false;
                await personRepository.Update(person);
            }
        }

    }
}
