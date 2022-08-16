using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PhoneBook_Api
{
    public class PhoneBook
    {
        public Guid PhoneBookId { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string UsersId { get; set; }
        [JsonIgnore, ForeignKey("UsersId")]
        public Users User { get; set; }
    }
}
