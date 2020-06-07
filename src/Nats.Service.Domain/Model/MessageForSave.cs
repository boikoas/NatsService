using Nats.Setvice.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Nats.Service.Domain.Model
{
    [Serializable]
    [Table("messageForSave")]
    public class MessageForSave : Entity
    {
        [Required]
        int Number;

        [Required(ErrorMessage = "Text dont be empty")]
        string Text;

        [Required]
        DateTime TimeSend;

        [Required]
        int HashCode;
    }
}
