using MarriageAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageAgency.Data
{
    public class DbInitializer
    {
        public static void Initialize(MarriageAgencyContext context)
        {
            context.Database.EnsureCreated();

            if (context.ZodiacSigns.Any())
            {
                return;
            }

            var zodiacsigns = new ZodiacSign[]
            {
                new ZodiacSign { Name = "Козерог", Description = "Земной знак"},
                new ZodiacSign { Name = "Водолей", Description = "Воздушный знак"},                
                new ZodiacSign { Name = "Рыбы", Description = "Водный знак"},                
                new ZodiacSign { Name = "Овен", Description = "Огненый знак"},
                new ZodiacSign { Name = "Телец", Description = "Земной знак" },
                new ZodiacSign { Name = "Близнецы", Description = "Воздушный знак"},
                new ZodiacSign { Name = "Рак", Description = "Водный знак"},
                new ZodiacSign { Name = "Лев", Description = "Огненый знак"},
                new ZodiacSign { Name = "Дева", Description = "Земной знак" },
                new ZodiacSign { Name = "Весы", Description = "Воздушный знак"},
                new ZodiacSign { Name = "Скорпион", Description = "Водный знак"},
                new ZodiacSign { Name = "Стрелец", Description = "Огненый знак" },

            };

            foreach (ZodiacSign c in zodiacsigns)
            {
                context.ZodiacSigns.Add(c);
            }
            context.SaveChanges();

            if (context.Relations.Any())
            {
                return;
            }

            var relations = new Relation[]
            {
                new Relation { Name = "Холост", Description = "В Поисках Жены"},
                new Relation { Name = "Не замужем", Description = "В Поисках Семьи"},
                new Relation { Name = "Разведен", Description = "В Поисках Спутницы"},
                new Relation { Name = "Разведена", Description = "В Поисках Мужа"},
                new Relation { Name = "Свободный", Description = "Ищет Даму"},
                new Relation { Name = "Девушка", Description = "Ищет Молодого парня"},
                new Relation { Name = "Парень", Description = "Ищет Девушку"},
                new Relation { Name = "Дама", Description = "Ищет Мужчину"},
                new Relation { Name = "Мужчина", Description = "Ищет Даму"},
                new Relation { Name = "Пенсионер", Description = "В Поиске Дамы"}
            };

            foreach (Relation a in relations)
            {
                context.Relations.Add(a);
            }
            context.SaveChanges();

            if (context.Nationalities.Any())
            {
                return;
            }

            var nationalities = new Nationalitie[]
            {
                new Nationalitie { Name = "Белорус", Description = "Добрый"},
                new Nationalitie { Name = "Белоруска", Description = "Семейная"},
                new Nationalitie { Name = "Русский", Description = "Хозяин"},
                new Nationalitie { Name = "Русская", Description = "Хозяйка"},
                new Nationalitie { Name = "Украинец", Description = "Руководитель"},
                new Nationalitie { Name = "Украинка", Description = "Госпожа"},
                new Nationalitie { Name = "Латыш", Description = "Спокойный"},
                new Nationalitie { Name = "Латышка", Description = "Спокойная"},
                new Nationalitie { Name = "Татарин", Description = "Восточный"},                                         
                new Nationalitie { Name = "Полька", Description = "Светлая"}
            };

            foreach (Nationalitie i in nationalities)
            {
                context.Nationalities.Add(i);
            }
            context.SaveChanges();

            if (context.Clients.Any())
            {
                return;
            }

            var clients = new Client[]
            {
                new Client{ FirsLastMidName = "Иванов Кирил Сергеевич", Age = 33, Gender = "Муж", DateofBirth = DateTime.Parse("12-10-1987"),
                    Height = 180, Weight = 75, Children = 1,
                    MaritalStatus = "Холост", BadHabits = "Курение", Hobby = "Рыбалка", Description = "Нет",
                    ZodiacSignID = 10, RelationID = 1, NationalID = 1,
                    //zodiacsigns.Single().ZodiacSignID,relations.Single().RelationID,nationalities.Single().NationalID
                    Addres = "Гомель. Пр-т Октября. 48/21", Phone = "+375445685246",  Passport = "АВ3645218"},
                new Client{ FirsLastMidName = "Семенова Анна Ивановна", Age = 30, Gender = "Жен", DateofBirth = DateTime.Parse("6-07-1990"),
                    Height = 165, Weight = 60, Children = 0,
                    MaritalStatus = "Не замужем", BadHabits = "Нет", Hobby = "Вязание", Description = "Нет",
                    ZodiacSignID = 7,RelationID = 2,NationalID = 2,
                    Addres = "Гомель. Пр-т Октября. 55/36", Phone = "+375297672234",  Passport = "НВ3564376"},
                new Client{ FirsLastMidName = "Андронов Антон Адамович", Age = 35, Gender = "Муж", DateofBirth = DateTime.Parse("4-03-1985"),
                    Height = 178, Weight = 69, Children = 1,
                    MaritalStatus = "Холост", BadHabits = "Спиртное", Hobby = "Спорт", Description = "Нет",
                    ZodiacSignID = 3,RelationID = 5,NationalID = 5,
                    Addres = "Гомель. Косарева. 57/36", Phone = "+375295384621",  Passport = "НВ6254183"},
                new Client{ FirsLastMidName = "Карпенко Марина Федоровна", Age = 26, Gender = "Жен", DateofBirth = DateTime.Parse("8-02-1994"),
                    Height = 163, Weight = 58, Children = 1,
                    MaritalStatus = "Разведена", BadHabits = "Нет", Hobby = "Готовить", Description = "Нет",
                    ZodiacSignID = 2, RelationID = 6, NationalID = 4,
                    Addres = "Гомель. Советская. 68/12", Phone = "+375297672234",  Passport = "НВ3564376"},
                new Client{ FirsLastMidName = "Максимов Виктор Олегович", Age = 37, Gender = "Муж", DateofBirth = DateTime.Parse("4-08-1983"),
                    Height = 175, Weight = 75, Children = 1,
                    MaritalStatus = "Холост", BadHabits = "Нет", Hobby = "Спорт", Description = "Нет",
                    ZodiacSignID = 7,RelationID = 9,NationalID = 9,
                    Addres = "Гомель. ул.Победы 55/16", Phone = "+375297564329",  Passport = "НВ7359456"},
                new Client{ FirsLastMidName = "Полякова Татьяна Игоревна", Age = 29, Gender = "Жен", DateofBirth = DateTime.Parse("6-05-1991"),
                    Height = 165, Weight = 58, Children = 0,
                    MaritalStatus = "Не замужем", BadHabits = "Нет", Hobby = "Шитье", Description = "Хорошая",
                    ZodiacSignID = 5,RelationID = 6,NationalID = 4,
                    Addres = "Гомель. ул. Барыкина. 44/22", Phone = "+375291125479",  Passport = "НВ31258964"},
                new Client{ FirsLastMidName = "Гордеева Кира Ивановна", Age = 25, Gender = "Жен", DateofBirth = DateTime.Parse("28-07-1995"),
                    Height = 165, Weight = 62, Children = 0,
                    MaritalStatus = "Не замужем", BadHabits = "Нет", Hobby = "Вязание", Description = "Нет",
                    ZodiacSignID = 7,RelationID = 6, NationalID = 2,
                    Addres = "Гомель. Пр-т Космонавтов. 44/33", Phone = "+375295442122",  Passport = "НВ7226142"},
                new Client{ FirsLastMidName = "Еловой Виктор Иванович", Age = 33, Gender = "Муж", DateofBirth = DateTime.Parse("16-09-1987"),
                    Height = 180, Weight = 77, Children = 1,
                    MaritalStatus = "Разведен", BadHabits = "Алкоголь", Hobby = "Книги", Description = "Нет",
                    ZodiacSignID = 9,RelationID = 5, NationalID = 1,
                    Addres = "Гомель. ул.Юбилейная. 57/36", Phone = "+375291345678",  Passport = "НВ6549215"},
                new Client{ FirsLastMidName = "Яблонский Сергей Витальевич", Age = 40, Gender = "Муж", DateofBirth = DateTime.Parse("22-01-1980"),
                    Height = 182, Weight = 78, Children = 1,
                    MaritalStatus = "Разведен", BadHabits = "Курение", Hobby = "Книги", Description = "Нет",
                    ZodiacSignID = 1, RelationID = 5, NationalID = 7,                  
                    Addres = "Гомель. Пр-т Лениена. 102/28", Phone = "+375447458943",  Passport = "АВ3645218"},
                new Client{ FirsLastMidName = "Алферова Катерина Федоровна", Age = 56, Gender = "Жен", DateofBirth = DateTime.Parse("8-12-1964"),
                    Height = 167, Weight = 78, Children = 2,
                    MaritalStatus = "Вдова", BadHabits = "Нет", Hobby = "Готовить", Description = "Нет",
                    ZodiacSignID = 12, RelationID = 8, NationalID = 4,
                    Addres = "Гомель. ул.Некрасова. 51/58", Phone = "+375258956432",  Passport = "АН6452371"},
                new Client{ FirsLastMidName = "Чехова Анфиса Петровна", Age = 32, Gender = "Жен", DateofBirth = DateTime.Parse("18-04-1988"),
                    Height = 165, Weight = 62, Children = 0,
                    MaritalStatus = "Не замужем", BadHabits = "Нет", Hobby = "Готовить", Description = "Нет",
                    ZodiacSignID = 4, RelationID = 2, NationalID = 6,
                    Addres = "Гомель. ул.Крестьянская. 28/62", Phone = "+375293365241",  Passport = "НВ9412586"},
                new Client{  FirsLastMidName = "Сидоров Адам Генадьевич", Age = 68, Gender = "Муж", DateofBirth = DateTime.Parse("12-11-1952"),
                    Height = 166, Weight = 75, Children = 2,
                    MaritalStatus = "Разведен", BadHabits = "Курение", Hobby = "Рыбалка", Description = "Нет",
                    ZodiacSignID = 11, RelationID = 10, NationalID = 5,
                    Addres = "Гомель. Пр-т Коммисаров. 12/20", Phone = "+375448523456",  Passport = "АВ3842653"},
                new Client{ FirsLastMidName = "Денисов Владимир Евгеньевич", Age = 36, Gender = "Муж", DateofBirth = DateTime.Parse("14-06-1984"),
                    Height = 168, Weight = 78, Children = 1,
                    MaritalStatus = "Разведен", BadHabits = "Курение", Hobby = "Электроника", Description = "Нет",
                    ZodiacSignID = 6, RelationID = 3, NationalID = 1,
                    Addres = "Гомель. ул.Плеханова. 45/27", Phone = "+375443542694",  Passport = "АВ1258735"},
                 new Client{ FirsLastMidName = "Борисова Дана Петровна", Age = 28, Gender = "Жен", DateofBirth = DateTime.Parse("18-05-1992"),
                    Height = 160, Weight = 62, Children = 0,
                    MaritalStatus = "Не замужем", BadHabits = "Нет", Hobby = "Книги", Description = "Нет",
                    ZodiacSignID = 5, RelationID = 6, NationalID = 8,
                    Addres = "Гомель. ул.Крестьянская. 44/38", Phone = "+375297456325",  Passport = "АЕ6452586"},
                 new Client{ FirsLastMidName = "Прокопеня Дмитрий Иванович", Age = 20, Gender = "Муж", DateofBirth = DateTime.Parse("6-02-2000"),
                    Height = 172, Weight = 60, Children = 0,
                    MaritalStatus = "Парень", BadHabits = "Нет", Hobby = "Программирование", Description = "Нет",
                    ZodiacSignID = 2,RelationID = 7,NationalID = 7,
                    Addres = "Гомель. ул.Нагорная 66/33", Phone = "+375295425582",  Passport = "АВ6238412"}
            };

            foreach (Client s in clients)
            {
                context.Clients.Add(s);
            }
            context.SaveChanges();

            if (context.Positions.Any())
            {
                return;
            }

            var positions = new Position[]
            {
                new Position{ NamePosition = "Менеджер", Salary = 1000, Responsibilitie = "Подбор Клиентов", Requirement = "Психология"},
                new Position{ NamePosition = "Тамада", Salary = 800, Responsibilitie = "Ведение свадеб", Requirement = "Музыка, песни"},
                new Position{ NamePosition = "Фотограф", Salary = 700, Responsibilitie = "Фото и Видео", Requirement = "Профессионализм"},
                new Position{ NamePosition = "Администратор", Salary = 600, Responsibilitie = "Документация", Requirement = "Диплом Юриста"},
                new Position{ NamePosition = "Бухгалтер", Salary = 600, Responsibilitie = "Бух-учет", Requirement = "Знание финансов"},
                new Position{ NamePosition = "Директор", Salary = 2600, Responsibilitie = "Руководить", Requirement = "Быть Главным"}
            };

            foreach (Position n in positions)
            {
                context.Positions.Add(n);
            }
            context.SaveChanges();

            if (context.Employees.Any())
            {
                return;
            }

            var employees = new Employee[]
            {
                new Employee{ FirsLastMidName = "Петров Федор Сергеевич", Age = 37, Gender = "Муж", Addres = "Гомель. ул.Кожара. 96/44",
                    Phone = "+375298523121", Passport = "НВ2384521", PositionID = 1},//positions.Single().PositionID
                new Employee{ FirsLastMidName = "Козлов Олег Леонидович", Age = 41, Gender = "Муж", Addres = "Гомель. ул.Плеханова. 88/32",
                    Phone = "+375336785216", Passport = "НВ3256494", PositionID = 1},
                new Employee{ FirsLastMidName = "Змеев Андрей Аркадьевич", Age = 44, Gender = "Муж", Addres = "Гомель. ул.Дынды. 12/37",
                    Phone = "+375259613357", Passport = "НВ6529542", PositionID = 1},
                new Employee{ FirsLastMidName = "Худякова Инна Сергевна", Age = 33, Gender = "Жен", Addres = "Гомель. ул.Советская. 82/13",
                    Phone = "+375298631254", Passport = "НВ6215478", PositionID = 2},
                new Employee{ FirsLastMidName = "Смирнов Иван Абрамович", Age = 47, Gender = "Муж", Addres = "Гомель. ул.Песина. 100/51",
                    Phone = "+375296598732", Passport = "НВ6652712", PositionID = 3},
                new Employee{ FirsLastMidName = "Ефимова Светлана Андреевна", Age = 30, Gender = "Жен", Addres = "Гомель. ул.Б.Хмельницкого 196/53",
                    Phone = "+375256341258", Passport = "НВ7214596", PositionID = 4},
                new Employee{ FirsLastMidName = "Гурская Елена Константиновна", Age = 45, Gender = "Жен", Addres = "Гомель. ул.Барыкина. 34/41",
                    Phone = "+375293254197", Passport = "НВ5643281", PositionID = 5},
                new Employee{ FirsLastMidName = "Артемов Василий Иванович", Age = 59, Gender = "Муж", Addres = "Гомель. ул.Зои-Космодемьянской. 196/106",
                    Phone = "+375298523121", Passport = "НВ2384521", PositionID = 6}
            };

            foreach (Employee e in employees)
            {
                context.Employees.Add(e);
            }
            context.SaveChanges();

            if (context.Services.Any())
            {
                return;
            }

            var servise = new Service[]//здесь все переделать надо!!!
            {                                                                  //employees.Single().EmployeeID//clients.Single().ClientID,
                new Service { /*ServiseID = 1,*/ Date = DateTime.Parse("17-10-2019"), Cost = 300, ClientID = 1, EmployeeID = 1 },
                new Service { /*ServiseID = 2,*/ Date = DateTime.Parse("10-10-2019"), Cost = 350, ClientID = 3, EmployeeID = 3 },
                new Service { /*ServiseID = 3,*/ Date = DateTime.Parse("18-10-2019"), Cost = 50, ClientID = 10, EmployeeID = 4 },
                new Service { /*ServiseID = 4,*/ Date = DateTime.Parse("12-10-2019"), Cost = 180, ClientID = 3, EmployeeID = 1 },
                new Service { /*ServiseID = 5,*/ Date = DateTime.Parse("15-10-2019"), Cost = 280, ClientID = 2, EmployeeID = 3 }
            };

            foreach (Service d in servise)
            {
                context.Services.Add(d);
            }
            context.SaveChanges();

        }
    }
}
