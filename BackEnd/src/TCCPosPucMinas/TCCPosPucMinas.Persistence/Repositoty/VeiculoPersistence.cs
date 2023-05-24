﻿using Microsoft.EntityFrameworkCore;
using TCCPosPucMinas.Domain.Models;
using TCCPosPucMinas.Persistence.Interface;

namespace TCCPosPucMinas.Persistence.Repositoty
{
    public class VeiculoPersistence : GeralPersistence, IVeiculoPersist
    {     
        public VeiculoPersistence(TCCPosPucMinasContext context) : base(context)
        {
            //context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        #region Veiculo

        public async Task<Veiculo[]> GetAllVeiculosAsync()
        {
            IQueryable<Veiculo> query = _context.Veiculos.Include(v => v.MarcaNavigation);
            query = query.OrderBy(v => v.MarcaNavigation.Nome);

            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Veiculo[]> GetAllVeiculosByMarcaAsync(string marca)
        {
            IQueryable<Veiculo> query = _context.Veiculos.Include(v => v.MarcaNavigation);
            query = query.Where(v => v.MarcaNavigation.Nome.ToLower().Equals(marca.ToLower()));

            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Veiculo?> GetVeiculoByIdAsync(int veiculoId)
        {
            return await _context.Veiculos.AsNoTracking().FirstOrDefaultAsync(v => v.Id == veiculoId);
        }

        #endregion
    }
}
