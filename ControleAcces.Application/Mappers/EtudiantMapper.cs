using ControleAcces.Application.DTOs;
using ControleAcces.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcces.Application.Mappers
{
    public static class EtudiantMapper
    {
        public static EtudiantDTO ToDTO(Etudiant etudiant)
        {
            return new EtudiantDTO
            {
                Id = etudiant.Id,
                Matricule = etudiant.Matricule,
                NomComplet = $"{etudiant.Nom} {etudiant.PostNom} {etudiant.Prenom}",
                Email = etudiant.Email,
                Promotion = etudiant.Promotion.Nom,
                CarteRFID = etudiant.CarteRFID,
                Empreinte = etudiant.EmpreinteHash
            };
        }
    }
}
