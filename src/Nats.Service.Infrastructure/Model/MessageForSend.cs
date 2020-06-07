﻿using Nats.Setvice.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Nats.Service.Infrastructure.Model
{
    [Serializable]
    [Table("messageForSend")]
    public class MessageForSend : Entity
    {
        [Required(ErrorMessage = "Text dont be empty")]
        string Text;
    }
}
