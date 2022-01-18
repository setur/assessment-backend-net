using Microsoft.AspNetCore.Mvc;
using SeturDirectoryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeturDirectoryApp.Services.ContactInformation
{
   public interface IContactInformationService
    {
        Task<ActionResult<IEnumerable<CantactInformation>>> GetCantactInformations();
        Task<ActionResult<CantactInformation>> GetCantactInformation(int id);
        //Task<ActionResult<CantactInformation>> DeleteCantactInformation(int id);
        Task<IActionResult> DeleteCantactInformation(int id);



    }
}
