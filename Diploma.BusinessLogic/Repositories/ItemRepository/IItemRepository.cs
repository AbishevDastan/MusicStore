using Diploma.DataAccess;
using Diploma.Domain;
using Diploma.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.BusinessLogic.Repositories.ItemRepository
{
    public interface IItemRepository
    {
        Task<ServiceResponse<List<Item>>> GetItems(); 
        Task<ServiceResponse<Item>> GetItem(int itemId);
        Task<ServiceResponse<List<Item>>> GetItemsByCategory(string categoryUrl);
    }
}
