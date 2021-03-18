using Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppleAppRequest.Models
{
    public class AppleAppApplicationModel : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
