﻿using System;
using System.Collections.Generic;

namespace chatbotapi;

public partial class Query
{
    public int? Id { get; set; }

    public string? Question { get; set; }

    public string? Answer { get; set; }
}
