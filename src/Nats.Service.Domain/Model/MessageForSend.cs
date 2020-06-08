using Nats.Setvice.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nats.Service.Domain.Model
{
    [Serializable]
    [Table("messageForSend")]
    public class MessageForSend : Entity
    {
        [Required(ErrorMessage = "Text dont be empty")]
        public string Text { get; set; }
    }
}