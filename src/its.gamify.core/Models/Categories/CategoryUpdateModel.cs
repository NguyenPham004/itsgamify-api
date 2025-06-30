using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.core.Models.Categories
{
    public class CategoryUpdateModel:CategoryCreateModel
    {
        public Guid Id { get; set; }
    }
}
