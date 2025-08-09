using ControleAcces.Domain.Entities;
using ControleAcces.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace ControleAcces.Application.UseCases
{
    public class CreerSessionUseCase

    {

        private readonly ISessionRepository _sessionRepository;


        public CreerSessionUseCase(ISessionRepository sessionRepository)

        {
            _sessionRepository = sessionRepository;

        }


        public async Task<bool> CreerSessionAsync(string nomSession, DateTime dateDebut, DateTime dateFin, string anneeAcademique)

        {

            var session = new Session

            {

                //Id =,

                Nom = nomSession,

                DateDebut = dateDebut,

                DateFin = dateFin,

                AnneeAcademique = anneeAcademique

            };


            await _sessionRepository.AddAsync(session);

            return true;

        }
    }
}