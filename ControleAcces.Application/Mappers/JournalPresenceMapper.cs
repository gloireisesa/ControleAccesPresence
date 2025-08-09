using ControleAcces.Application.DTOs;
using ControleAcces.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Application.Mappers
{
    public static class JournalPresenceMapper
    {
        public static JournalPresenceDTO ToDTO(JournalPresence presence)
        {
            return new JournalPresenceDTO
            {
                EtudiantNom = presence.Etudiant.Nom,
                HeureEntree = presence.HeureEntree,
                HeureSortie = presence.HeureSortie,
                Statut = presence.Statut
            };
        }
    }
}
