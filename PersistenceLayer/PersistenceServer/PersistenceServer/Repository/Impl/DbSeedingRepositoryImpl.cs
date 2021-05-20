using System;
using System.Collections.Generic;
using System.Linq;
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
                    Password = "pB8NtLP0d3I",
                    Cpr = 1234567890
                },
                new Member()
                {
                    ViaId = 297112,
                    FirstName = "Claudiu",
                    LastName = "Hornet",
                    Password = "CTxG88wsH",
                    Cpr = 1238547856
                },
                new Member()
                {
                    ViaId = 263458,
                    FirstName = "Maria",
                    LastName = "Asenova",
                    Password = "wUIyex7HqS9C",
                    Cpr = 1352468756
                },
                new Member()
                {
                    ViaId = 275986,
                    FirstName = "Cezary",
                    LastName = "Korenczuk",
                    Password = "GPKX9CZeHn",
                    Cpr = 1314568752
                },
                new Member()
                {
                    ViaId = 297109,
                    FirstName = "Bogdan",
                    LastName = "Cirstoiu",
                    Password = "2FYYbokA",
                    Cpr = 1238569657
                },
                new Member()
                {
                    ViaId = 297110,
                    FirstName = "Mihail",
                    LastName = "Constantin",
                    Password = "fNbJcNdf",
                    Cpr = 1458524562
                },
                new Member()
                {
                    ViaId = 154856,
                    FirstName = "Crééz",
                    LastName = "Querree",
                    Password = "kZ48Qkr0OdE",
                    Cpr = 1238547695
                },
                new Member()
                {
                    ViaId = 123587,
                    FirstName = "Thérèse",
                    LastName = "Benedidick",
                    Password = "swNMW4V5",
                    Cpr = 1324563528
                },
                new Member()
                {
                    ViaId = 25456,
                    FirstName = "Nadège",
                    LastName = "Kemitt",
                    Password = "Sokx6w5UxvwY",
                    Cpr = 0123456258
                },
                new Member()
                {
                    ViaId = 189563,
                    FirstName = "Rachèle",
                    LastName = "Delgardo",
                    Password = "V14odWLTCO4I",
                    Cpr = 0423568745
                },
                new Member()
                {
                    ViaId = 303854,
                    FirstName = "Pélagie",
                    LastName = "Steart",
                    Password = "zFHJQMnJY7",
                    Cpr = 1085463254
                },
                new Member()
                {
                    ViaId = 200111,
                    FirstName = "Gwenaëlle",
                    LastName = "Daniau",
                    Password = "zFHJQMnJY7",
                    Cpr = 0936541258
                },
                new Member()
                {
                    ViaId = 199523,
                    FirstName = "Dorothée",
                    LastName = "Ferrarini",
                    Password = "9LzRqzmij",
                    Cpr = 1122334455
                },
                new Member()
                {
                    ViaId = 203345,
                    FirstName = "Lóng",
                    LastName = "Pipping",
                    Password = "GBXDqy9CWX",
                    Cpr = 0456856633
                },
                new Member()
                {
                    ViaId = 175845,
                    FirstName = "Annotés",
                    LastName = "Estcot",
                    Password = "1cX4Bge",
                    Cpr = 0323456585
                },
                new Member()
                {
                    ViaId = 99456,
                    FirstName = "Yáo",
                    LastName = "Towler",
                    Password = "cc7sjZqF7",
                    Cpr = 0123458565
                },
                new Member()
                {
                    ViaId = 12856,
                    FirstName = "Adélie",
                    LastName = "Tippings",
                    Password = "I4yhUxoHyxc8",
                    Cpr = 0701854655
                },
                new Member()
                {
                    ViaId = 305503,
                    FirstName = "Béatrice",
                    LastName = "McAne",
                    Password = "tgqXXfQ",
                    Cpr = 0512458566
                },
                new Member()
                {
                    ViaId = 218203,
                    FirstName = "Cunégonde",
                    LastName = "Aleksankin",
                    Password = "Vw42KvF",
                    Cpr = 0565854533
                },
                new Member()
                {
                    ViaId = 165234,
                    FirstName = "Naëlle",
                    LastName = "Noyce",
                    Password = "Ut4tTOS",
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
                    Password = "kVh1dIKpPcu",
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Horsens"))
                },
                new Facility()
                {
                    ViaId = 53654,
                    Name = "Horsens Canteen",
                    Password = "eGbRmMu",
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Horsens"))
                },
                new Facility()
                {
                    ViaId = 120336,
                    Name = "Horsens Music Room",
                    Password = "GlGttQy8qK",
                    Campus = campusList.FirstOrDefault(c => c.Name.Contains("Horsens"))
                },
                // new Facility()
                // {
                //     ViaId = 55236,
                //     Name = "Aarhus C Library",
                //     Password = "1Ay6rbas5",
                //     Campus = campusList.FirstOrDefault(c => c.Name.Contains("Aarhus C")),
                //     City = "Aarhus",
                //     Street = "Ceresbyen",
                //     PostCode = "8000"
                // },
                // new Facility()
                // {
                //     ViaId = 4585,
                //     Name = "Aarhus C Canteen",
                //     Password = "oa8x5AAy",
                //     Campus = campusList.FirstOrDefault(c => c.Name.Contains("Aarhus C")),
                //     City = "Aarhus",
                //     Street = "Ceresbyen",
                //     PostCode = "8000"
                // },
                // new Facility()
                // {
                //     ViaId = 102236,
                //     Name = "Aarhus C Cafe",
                //     Password = "AHaZiZ",
                //     Campus = campusList.FirstOrDefault(c => c.Name.Contains("Aarhus C")),
                //     City = "Aarhus",
                //     Street = "Ceresbyen",
                //     PostCode = "8000"
                // },
                // new Facility()
                // {
                //     ViaId = 15429,
                //     Name = "Aarhus N Library",
                //     Password = "NWiaDlL83M",
                //     Campus = campusList.FirstOrDefault(c => c.Name.Contains("Aarhus N")),
                //     City = "Aarhus",
                //     Street = "Hedeager",
                //     PostCode = "8200"
                // },
                // new Facility()
                // {
                //     ViaId = 12333,
                //     Name = "Aarhus C Canteen",
                //     Password = "QLnlvqTzHzK",
                //     Campus = campusList.FirstOrDefault(c => c.Name.Contains("Aarhus N")),
                //     City = "Aarhus",
                //     Street = "Hedeager",
                //     PostCode = "8200"
                // },
                // new Facility()
                // {
                //     ViaId = 45782,
                //     Name = "Aarhus C Cafe",
                //     Password = "naARC532A9i",
                //     Campus = campusList.FirstOrDefault(c => c.Name.Contains("Aarhus N")),
                //     City = "Aarhus",
                //     Street = "Hedeager",
                //     PostCode = "8200"
                // },
                // new Facility()
                // {
                //     ViaId = 125864,
                //     Name = "Herning Library",
                //     Password = "ffnkQG",
                //     Campus = campusList.FirstOrDefault(c => c.Name.Contains("Herning")),
                //     City = "Herning",
                //     Street = "Birk Centerpark",
                //     PostCode = "7400"
                // },
                // new Facility()
                // {
                //     ViaId = 129365,
                //     Name = "Herning Canteen",
                //     Password = "vQCRTfRhm",
                //     Campus = campusList.FirstOrDefault(c => c.Name.Contains("Herning")),
                //     City = "Herning",
                //     Street = "Birk Centerpark",
                //     PostCode = "7400"
                // },
                // new Facility()
                // {
                //     ViaId = 150325,
                //     Name = "Herning Cafe",
                //     Password = "STmtp3",
                //     Campus = campusList.FirstOrDefault(c => c.Name.Contains("Herning")),
                //     City = "Herning",
                //     Street = "Birk Centerpark",
                //     PostCode = "7400"
                // },
                // new Facility()
                // {
                //     ViaId = 195000,
                //     Name = "Holstebro Library",
                //     Password = "YhnWfWJ",
                //     Campus = campusList.FirstOrDefault(c => c.Name.Contains("Holstebro")),
                //     City = "Holstebro",
                //     Street = "Gl Struervej",
                //     PostCode = "7500"
                // },
                // new Facility()
                // {
                //     ViaId = 199123,
                //     Name = "Holstebro Canteen",
                //     Password = "fZyi3k0CMU",
                //     Campus = campusList.FirstOrDefault(c => c.Name.Contains("Holstebro")),
                //     City = "Holstebro",
                //     Street = "Gl Struervej",
                //     PostCode = "7500"
                // },
                // new Facility()
                // {
                //     ViaId = 198752,
                //     Name = "Holstebro Cafe",
                //     Password = "SWsWY472VSN6",
                //     Campus = campusList.FirstOrDefault(c => c.Name.Contains("Holstebro")),
                //     City = "Holstebro",
                //     Street = "Gl Struervej",
                //     PostCode = "7500"
                // },
                // new Facility()
                // {
                //     ViaId = 52368,
                //     Name = "Randers Library",
                //     Password = "vJu2WVv9",
                //     Campus = campusList.FirstOrDefault(c => c.Name.Contains("Randers")),
                //     City = "Randers",
                //     Street = "Jens Otto Krags",
                //     PostCode = "8900"
                // },
                // new Facility()
                // {
                //     ViaId = 55364,
                //     Name = "Randers Canteen",
                //     Password = "9m1csXMx",
                //     Campus = campusList.FirstOrDefault(c => c.Name.Contains("Randers")),
                //     City = "Randers",
                //     Street = "Jens Otto Krags",
                //     PostCode = "8900"
                // },
                // new Facility()
                // {
                //     ViaId = 55421,
                //     Name = "Randers Cafe",
                //     Password = "fCy94zxbI6",
                //     Campus = campusList.FirstOrDefault(c => c.Name.Contains("Randers")),
                //     City = "Randers",
                //     Street = "Jens Otto Krags",
                //     PostCode = "8900"
                // },
                // new Facility()
                // {
                //     ViaId = 95456,
                //     Name = "Silkeborg Library",
                //     Password = "YRT99g",
                //     Campus = campusList.FirstOrDefault(c => c.Name.Contains("Silkeborg")),
                //     City = "Silkeborg",
                //     Street = "Nattergalevej",
                //     PostCode = "8600"
                // },
                // new Facility()
                // {
                //     ViaId = 96128,
                //     Name = "Silkeborg Canteen",
                //     Password = "sNRkyoULDeF",
                //     Campus = campusList.FirstOrDefault(c => c.Name.Contains("Silkeborg")),
                //     City = "Silkeborg",
                //     Street = "Nattergalevej",
                //     PostCode = "8600"
                // },
                // new Facility()
                // {
                //     ViaId = 97855,
                //     Name = "Silkeborg Cafe",
                //     Password = "eA7nC3Gsk",
                //     Campus = campusList.FirstOrDefault(c => c.Name.Contains("Silkeborg")),
                //     City = "Silkeborg",
                //     Street = "Nattergalevej",
                //     PostCode = "8600"
                // },
                // new Facility()
                // {
                //     ViaId = 32555,
                //     Name = "Viborg Library",
                //     Password = "jYSljNk628D",
                //     Campus = campusList.FirstOrDefault(c => c.Name.Contains("Viborg")),
                //     City = "Viborg",
                //     Street = "Prinsens Alle",
                //     PostCode = "8800"
                // },
                // new Facility()
                // {
                //     ViaId = 33784,
                //     Name = "Viborg Canteen",
                //     Password = "6XQBY6",
                //     Campus = campusList.FirstOrDefault(c => c.Name.Contains("Viborg")),
                //     City = "Viborg",
                //     Street = "Prinsens Alle",
                //     PostCode = "8800"
                // },
                // new Facility()
                // {
                //     ViaId = 36591,
                //     Name = "Viborg Cafe",
                //     Password = "lXIwo5XPprCg",
                //     Campus = campusList.FirstOrDefault(c => c.Name.Contains("Viborg")),
                //     City = "Viborg",
                //     Street = "Prinsens Alle",
                //     PostCode = "8800"
                // }
            };
        }
    }
}