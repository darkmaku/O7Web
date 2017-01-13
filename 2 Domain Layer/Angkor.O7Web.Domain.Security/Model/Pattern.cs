// Create by Felix A. Bueno

using System.Collections.Generic;
using Angkor.O7Framework.Web.Model;
using Angkor.O7Web.Common.Security.Entity;

namespace Angkor.O7Web.Domain.Security.Model
{
    public class Pattern
    {
        public static List<O7Menu> SortMenus(List<Menu> menus, string menuId)
        {
            var result = new List<O7Menu>();
            foreach (var item in menus)
            {
                if (item.FatherId != menuId) continue;
                var node = new O7Menu
                {
                    Id = item.Id,
                    Title = item.Title,
                    Observation = item.Observacion,
                    Url = item.Url,
                    Icon = item.Icon,
                    Folder = item.Folder                    
                };
                node.Menus = SortMenus(menus, node.Id);                
                result.Add(node);                
            }
            return result;
        }
    }
}