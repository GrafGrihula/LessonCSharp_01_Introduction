using System;
using System.Collections.Generic;
using System.Text;

namespace Staffer
{
    class RandomText
    {
        string[] first = 
        { 
                "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "К", "Л", "М", "Н", "О", 
                "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Э", "Ю", "Я", "Й" 
        };
        string[] medi = 
        { 
            "ав", "бо", "ю", "в", "е", "г", "д", "е", "сёк", "жи", "з", "и", "ки", "о", "л", 
            "ма", "а", "не", "о", "п", "ри", "су", "я", "та", "у", "фе", "у", "хи", "ц", "и", 
            "ч", "е", "ш", "а", "щ", "э", "ю", "я", "й", "ы" 
        };
        string[] lastNameEnd = 
        { 
            "ий", "ай", "ил", "ел", "ей" 
        };
        string[] lastOtchestvoEnd = 
        { 
            "ович", "евич", "лыч", "ныч" 
        };
        string[] lastFamiliyaEnd = 
        { 
            "ов", "ев", "опко", "шин", "дзе", "ян", "швили", "ян" 
        };
        string[] firstEmail = 
        { 
            "qwerty", "uiop", "asdfg", "hjkl", "zxcvb", "nm" 
        };
        string[] lastEmail = 
        { 
            "mail.ru", "yandex.ru", "rambler.ru", "gmail.com" 
        };
        string[] postArr = { 
            "SEO-специалист", "Контент-менеджер", "Копирайтер", "Линкбилдер", 
            "Link-менеджер", "Юзабилист", "Верстальщик", "Модератор", "Web-аналитик", 
            "Тимлид", "Front-end разработчик", "Back-end разработчик", 
            "Embedded-программист" };
        private string familiya;
        private string imya;
        private string otchestvo;
        private string telephone;
        private string age;
        private string email;
        private string salary;
        private string post;

        public string RandomFamiliya()
        {
            Random random = new Random();
            return familiya = first[random.Next(0, 29)] + MediumName() + lastFamiliyaEnd[ random.Next(0, 7)];
        }

        public string RandomName()
        {
            Random random = new Random();
            return imya = first[ random.Next( 0, 29 ) ] + MediumName() + lastNameEnd[ random.Next( 0, 4 ) ];
        }

        public string RandomOtchestvo()
        {
            Random random = new Random();
            return otchestvo = first[ random.Next( 0, 29 ) ] + MediumName() + lastOtchestvoEnd[ random.Next( 0, 3 ) ];
        }

        public string MediumName()
        {
            Random random = new Random();
            string mediumName = null;
            for( int i = 0; i < random.Next( 2, 7 ); i++ )
            {
                mediumName += medi[ random.Next( 0, 39 ) ];
            }
            return mediumName;
        }

        public string RandomTelephone()
        {
            Random random = new Random();
            return telephone = "849" + random.Next( 50000000, 59999999 ).ToString();
        }

        public string RandomAge()
        {
            Random random = new Random();
            return age = random.Next( 1950, 2000 ).ToString();
        }

        public string RandomEmail()
        {
            Random random = new Random();
            return email = firstEmail[ random.Next( 0, 5 ) ] + "@" + lastEmail[ random.Next( 0, 3 ) ];
        }

        public string RandomSalary()
        {
            Random random = new Random();
            return salary = random.Next( 15000, 150000 ).ToString();
        }

        public string RandomPost()
        {
            Random random = new Random();
            return post = postArr[ random.Next( 0, 12 ) ];
        }
    }
}
