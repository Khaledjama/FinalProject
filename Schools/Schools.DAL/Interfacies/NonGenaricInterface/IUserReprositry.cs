﻿using Schools.DAL.Interfacies.GenaricInterface;
using Schools.DataStorage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schools.DAL.Interfacies.NonGenaricInterface
{
   public interface IUserReprositry : IGenaricReprositry<ApplicationUser>
    {
        Student GetCurrentUserByUserId(string UserId);
    }
}
