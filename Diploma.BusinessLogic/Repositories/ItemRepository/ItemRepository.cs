using Azure;
using Diploma.DataAccess;
using Diploma.Domain;
using Diploma.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.BusinessLogic.Repositories.ItemRepository
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext _dataContext;

        public ItemRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<List<Item>>> GetItems()
        {

            var response = new ServiceResponse<List<Item>>
            {
                Data = await _dataContext.Items.ToListAsync()
            };

        return response;
        }
    }
}
        
    
