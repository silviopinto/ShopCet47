using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopCet47.Web.Data.Entities;

namespace ShopCet47.Web.Data.Entities
{
    public class Country : IEntity
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }
}
