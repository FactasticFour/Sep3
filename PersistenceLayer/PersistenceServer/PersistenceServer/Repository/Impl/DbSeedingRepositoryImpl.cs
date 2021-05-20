﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PersistenceServer.Data;
using PersistenceServer.Models;

namespace PersistenceServer.Repository.Impl
{
    public class DbSeedingRepositoryImpl : IDbSeedingRepository
    {
        private List<Member> membersList;
        private List<Campus> campusList;
        private List<Facility> facilitiesList;
        public async void SeedDatabase()
        {
            Console.WriteLine("Seeding Database");

            await PopulateLists();
            Console.WriteLine(membersList.Count);
            Console.WriteLine(campusList.Count);
            Console.WriteLine(facilitiesList.Count);

            await EmptyDatabase();

            await PopulateDatabase();
        }

        private async Task PopulateDatabase()
        {
            await PopulateMembers();
            //await PopulateCampuses();
            await PopulateFacilities();
        }

        private async Task PopulateFacilities()
        {
            using (DataContext dataContext = new DataContext())
            {
                await dataContext.Facilities.AddRangeAsync(facilitiesList);
                await dataContext.SaveChangesAsync();
            }
        }

        private async Task PopulateCampuses()
        {
            using (DataContext dataContext = new DataContext())
            {
                await dataContext.Campuses.AddRangeAsync(campusList);
                await dataContext.SaveChangesAsync();
            }
        }

        private async Task PopulateMembers()
        {
            using (DataContext dataContext = new DataContext())
            {
                await dataContext.Members.AddRangeAsync(membersList);
                await dataContext.SaveChangesAsync();
            }
        }

        private async Task EmptyDatabase()
        {
            using (DataContext dataContext = new DataContext())
            {
                dataContext.Members.RemoveRange(dataContext.Members);
                dataContext.Campuses.RemoveRange(dataContext.Campuses);
                dataContext.Facilities.RemoveRange(dataContext.Facilities);
                dataContext.Accounts.RemoveRange(dataContext.Accounts);
                await dataContext.SaveChangesAsync();
            }
        }

