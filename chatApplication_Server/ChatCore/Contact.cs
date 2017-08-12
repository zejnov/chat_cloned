using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessagesCore
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string LastMessageText { get; set; } //specifies last message text happend between this
                                                    // contact and the user that have this contact

        [StringLength(50)]
        [Index(IsUnique = true)]
        [Required]
        public string Email { get; set; }

        public virtual User User { get; set; }
    }
}
