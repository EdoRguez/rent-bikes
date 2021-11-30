﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRentBikesTests.FakeData
{
    public static class Data
    {
        public static List<RentalType> GetRentalTypes()
        {
            return new List<RentalType>()
            {
                new RentalType
                {
                    Id = Guid.Parse("B090A296-D3A3-4828-B2F9-0B6C360AD77B"),
                    Name = "Hour",
                    Price = (decimal) 5.0
                },
                new RentalType
                {
                    Id = Guid.Parse("3CDB0CE0-6C5E-4C2D-9252-54ED5683B854"),
                    Name = "Day",
                    Price = (decimal) 20.0
                },
                new RentalType
                {
                    Id = Guid.Parse("36346EBC-523D-4D0E-8C75-3BCC0F380DA0"),
                    Name = "Week",
                    Price = (decimal) 60.0
                }
            };
        }

        public static List<Bike> GetBikes()
        {
            return new List<Bike>()
            {
                new Bike()
                {
                    Id = Guid.Parse("1C4A515A-56D1-43A8-8A80-39343FE2654F"),
                    SerialNumber = "U-35986859643",
                    IsAvailable = true
                },
                new Bike()
                {
                    Id = Guid.Parse("C8F84C17-23C2-4822-B611-80B05C945D17"),
                    SerialNumber = "F-95865965965",
                    IsAvailable = true
                },
                new Bike()
                {
                    Id = Guid.Parse("6FE98C41-F2FE-4D45-860E-3042DD182751"),
                    SerialNumber = "Y-24569875645",
                    IsAvailable = true
                },
                new Bike()
                {
                    Id = Guid.Parse("B8CB8AA8-97E3-4049-B31D-8CD5D15503E8"),
                    SerialNumber = "T-63232369569",
                    IsAvailable = true
                },
                new Bike()
                {
                    Id = Guid.Parse("C643797D-EB35-4ABD-AC14-5BF3575256FE"),
                    SerialNumber = "Q-01258456985",
                    IsAvailable = true
                },
                new Bike()
                {
                    Id = Guid.Parse("D19FBC15-9C45-40AF-97A4-4D4DEC977CCD"),
                    SerialNumber = "O-52456985695",
                    IsAvailable = true
                },
                new Bike()
                {
                    Id = Guid.Parse("6C49FE76-22C2-4B72-8C3C-6E1A0F4233C8"),
                    SerialNumber = "C-55569865965",
                    IsAvailable = true
                },
                new Bike()
                {
                    Id = Guid.Parse("AE366B8F-471D-4677-9E52-9949D4836239"),
                    SerialNumber = "R-11122233345",
                    IsAvailable = true
                },
                new Bike()
                {
                    Id = Guid.Parse("C071C09A-8291-4F88-BB1B-021AB8FCA3B0"),
                    SerialNumber = "J-99874563210",
                    IsAvailable = true
                },
                new Bike()
                {
                    Id = Guid.Parse("FB11168B-35DE-4593-9809-1E54CC460BB6"),
                    SerialNumber = "Z-44455556677",
                    IsAvailable = true
                }
            };
        }
    }
}
