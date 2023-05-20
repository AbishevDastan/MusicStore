using Diploma.Domain;
using Diploma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.BusinessLogic.Services.ItemService
{
    public interface IItemService
    {
        event Action ItemsChanged;
        List<Item> Items { get; set; }
        Task GetItems(string? categoryUrl = null);
        Task<ServiceResponse<Item>> GetItem(int itemId);
    }
}
