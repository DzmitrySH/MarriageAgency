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
                new ZodiacSign { Name = "Козерог", Description = "Земной знак"},   //1
                new ZodiacSign { Name = "Водолей", Description = "Воздушный знак"},//2               
                new ZodiacSign { Name = "Рыбы", Description = "Водный знак"},      //3          
                new ZodiacSign { Name = "Овен", Description = "Огненый знак"},     //4
                new ZodiacSign { Name = "Телец", Description = "Земной знак" },    //5
                new ZodiacSign { Name = "Близнецы", Description = "Воздушный знак"},//6
                new ZodiacSign { Name = "Рак", Description = "Водный знак"},       //7
                new ZodiacSign { Name = "Лев", Description = "Огненый знак"},      //8
                new ZodiacSign { Name = "Дева", Description = "Земной знак" },     //9
                new ZodiacSign { Name = "Весы", Description = "Воздушный знак"},   //10
                new ZodiacSign { Name = "Скорпион", Description = "Водный знак"},  //11
                new ZodiacSign { Name = "Стрелец", Description = "Огненый знак" }, //12

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
                new Relation { Name = "Холост", Description = "В Поисках Жены"},     //1
                new Relation { Name = "Не замужем", Description = "В Поисках Семьи"},//2
                new Relation { Name = "Разведен", Description = "В Поисках Спутницы"},//3
                new Relation { Name = "Разведена", Description = "В Поисках Мужа"},  //4
                new Relation { Name = "Свободный", Description = "Ищет Даму"},       //5
                new Relation { Name = "Девушка", Description = "Ищет Молодого парня"},//6
                new Relation { Name = "Парень", Description = "Ищет Девушку"},       //7
                new Relation { Name = "Дама", Description = "Ищет Мужчину"},         //8
                new Relation { Name = "Мужчина", Description = "Ищет Даму"},         //9
                new Relation { Name = "Пенсионер", Description = "В Поиске Дамы"}    //10
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
                new Nationalitie { Name = "Белорус", Description = "Добрый"},       //1
                new Nationalitie { Name = "Белоруска", Description = "Семейная"},   //2
                new Nationalitie { Name = "Русский", Description = "Хозяин"},       //3
                new Nationalitie { Name = "Русская", Description = "Хозяйка"},      //4
                new Nationalitie { Name = "Украинец", Description = "Руководитель"},//5
                new Nationalitie { Name = "Украинка", Description = "Госпожа"},     //6
                new Nationalitie { Name = "Латыш", Description = "Спокойный"},      //7
                new Nationalitie { Name = "Латышка", Description = "Спокойная"},    //8
                new Nationalitie { Name = "Татарин", Description = "Восточный"},    //9                                      
                new Nationalitie { Name = "Полька", Description = "Светлая"},       //10
                new Nationalitie { Name = "Поляк", Description = "Добряк"},        //11
                new Nationalitie { Name = "Еврей", Description = "Умный"},         //12
                new Nationalitie { Name = "Еврейка", Description = "Порядочная"}    //13
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
            {                            //zodiacsigns.Single().ZodiacSignID,relations.Single().RelationID,nationalities.Single().NationalID
                new Client{ FirsLastMidName = "Иванов Кирил Сергеевич", Age = 33, Gender = "Муж", DateofBirth = DateTime.Parse("12-10-1987"),
                    Height = 180, Weight = 75, Children = 1,
                    MaritalStatus = "Холост", BadHabits = "Курение", Hobby = "Рыбалка", Description = "Игроман",
                    ZodiacSignID = 10, RelationID = 1, NationalID = 1,           
                    Addres = "Гомель. Пр-т Октября. 48/21", Phone = "+375445685246",  Passport = "АВ3645218"},
                new Client{ FirsLastMidName = "Семенова Анна Ивановна", Age = 30, Gender = "Жен", DateofBirth = DateTime.Parse("6-07-1990"),
                    Height = 165, Weight = 60, Children = 0,
                    MaritalStatus = "Не замужем", BadHabits = "Нет", Hobby = "Вязание", Description = "Стройная",
                    ZodiacSignID = 7,RelationID = 2,NationalID = 2,
                    Addres = "Гомель. Пр-т Октября. 55/36", Phone = "+375297672234",  Passport = "НВ3564376"},
                new Client{ FirsLastMidName = "Андронов Антон Адамович", Age = 35, Gender = "Муж", DateofBirth = DateTime.Parse("4-03-1985"),
                    Height = 178, Weight = 69, Children = 1,
                    MaritalStatus = "Холост", BadHabits = "Спиртное", Hobby = "Спорт", Description = "Отсутствует",
                    ZodiacSignID = 3,RelationID = 5,NationalID = 5,
                    Addres = "Гомель. Косарева. 57/36", Phone = "+375295384621",  Passport = "НВ6254183"},
                new Client{ FirsLastMidName = "Карпенко Марина Федоровна", Age = 26, Gender = "Жен", DateofBirth = DateTime.Parse("8-02-1994"),
                    Height = 163, Weight = 58, Children = 1,
                    MaritalStatus = "Разведена", BadHabits = "Нет", Hobby = "Готовить", Description = "Полная",
                    ZodiacSignID = 2, RelationID = 6, NationalID = 4,
                    Addres = "Гомель. Советская. 68/12", Phone = "+375297672234",  Passport = "НВ3564376"},
                new Client{ FirsLastMidName = "Максимов Виктор Олегович", Age = 37, Gender = "Муж", DateofBirth = DateTime.Parse("4-08-1983"),
                    Height = 175, Weight = 75, Children = 1,
                    MaritalStatus = "Холост", BadHabits = "Нет", Hobby = "Спорт", Description = "Отсутствует",
                    ZodiacSignID = 7,RelationID = 9,NationalID = 9,
                    Addres = "Гомель. ул.Победы 55/16", Phone = "+375297564329",  Passport = "НВ7359456"},
                new Client{ FirsLastMidName = "Полякова Татьяна Игоревна", Age = 29, Gender = "Жен", DateofBirth = DateTime.Parse("6-05-1991"),
                    Height = 165, Weight = 58, Children = 0,
                    MaritalStatus = "Не замужем", BadHabits = "Нет", Hobby = "Шитье", Description = "Домоседка",
                    ZodiacSignID = 5,RelationID = 6,NationalID = 4,
                    Addres = "Гомель. ул. Барыкина. 44/22", Phone = "+375291125479",  Passport = "НВ31258964"},
                new Client{ FirsLastMidName = "Гордеева Кира Ивановна", Age = 25, Gender = "Жен", DateofBirth = DateTime.Parse("28-07-1995"),
                    Height = 165, Weight = 62, Children = 0,
                    MaritalStatus = "Не замужем", BadHabits = "Нет", Hobby = "Вязание", Description = "Домоседка",
                    ZodiacSignID = 7,RelationID = 6, NationalID = 2,
                    Addres = "Гомель. Пр-т Космонавтов. 44/33", Phone = "+375295442122",  Passport = "НВ7226142"},
                new Client{ FirsLastMidName = "Еловой Виктор Иванович", Age = 33, Gender = "Муж", DateofBirth = DateTime.Parse("16-09-1987"),
                    Height = 180, Weight = 77, Children = 1,
                    MaritalStatus = "Разведен", BadHabits = "Алкоголь", Hobby = "Книги", Description = "Шатен",
                    ZodiacSignID = 9,RelationID = 5, NationalID = 1,
                    Addres = "Гомель. ул.Юбилейная. 57/36", Phone = "+375291345678",  Passport = "НВ6549215"},
                new Client{ FirsLastMidName = "Яблонский Сергей Витальевич", Age = 40, Gender = "Муж", DateofBirth = DateTime.Parse("22-01-1980"),
                    Height = 182, Weight = 78, Children = 1,
                    MaritalStatus = "Разведен", BadHabits = "Курение", Hobby = "Книги", Description = "Отсутствует",
                    ZodiacSignID = 1, RelationID = 5, NationalID = 7,                  
                    Addres = "Гомель. Пр-т Лениена. 102/28", Phone = "+375447458943",  Passport = "АВ3645218"},
                new Client{ FirsLastMidName = "Алферова Катерина Федоровна", Age = 56, Gender = "Жен", DateofBirth = DateTime.Parse("8-12-1964"),
                    Height = 167, Weight = 78, Children = 2,
                    MaritalStatus = "Вдова", BadHabits = "Нет", Hobby = "Готовить", Description = "Отсутствует",
                    ZodiacSignID = 12, RelationID = 8, NationalID = 4,
                    Addres = "Гомель. ул.Некрасова. 51/58", Phone = "+375258956432",  Passport = "АН6452371"},
                new Client{ FirsLastMidName = "Чехова Анфиса Петровна", Age = 32, Gender = "Жен", DateofBirth = DateTime.Parse("18-04-1988"),
                    Height = 165, Weight = 62, Children = 0,
                    MaritalStatus = "Не замужем", BadHabits = "Нет", Hobby = "Готовить", Description = "Брюнетка",
                    ZodiacSignID = 4, RelationID = 2, NationalID = 6,
                    Addres = "Гомель. ул.Крестьянская. 28/62", Phone = "+375293365241",  Passport = "НВ9412586"},
                new Client{  FirsLastMidName = "Сидоров Адам Генадьевич", Age = 68, Gender = "Муж", DateofBirth = DateTime.Parse("12-11-1952"),
                    Height = 166, Weight = 75, Children = 2,
                    MaritalStatus = "Разведен", BadHabits = "Курение", Hobby = "Рыбалка", Description = "Отсутствует",
                    ZodiacSignID = 11, RelationID = 10, NationalID = 5,
                    Addres = "Гомель. Пр-т Коммисаров. 12/20", Phone = "+375448523456",  Passport = "АВ3842653"},
                new Client{ FirsLastMidName = "Денисов Владимир Евгеньевич", Age = 36, Gender = "Муж", DateofBirth = DateTime.Parse("14-06-1984"),
                    Height = 168, Weight = 78, Children = 1,
                    MaritalStatus = "Разведен", BadHabits = "Курение", Hobby = "Электроника", Description = "Разработчик",
                    ZodiacSignID = 6, RelationID = 3, NationalID = 1,
                    Addres = "Гомель. ул.Плеханова. 45/27", Phone = "+375443542694",  Passport = "АВ1258735"},
                new Client{ FirsLastMidName = "Борисова Дана Петровна", Age = 28, Gender = "Жен", DateofBirth = DateTime.Parse("18-05-1992"),
                    Height = 160, Weight = 62, Children = 0,
                    MaritalStatus = "Не замужем", BadHabits = "Нет", Hobby = "Книги", Description = "Девушка",
                    ZodiacSignID = 5, RelationID = 6, NationalID = 8,
                    Addres = "Гомель. ул.Крестьянская. 44/38", Phone = "+375297456325",  Passport = "АЕ6452586"},
                new Client{ FirsLastMidName = "Прокопеня Дмитрий Иванович", Age = 20, Gender = "Муж", DateofBirth = DateTime.Parse("6-02-2000"),
                    Height = 172, Weight = 60, Children = 0,
                    MaritalStatus = "Парень", BadHabits = "Нет", Hobby = "Программинг", Description = "Отсутствует",
                    ZodiacSignID = 2,RelationID = 7,NationalID = 7,
                    Addres = "Гомель. ул.Нагорная 66/33", Phone = "+375295425582",  Passport = "АВ6238412"},
                new Client{ FirsLastMidName = "Белый Александр Сергеевич", Age = 33, Gender = "Муж", DateofBirth = DateTime.Parse("12-10-1987"),
                    Height = 185, Weight = 78, Children = 1,
                    MaritalStatus = "Женат", BadHabits = "Нет", Hobby = "Автомобиль", Description = "Блондин",
                    ZodiacSignID = 10, RelationID = 1, NationalID = 1,
                    Addres = "Гомель. Пр-т Октября. 48/21", Phone = "+375445685246",  Passport = "АВ3645218"},
                new Client{ FirsLastMidName = "Габдрахимова Лейла Самуиловна", Age = 30, Gender = "Жен", DateofBirth = DateTime.Parse("09-07-1990"),
                    Height = 172, Weight = 66, Children = 0,
                    MaritalStatus = "Не замужем", BadHabits = "Нет", Hobby = "Вязание", Description = "Отсутствует",
                    ZodiacSignID = 7,RelationID = 2,NationalID = 13,
                    Addres = "Гомель. Пр-т Коммисаров. 80/86", Phone = "+375295924682",  Passport = "НВ7264193"},
                new Client{ FirsLastMidName = "Полунин Генадий Адамович", Age = 35, Gender = "Муж", DateofBirth = DateTime.Parse("4-03-1985"),
                    Height = 178, Weight = 69, Children = 1,
                    MaritalStatus = "Холост", BadHabits = "Спиртное", Hobby = "Спорт", Description = "Инструктор",
                    ZodiacSignID = 3,RelationID = 5,NationalID = 5,
                    Addres = "Гомель. Косарева. 41/32", Phone = "+375297384626",  Passport = "НВ92434573"},
                new Client{ FirsLastMidName = "Кириенко Лизавета Петровна", Age = 26, Gender = "Жен", DateofBirth = DateTime.Parse("8-02-1994"),
                    Height = 163, Weight = 58, Children = 2,
                    MaritalStatus = "Разведена", BadHabits = "Нет", Hobby = "Готовить", Description = "Отсутствует",
                    ZodiacSignID = 2, RelationID = 6, NationalID = 4,
                    Addres = "Гомель. Советская. 38/19", Phone = "+375297315798",  Passport = "НВ31499273"},
                new Client{ FirsLastMidName = "Ермолаев Виктор Андреевич", Age = 37, Gender = "Муж", DateofBirth = DateTime.Parse("4-07-1983"),
                    Height = 175, Weight = 75, Children = 1,
                    MaritalStatus = "Холост", BadHabits = "Нет", Hobby = "Плавание", Description = "Спортсмен",
                    ZodiacSignID = 8,RelationID = 9,NationalID = 9,
                    Addres = "Гомель. ул.Замковая 52/76", Phone = "+3752976648852",  Passport = "НВ9547632"},
                new Client{ FirsLastMidName = "Михайлова Наталья Петровна", Age = 29, Gender = "Жен", DateofBirth = DateTime.Parse("16-05-1991"),
                    Height = 165, Weight = 58, Children = 0,
                    MaritalStatus = "Не замужем", BadHabits = "Нет", Hobby = "Шитье", Description = "Умная",
                    ZodiacSignID = 5,RelationID = 6,NationalID = 4,
                    Addres = "Гомель. ул. 60 Лет БССР. 140/63", Phone = "+375291625274",  Passport = "НВ19843514"},
                new Client{ FirsLastMidName = "Фаддеева Сара Ивановна", Age = 25, Gender = "Жен", DateofBirth = DateTime.Parse("25-07-1995"),
                    Height = 167, Weight = 62, Children = 0,
                    MaritalStatus = "Не замужем", BadHabits = "Нет", Hobby = "Вязание", Description = "Молодая",
                    ZodiacSignID = 7,RelationID = 6, NationalID = 13,
                    Addres = "Гомель. Пр-т Космонавтов. 55/47", Phone = "+375295442843",  Passport = "НВ16835468"},
                new Client{ FirsLastMidName = "Сухоруков Виктор Иванович", Age = 39, Gender = "Муж", DateofBirth = DateTime.Parse("06-09-1981"),
                    Height = 180, Weight = 77, Children = 1,
                    MaritalStatus = "Разведен", BadHabits = "Алкоголь", Hobby = "Книги", Description = "Отсутствует",
                    ZodiacSignID = 9,RelationID = 5, NationalID = 1,
                    Addres = "Гомель. ул.Юбилейная. 94/26", Phone = "+375291259874",  Passport = "НВ5732159"},
                new Client{ FirsLastMidName = "Ивус Артем Витальевич", Age = 28, Gender = "Муж", DateofBirth = DateTime.Parse("22-01-1992"),
                    Height = 182, Weight = 78, Children = 0,
                    MaritalStatus = "Холостой", BadHabits = "Нет", Hobby = "Книги", Description = "Замкнутый",
                    ZodiacSignID = 1, RelationID = 7, NationalID = 11,
                    Addres = "Гомель. Пр-т Лениена. 102/28", Phone = "+375447458943",  Passport = "АВ3645218"},
                new Client{ FirsLastMidName = "Самойлова Тамара Федоровна", Age = 56, Gender = "Жен", DateofBirth = DateTime.Parse("8-12-1964"),
                    Height = 167, Weight = 78, Children = 2,
                    MaritalStatus = "Вдова", BadHabits = "Нет", Hobby = "Готовить", Description = "Отсутствует",
                    ZodiacSignID = 12, RelationID = 8, NationalID = 13,
                    Addres = "Гомель. ул.Некрасова. 51/58", Phone = "+375258956432",  Passport = "АН6452371"},
                new Client{ FirsLastMidName = "Морозова Елена Петровна", Age = 32, Gender = "Жен", DateofBirth = DateTime.Parse("10-04-1988"),
                    Height = 164, Weight = 62, Children = 0,
                    MaritalStatus = "Не замужем", BadHabits = "Нет", Hobby = "Готовить", Description = "Кулинарка",
                    ZodiacSignID = 4, RelationID = 2, NationalID = 6,
                    Addres = "Гомель. ул.Крестьянская. 68/42", Phone = "+375259126524",  Passport = "НВ6432576"},
                new Client{  FirsLastMidName = "Горохов Евгений Олегович", Age = 68, Gender = "Муж", DateofBirth = DateTime.Parse("01-11-1952"),
                    Height = 162, Weight = 79, Children = 2,
                    MaritalStatus = "Разведен", BadHabits = "Курение", Hobby = "Рыбалка", Description = "Отсутствует",
                    ZodiacSignID = 11, RelationID = 10, NationalID = 9,
                    Addres = "Гомель. Пр-т Победителей. 61/25", Phone = "+375256721985",  Passport = "АВ1687878"},
                new Client{ FirsLastMidName = "Борисенко Владимир Викторович", Age = 36, Gender = "Муж", DateofBirth = DateTime.Parse("11-06-1984"),
                    Height = 169, Weight = 78, Children = 1,
                    MaritalStatus = "Разведен", BadHabits = "Курение", Hobby = "Электроника", Description = "Разрабртчик",
                    ZodiacSignID = 6, RelationID = 3, NationalID = 1,
                    Addres = "Гомель. ул.Плеханова. 75/23", Phone = "+37544321473",  Passport = "АВ3548526"},
                new Client{ FirsLastMidName = "Ларусис Диана Анатольевна", Age = 28, Gender = "Жен", DateofBirth = DateTime.Parse("17-05-1992"),
                    Height = 168, Weight = 60, Children = 1,
                    MaritalStatus = "Разведена", BadHabits = "Нет", Hobby = "Книги", Description = "Эрудирована",
                    ZodiacSignID = 5, RelationID = 6, NationalID = 8,
                    Addres = "Гомель. ул.Полесская. 64/27", Phone = "+375293354625",  Passport = "АЕ7995426"},
                new Client{ FirsLastMidName = "Адамов Дмитрий Абрамович", Age = 20, Gender = "Муж", DateofBirth = DateTime.Parse("6-07-2000"),
                    Height = 172, Weight = 60, Children = 0,
                    MaritalStatus = "Парень", BadHabits = "Нет", Hobby = "Программинг", Description = "Отсутствует",
                    ZodiacSignID = 8,RelationID = 7,NationalID = 12,
                    Addres = "Гомель. ул.Подгорная 99/33", Phone = "+375294125882",  Passport = "АН6268492"}
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
                new Position{ NamePosition = "Менеджер", Salary = 1000, Responsibilitie = "Связи Клиентов", Requirement = "Психология"},        //1  1-5
                new Position{ NamePosition = "Стилист", Salary = 800, Responsibilitie = "Подбор Образа", Requirement = "Профессионализм"},      //2  6
                new Position{ NamePosition = "Фотограф", Salary = 900, Responsibilitie = "Фото и Видео", Requirement = "Профессионализм"},      //3  7,8
                new Position{ NamePosition = "Администратор", Salary = 600, Responsibilitie = "Документация", Requirement = "Диплом Юриста"},   //4  9
                new Position{ NamePosition = "Бухгалтер", Salary = 600, Responsibilitie = "Бух-учет", Requirement = "Знание финансов"},         //5  10,11
                new Position{ NamePosition = "Директор", Salary = 2600, Responsibilitie = "Руководить", Requirement = "Быть Главным"},          //6  12
                new Position{ NamePosition = "Психолог", Salary = 1200, Responsibilitie = "Подбор Клиентов", Requirement = "Коммуникабельность"},//7  13,14
                new Position{ NamePosition = "Программист", Salary = 1600, Responsibilitie = "Пр. Обеспечение", Requirement = "C#,1C,Phyton"}   //8 15
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
            {                                                        //positions.Single().PositionID
                new Employee{ FirsLastMidName = "Петров Федор Сергеевич", Age = 37, Gender = "Муж", Addres = "Гомель. ул.Кожара. 96/44",
                    Phone = "+375298523121", Passport = "НВ2384521", PositionID = 1},
                new Employee{ FirsLastMidName = "Козлов Алексей Леонидович", Age = 41, Gender = "Муж", Addres = "Гомель. ул.Плеханова. 88/32",
                    Phone = "+375336785216", Passport = "НВ3256494", PositionID = 1},
                new Employee{ FirsLastMidName = "Змеев Андрей Аркадьевич", Age = 44, Gender = "Муж", Addres = "Гомель. ул.Дынды. 12/37",
                    Phone = "+375259613357", Passport = "НВ6529542", PositionID = 1},
                new Employee{ FirsLastMidName = "Емелеин Олег Сергеевич", Age = 40, Gender = "Муж", Addres = "Гомель. ул.Барыкина. 188/33",
                    Phone = "+37533763168", Passport = "НВ16871353", PositionID = 1},
                new Employee{ FirsLastMidName = "Загоруев Андрей Максимович", Age = 45, Gender = "Муж", Addres = "Гомель. ул.Дынды. 17/57",
                    Phone = "+375259613357", Passport = "НВ6942516", PositionID = 1},
                new Employee{ FirsLastMidName = "Худякова Инна Сергевна", Age = 33, Gender = "Жен", Addres = "Гомель. ул.Советская. 82/13",
                    Phone = "+375298631254", Passport = "НВ6215478", PositionID = 2},
                new Employee{ FirsLastMidName = "Смирнов Иван Абрамович", Age = 47, Gender = "Муж", Addres = "Гомель. ул.Песина. 100/51",
                    Phone = "+375296598732", Passport = "НВ6652712", PositionID = 3},
                new Employee{ FirsLastMidName = "Томилин Адам Абрамович", Age = 46, Gender = "Муж", Addres = "Гомель. ул.Песина. 102/58",
                    Phone = "+37529128645", Passport = "НВ7321561", PositionID = 3},
                new Employee{ FirsLastMidName = "Ефимова Светлана Андреевна", Age = 30, Gender = "Жен", Addres = "Гомель. ул.Б.Хмельницкого 196/53",
                    Phone = "+375256341258", Passport = "НВ7214596", PositionID = 4},
                new Employee{ FirsLastMidName = "Гурская Елена Константиновна", Age = 45, Gender = "Жен", Addres = "Гомель. ул.Барыкина. 34/41",
                    Phone = "+375293254197", Passport = "НВ5643281", PositionID = 5},
                new Employee{ FirsLastMidName = "Грошева Светлана Андреевна", Age = 47, Gender = "Жен", Addres = "Гомель. ул.Бондарева. 35/41",
                    Phone = "+375297459855", Passport = "НВ7995413", PositionID = 5},
                new Employee{ FirsLastMidName = "Артемов Василий Иванович", Age = 59, Gender = "Муж", Addres = "Гомель. ул.Зои-Космодемьянской. 196/106",
                    Phone = "+375298523121", Passport = "НВ2384521", PositionID = 6},
                new Employee{ FirsLastMidName = "Кудинова Алла Сергевна", Age = 32, Gender = "Жен", Addres = "Гомель. ул.Севастопольская. 80/16",
                    Phone = "+37529816498", Passport = "НВ8552661", PositionID = 7},
                new Employee{ FirsLastMidName = "Курагина Светлана Викторовна", Age = 29, Gender = "Жен", Addres = "Гомель. ул.Гер.Подпольщиков 16/50",
                    Phone = "+375258526347", Passport = "НВ4569237", PositionID = 7},
                new Employee{ FirsLastMidName = "Кондратович Иван Иванович", Age = 27, Gender = "Муж", Addres = "Гомель. ул.Кожара. 106/67",
                    Phone = "+375299823913", Passport = "НВ17985852", PositionID = 8}
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

            var servise = new Service[]
            {                                     //employees.Single().EmployeeID//clients.Single().ClientID,
                new Service { Date = DateTime.Parse("13-05-2019"), Cost = 110, ClientID = 5, EmployeeID = 14 },
                new Service { Date = DateTime.Parse("13-05-2019"), Cost = 10, ClientID = 1, EmployeeID = 12 },
                new Service { Date = DateTime.Parse("13-05-2019"), Cost = 60, ClientID = 4, EmployeeID = 9 },
                new Service { Date = DateTime.Parse("14-05-2019"), Cost = 20, ClientID = 18, EmployeeID = 4 },
                new Service { Date = DateTime.Parse("13-05-2019"), Cost = 160, ClientID = 27, EmployeeID = 10 },
                new Service { Date = DateTime.Parse("14-05-2019"), Cost = 210, ClientID = 19, EmployeeID = 5 },
                new Service { Date = DateTime.Parse("13-05-2019"), Cost = 70, ClientID = 25, EmployeeID = 8 },
                new Service { Date = DateTime.Parse("14-05-2019"), Cost = 90, ClientID = 7, EmployeeID = 14 },
                new Service { Date = DateTime.Parse("10-07-2019"), Cost = 100, ClientID = 8, EmployeeID = 12 },
                new Service { Date = DateTime.Parse("10-07-2019"), Cost = 360, ClientID = 30, EmployeeID = 9 },
                new Service { Date = DateTime.Parse("10-07-2019"), Cost = 10, ClientID = 18, EmployeeID = 4 },
                new Service { Date = DateTime.Parse("11-07-2019"), Cost = 180, ClientID = 26, EmployeeID = 13 },
                new Service { Date = DateTime.Parse("10-07-2019"), Cost = 210, ClientID = 19, EmployeeID = 5 },
                new Service { Date = DateTime.Parse("10-07-2019"), Cost = 70, ClientID = 23, EmployeeID = 8 },
                new Service { Date = DateTime.Parse("15-08-2019"), Cost = 290, ClientID = 6, EmployeeID = 12 },
                new Service { Date = DateTime.Parse("15-08-2019"), Cost = 350, ClientID = 3, EmployeeID = 9 },
                new Service { Date = DateTime.Parse("18-08-2019"), Cost = 20, ClientID = 15, EmployeeID = 4 },
                new Service { Date = DateTime.Parse("16-08-2019"), Cost = 180, ClientID = 22, EmployeeID = 13 },
                new Service { Date = DateTime.Parse("14-08-2019"), Cost = 200, ClientID = 2, EmployeeID = 3 },
                new Service { Date = DateTime.Parse("14-08-2019"), Cost = 80, ClientID = 15, EmployeeID = 8 },
                new Service { Date = DateTime.Parse("25-09-2019"), Cost = 75, ClientID = 9, EmployeeID = 12 },
                new Service { Date = DateTime.Parse("25-09-2019"), Cost = 350, ClientID = 13, EmployeeID = 11 },
                new Service { Date = DateTime.Parse("26-09-2019"), Cost = 30, ClientID = 16, EmployeeID = 4 },
                new Service { Date = DateTime.Parse("26-09-2019"), Cost = 140, ClientID = 26, EmployeeID = 13 },
                new Service { Date = DateTime.Parse("24-09-2019"), Cost = 220, ClientID = 29, EmployeeID = 3 },
                new Service { Date = DateTime.Parse("25-09-2019"), Cost = 180, ClientID = 12, EmployeeID = 8 },
                new Service { Date = DateTime.Parse("17-10-2019"), Cost = 70, ClientID = 1, EmployeeID = 1 },
                new Service { Date = DateTime.Parse("17-10-2019"), Cost = 350, ClientID = 3, EmployeeID = 3 },
                new Service { Date = DateTime.Parse("18-10-2019"), Cost = 40, ClientID = 10, EmployeeID = 6 },
                new Service { Date = DateTime.Parse("16-10-2019"), Cost = 180, ClientID = 13, EmployeeID = 1 },
                new Service { Date = DateTime.Parse("16-10-2019"), Cost = 280, ClientID = 2, EmployeeID = 4 },
                new Service { Date = DateTime.Parse("11-10-2019"), Cost = 100, ClientID = 11, EmployeeID = 1 },
                new Service { Date = DateTime.Parse("12-10-2019"), Cost = 320, ClientID = 3, EmployeeID = 3 },
                new Service { Date = DateTime.Parse("12-10-2019"), Cost = 25, ClientID = 14, EmployeeID = 4 },
                new Service { Date = DateTime.Parse("12-10-2019"), Cost = 150, ClientID = 13, EmployeeID = 13 },
                new Service { Date = DateTime.Parse("12-10-2019"), Cost = 280, ClientID = 28, EmployeeID = 3 },
                new Service { Date = DateTime.Parse("20-11-2019"), Cost = 20, ClientID = 21, EmployeeID = 15 },
                new Service { Date = DateTime.Parse("20-11-2019"), Cost = 140, ClientID = 5, EmployeeID = 8 },
                new Service { Date = DateTime.Parse("20-11-2019"), Cost = 80, ClientID = 1, EmployeeID = 6 },
                new Service { Date = DateTime.Parse("20-11-2019"), Cost = 280, ClientID = 7, EmployeeID = 9 },
                new Service { Date = DateTime.Parse("20-11-2019"), Cost = 50, ClientID = 4, EmployeeID = 3 },
                new Service { Date = DateTime.Parse("18-11-2019"), Cost = 20, ClientID = 22, EmployeeID = 14 },
                new Service { Date = DateTime.Parse("17-11-2019"), Cost = 180, ClientID = 6, EmployeeID = 8 },
                new Service { Date = DateTime.Parse("15-11-2019"), Cost = 100, ClientID = 2, EmployeeID = 3 },
                new Service { Date = DateTime.Parse("20-11-2019"), Cost = 320, ClientID = 17, EmployeeID = 9 },
                new Service { Date = DateTime.Parse("20-11-2019"), Cost = 60, ClientID = 4, EmployeeID = 6 },
                new Service { Date = DateTime.Parse("18-11-2019"), Cost = 20, ClientID = 20, EmployeeID = 15 },
                new Service { Date = DateTime.Parse("18-11-2019"), Cost = 150, ClientID = 6, EmployeeID = 8 },
                new Service { Date = DateTime.Parse("18-11-2019"), Cost = 80, ClientID = 2, EmployeeID = 3 },
                new Service { Date = DateTime.Parse("15-12-2019"), Cost = 90, ClientID = 9, EmployeeID = 2 },
                new Service { Date = DateTime.Parse("15-12-2019"), Cost = 35, ClientID = 17, EmployeeID = 7 },
                new Service { Date = DateTime.Parse("18-12-2019"), Cost = 20, ClientID = 30, EmployeeID = 4 },
                new Service { Date = DateTime.Parse("16-12-2019"), Cost = 80, ClientID = 3, EmployeeID = 1 },
                new Service { Date = DateTime.Parse("14-12-2019"), Cost = 220, ClientID = 20, EmployeeID = 3 },
                new Service { Date = DateTime.Parse("15-12-2019"), Cost = 110, ClientID = 24, EmployeeID = 5 },
                new Service { Date = DateTime.Parse("13-01-2020"), Cost = 100, ClientID = 19, EmployeeID = 2 },
                new Service { Date = DateTime.Parse("13-01-2020"), Cost = 350, ClientID = 23, EmployeeID = 7 },
                new Service { Date = DateTime.Parse("13-01-2020"), Cost = 90, ClientID = 30, EmployeeID = 4 },
                new Service { Date = DateTime.Parse("14-01-2020"), Cost = 150, ClientID = 3, EmployeeID = 1 },
                new Service { Date = DateTime.Parse("14-01-2020"), Cost = 280, ClientID = 25, EmployeeID = 3 },
                new Service { Date = DateTime.Parse("14-01-2020"), Cost = 130, ClientID = 16, EmployeeID = 10 }
            };

            foreach (Service d in servise)
            {
                context.Services.Add(d);
            }
            context.SaveChanges();

        }
    }
}
