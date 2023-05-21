using Diploma.Domain;
using Diploma.Domain.Entities;
using Diploma.DTO;
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
        List<ItemDTO> Items { get; set; }
        Task GetItems(string? categoryUrl);
        Task<ItemDTO> GetItem(int itemId);
    }
}
