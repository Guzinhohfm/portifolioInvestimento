﻿using System.ComponentModel.DataAnnotations;

namespace portifolioInvestimento.Models;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
}