        private async Task PopulateLists()
        {
            membersList = new List<Member>()
            {
                new Member()
                {
                    ViaId = 297111,
                    FirstName = "Ionut",
                    LastName = "Grosu",
                    Password = GetHash("pB8NtLP0d3I"),
                    Cpr = 1234567890
                },
                new Member()
                {
                    ViaId = 297112,
                    FirstName = "Claudiu",
                    LastName = "Hornet",
                    Password = GetHash("CTxG88wsH"),
                    Cpr = 1238547856
                },
                new Member()
                {
                    ViaId = 263458,
                    FirstName = "Maria",
                    LastName = "Asenova",
                    Password = GetHash("wUIyex7HqS9C"),
                    Cpr = 1352468756
                },
                new Member()
                {
                    ViaId = 275986,
                    FirstName = "Cezary",
                    LastName = "Korenczuk",
                    Password = GetHash("GPKX9CZeHn"),
                    Cpr = 1314568752
                },
                new Member()
                {
                    ViaId = 297109,
                    FirstName = "Bogdan",
                    LastName = "Cirstoiu",
                    Password = GetHash("2FYYbokA"),
                    Cpr = 1238569657
                },
                new Member()
                {
                    ViaId = 297110,
                    FirstName = "Mihail",
                    LastName = "Constantin",
                    Password = GetHash("fNbJcNdf"),
                    Cpr = 1458524562
                },
                new Member()
                {
                    ViaId = 154856,
                    FirstName = "Crééz",
                    LastName = "Querree",
                    Password = GetHash("kZ48Qkr0OdE"),
                    Cpr = 1238547695
                },
                new Member()
                {
                    ViaId = 123587,
                    FirstName = "Thérèse",
                    LastName = "Benedidick",
                    Password = GetHash("swNMW4V5"),
                    Cpr = 1324563528
                },
                new Member()
                {
                    ViaId = 25456,
                    FirstName = "Nadège",
                    LastName = "Kemitt",
                    Password = GetHash("Sokx6w5UxvwY"),
                    Cpr = 0123456258
                },
                new Member()
                {
                    ViaId = 189563,
                    FirstName = "Rachèle",
                    LastName = "Delgardo",
                    Password = GetHash("V14odWLTCO4I"),
                    Cpr = 0423568745
                },
                new Member()
                {
                    ViaId = 303854,
                    FirstName = "Pélagie",
                    LastName = "Steart",
                    Password = GetHash("zFHJQMnJY7"),
                    Cpr = 1085463254
                },
                new Member()
                {
                    ViaId = 200111,
                    FirstName = "Gwenaëlle",
                    LastName = "Daniau",
                    Password = GetHash("zFHJQMnJY7"),
                    Cpr = 0936541258
                },
                new Member()
                {
                    ViaId = 199523,
                    FirstName = "Dorothée",
                    LastName = "Ferrarini",
                    Password = GetHash("9LzRqzmij"),
                    Cpr = 1122334455
                },
                new Member()
                {
                    ViaId = 203345,
                    FirstName = "Lóng",
                    LastName = "Pipping",
                    Password = GetHash("GBXDqy9CWX"),
                    Cpr = 0456856633
                },
                new Member()
                {
                    ViaId = 175845,
                    FirstName = "Annotés",
                    LastName = "Estcot",
                    Password = GetHash("1cX4Bge"),
                    Cpr = 0323456585
                },
                new Member()
                {
                    ViaId = 99456,
                    FirstName = "Yáo",
                    LastName = "Towler",
                    Password = GetHash("cc7sjZqF7"),
                    Cpr = 0123458565
                },
                new Member()
                {
                    ViaId = 12856,
                    FirstName = "Adélie",
                    LastName = "Tippings",
                    Password = GetHash("I4yhUxoHyxc8"),
                    Cpr = 0701854655
                },
                new Member()
                {
                    ViaId = 305503,
                    FirstName = "Béatrice",
                    LastName = "McAne",
                    Password = GetHash("tgqXXfQ"),
                    Cpr = 0512458566
                },
                new Member()
                {
                    ViaId = 218203,
                    FirstName = "Cunégonde",
                    LastName = "Aleksankin",
                    Password = GetHash("Vw42KvF"),
                    Cpr = 0565854533
                },
                new Member()
                {
                    ViaId = 165234,
                    FirstName = "Naëlle",
                    LastName = "Noyce",
                    Password = GetHash("Ut4tTOS"),
                    Cpr = 0856421555
                }
            };

            campusList = new List<Campus>()
            {
                new Campus()
                {
                    City = "Horsens",
                    Street = "Chr M Østergaards Vej",
                    Name = "Campus Horsens",
                    PostCode = "8700"
                },
                new Campus()
                {
                    City = "Aarhus",
                    Street = "Ceresbyen",
                    Name = "Campus Aarhus C",
                    PostCode = "8000"
                },
                new Campus()
                {
                    City = "Aarhus",
                    Street = "Hedeager",
                    Name = "Campus Aarhus N",
                    PostCode = "8200"
                },
                new Campus()
                {
                    City = "Herning",
                    Street = "Birk Centerpark",
                    Name = "Campus Herning",
                    PostCode = "7400"
                },
                new Campus()
                {
                    City = "Holstebro",
                    Street = "Gl Struervej",
                    Name = "Campus Holstebro",
                    PostCode = "7500"
                },
                new Campus()
                {
                    City = "Randers",
                    Street = "Jens Otto Krags",
                    Name = "Campus Randers",
                    PostCode = "8900"
                },
                new Campus()
                {
                    City = "Silkeborg",
                    Street = "Nattergalevej",
                    Name = "Campus Silkeborg",
                    PostCode = "8600"
                },
                new Campus()
                {
                    City = "Viborg",
                    Street = "Prinsens Alle",
                    Name = "Campus Viborg",
                    PostCode = "8800"
                }
            };

            facilitiesList = new List<Facility>()
            {
                new Facility()
                {
                    ViaId = 12458,
                    Name = "Horsens Library",
                    Password = GetHash("kVh1dIKpPcu"),
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Horsens"))
                },
                new Facility()
                {
                    ViaId = 53654,
                    Name = "Horsens Canteen",
                    Password = GetHash("eGbRmMu"),
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Horsens"))
                },
                new Facility()
                {
                    ViaId = 120336,
                    Name = "Horsens Music Room",
                    Password = GetHash("GlGttQy8qK"),
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Horsens"))
                },
                new Facility()
                {
                    ViaId = 55236,
                    Name = "Aarhus C Library",
                    Password = GetHash("1Ay6rbas5"),
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Aarhus C"))
                },
                new Facility()
                {
                    ViaId = 4585,
                    Name = "Aarhus C Canteen",
                    Password = GetHash("oa8x5AAy"),
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Aarhus C"))
                },
                new Facility()
                {
                    ViaId = 102236,
                    Name = "Aarhus C Cafe",
                    Password = GetHash("AHaZiZ"),
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Aarhus C"))
                },
                new Facility()
                {
                    ViaId = 15429,
                    Name = "Aarhus N Library",
                    Password = GetHash("NWiaDlL83M"),
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Aarhus N"))
                },
                new Facility()
                {
                    ViaId = 12333,
                    Name = "Aarhus C Canteen",
                    Password = GetHash("QLnlvqTzHzK"),
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Aarhus N"))
                },
                new Facility()
                {
                    ViaId = 45782,
                    Name = "Aarhus C Cafe",
                    Password = GetHash("naARC532A9i"),
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Aarhus N"))
                },
                new Facility()
                {
                    ViaId = 125864,
                    Name = "Herning Library",
                    Password = GetHash("ffnkQG"),
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Herning"))
                },
                new Facility()
                {
                    ViaId = 129365,
                    Name = "Herning Canteen",
                    Password = GetHash("vQCRTfRhm"),
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Herning"))
                },
                new Facility()
                {
                    ViaId = 150325,
                    Name = "Herning Cafe",
                    Password = GetHash("STmtp3"),
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Herning"))
                },
                new Facility()
                {
                    ViaId = 195000,
                    Name = "Holstebro Library",
                    Password = GetHash("YhnWfWJ"),
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Holstebro"))
                },
                new Facility()
                {
                    ViaId = 199123,
                    Name = "Holstebro Canteen",
                    Password = GetHash("fZyi3k0CMU"),
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Holstebro"))
                },
                new Facility()
                {
                    ViaId = 198752,
                    Name = "Holstebro Cafe",
                    Password = GetHash("SWsWY472VSN6"),
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Holstebro"))
                },
                new Facility()
                {
                    ViaId = 52368,
                    Name = "Randers Library",
                    Password = GetHash("vJu2WVv9"),
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Randers"))
                },
                new Facility()
                {
                    ViaId = 55364,
                    Name = "Randers Canteen",
                    Password = GetHash("9m1csXMx"),
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Randers"))
                },
                new Facility()
                {
                    ViaId = 55421,
                    Name = "Randers Cafe",
                    Password = GetHash("fCy94zxbI6"),
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Randers"))
                },
                new Facility()
                {
                    ViaId = 95456,
                    Name = "Silkeborg Library",
                    Password = GetHash("YRT99g"),
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Silkeborg"))
                },
                new Facility()
                {
                    ViaId = 96128,
                    Name = "Silkeborg Canteen",
                    Password = GetHash("sNRkyoULDeF"),
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Silkeborg"))
                },
                new Facility()
                {
                    ViaId = 97855,
                    Name = "Silkeborg Cafe",
                    Password = GetHash("eA7nC3Gsk"),
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Silkeborg"))
                },
                new Facility()
                {
                    ViaId = 32555,
                    Name = "Viborg Library",
                    Password = GetHash("jYSljNk628D"),
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Viborg"))
                },
                new Facility()
                {
                    ViaId = 33784,
                    Name = "Viborg Canteen",
                    Password = GetHash("6XQBY6"),
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Viborg"))
                },
                new Facility()
                {
                    ViaId = 36591,
                    Name = "Viborg Cafe",
                    Password = GetHash("lXIwo5XPprCg"),
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Viborg"))
                }
            };
        }
        
        private static string GetHash(string input)
        {
            using SHA256 hashAlgorithm = SHA256.Create();
            
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}