﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Konzole.InventorySystem.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public string RoleName { get; set; }

        public Permission Permissions { get; set; }
    }
}