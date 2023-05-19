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
        List<Item> Items { get; set; }

        Task GetItems();
    }
}
