using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeturDirectoryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeturDirectoryApp.Services.ContactInformation
{
    public class ContactInformationService : IContactInformationService
    {
        private readonly mytestdbContext _mytestdbContext;


        public ContactInformationService(mytestdbContext Context)
        {
            _mytestdbContext = Context;
        }

        public async Task<ActionResult<IEnumerable<CantactInformation>>> GetCantactInformations()
        {
            return await _mytestdbContext.CantactInformations.ToListAsync();
        }

        public async Task<ActionResult<CantactInformation>> GetCantactInformation(int id)
        {
            var cantactInformation = await _mytestdbContext.CantactInformations.FindAsync(id);

            if (cantactInformation == null)
            {
                return null;
            }

            return cantactInformation;
        }

        public async Task<IActionResult> DeleteCantactInformation(int id)
        {
            var cantactInformation = await _mytestdbContext.CantactInformations.FindAsync(id);
            if (cantactInformation == null)
            {
                return null;
            }

            _mytestdbContext.CantactInformations.Remove(cantactInformation);
            await _mytestdbContext.SaveChangesAsync();

            return null;
        }
    }
}
