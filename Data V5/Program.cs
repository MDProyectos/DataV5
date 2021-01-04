using System;
using System.IO;
using System.Text;

namespace Data_V5
{
    class Program
    { 
        static string path = @"C:\Users\Mario David\Desktop\ejercicios\Data V5\Save.txt";
        static void Main(string[] args)
        {
            
            Menu();
            Console.ReadKey();
        }

        private static void Menu()
        {
            Console.Clear();
            bool pass = true;
            Console.WriteLine("Elige la opcion que desea realizar");
            Console.WriteLine("1. Mostrar los registros");
            Console.WriteLine("2. Encontrar un registro");
            Console.WriteLine("3. Agregar un registro");
            Console.WriteLine("4. Salir");
            
            do{
                pass = true;
                string option = Console.ReadLine();
                option = option.ToLower();
                switch(option)
                {
                    case "1":
                        ShowRegisters();
                        break;
                    case "2":
                        FindRegister();
                        break;
                     case "3":
                        AddNewRegister();
                        break;
                    case "4":
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("La opcion no es valida");
                        pass = false;
                        continue;
                }
            }while(!pass);

        }
        private static void FindRegister()
        {
            if (File.Exists(path)) 
            {  
                Console.Clear();
                Console.WriteLine("Pon la cedula del registro que deseas buscar");
                int lineFound = 0;
                string cedula = ReadCedula();
                string[] lines = File.ReadAllLines(path);  
                foreach(string line in lines)
                {  
                    if (line.Contains(cedula))
                    {
                        string[] register = line.Split(",");
                        string decoded = Decode(Convert.ToUInt16(register[5]));
                        register[5] = decoded;
                        foreach(string r in register)
                        {
                            Console.Write(r+",");
                        }
                        Console.WriteLine();
                        lineFound++;
                        break;
                    }
                    lineFound++;
                }
                Console.WriteLine(lineFound);
                Console.WriteLine("1. Editar registro");
                Console.WriteLine("2. Borrar registro");
                Console.WriteLine("3. Salir");
                bool pass = true;
                 do{
                pass = true;
                string option = Console.ReadLine();
                option = option.ToLower();
                switch(option)
                {
                    case "1":
                        EditRegister(lines,lineFound);
                        break;
                    case "2":
                        DeleteRegister(lines,lineFound);
                        break;
                    case "3":
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("La opcion no es valida");
                        pass = false;
                        continue;
                }
            }while(!pass);
            }
        }
        private static void ShowRegisters()
        {
            if (File.Exists(path)) 
            {  
                Console.Clear();
                string[] lines = File.ReadAllLines(path);  
                foreach(string line in lines)
                {
                    string[] register = line.Split(",");
                    string decoded = Decode(Convert.ToUInt16(register[5]));
                    register[5] = decoded;
                    foreach(string r in register)
                    {
                        Console.Write(r+",");
                    }
                    Console.WriteLine();
                }  
            }
            Console.ReadKey();
            Menu();
        }
        private static void AddNewRegister()
        {
            Console.Clear();
            string register = "";
            
            bool pass = true;
            bool pass2 = true;
            do{
                string cedula = ReadCedula();
                string name = ReadName();
                string lastName = ReadLastName();
                int age = ReadAge();
                decimal save = ReadSave();
                string password = ReadPassword();
                string toCode = "";
                Console.WriteLine("Sexo: M|F ");
                do{
                    pass2 = true;
                    string option = ReadChar().ToString();
                    option = option.ToLower();
                    switch(option)
                    {
                        case "m":
                            toCode += option;
                            break;
                        case "f":
                            toCode += option;
                            break;
                        default:
                            Console.WriteLine("La opcion no es valida");
                            pass2 = false;
                            continue;
                    }
                }while(!pass2);
                Console.WriteLine();
                Console.WriteLine("Estado Civil: S|C ");
                do{
                    pass2 = true;
                    string option = ReadChar().ToString();
                    option = option.ToLower();
                    switch(option)
                    {
                        case "s":
                            toCode += option;
                            break;
                        case "c":
                            toCode += option;
                            break;
                        default:
                            Console.WriteLine("La opcion no es valida");
                            pass2 = false;
                            continue;
                    }
                }while(!pass2);
                Console.WriteLine();
                Console.WriteLine("Grado academico: I|M|G|P");
                do{
                    pass2 = true;
                    string option = ReadChar().ToString();
                    option = option.ToLower();
                    switch(option)
                    {
                        case "i":
                            toCode += option;
                            break;
                        case "m":
                            toCode += option;
                            break;
                        case "g":
                            toCode += option;
                            break;
                        case "p":
                            toCode += option;
                            break;
                        default:
                            Console.WriteLine("La opcion no es valida");
                            pass2 = false;
                            continue;
                    }
                }while(!pass2);
                Console.WriteLine();
                int code = ToCode(toCode,age);
                register = cedula + "," + name + "," + lastName + "," + save + "," + password + "," + code;
                pass = true;
                Console.WriteLine("Grabar(G), Continuar(C), Salir(S)?");
                do{
                    pass2 = true;
                    string option = Console.ReadLine();
                    option = option.ToLower();
                    switch(option)
                    {
                        case "g":
                            break;
                        case "c":
                            pass = false;
                            break;
                        case "s":
                            Environment.Exit(1);
                            break;
                        default:
                            Console.WriteLine("La opcion no es valida");
                            pass2 = false;
                            continue;
                    }
                }while(!pass2);
            }while(!pass);

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(path, true))
            {
                file.WriteLine(register);
            }
            Console.WriteLine("Se ha guardado exitosamente.");
            Menu();
        }
        private static void EditRegister(string[] lines, int line)
        {
            Console.Clear();
            string register = "";
            
            bool pass = true;
            bool pass2 = true;
            do{
                string cedula = ReadCedula();
                string name = ReadName();
                string lastName = ReadLastName();
                int age = ReadAge();
                decimal save = ReadSave();
                string password = ReadPassword();
                string toCode = "";
                Console.WriteLine("Sexo: M|F ");
                do{
                    pass2 = true;
                    string option = ReadChar().ToString();
                    option = option.ToLower();
                    switch(option)
                    {
                        case "m":
                            toCode += option;
                            break;
                        case "f":
                            toCode += option;
                            break;
                        default:
                            Console.WriteLine("La opcion no es valida");
                            pass2 = false;
                            continue;
                    }
                }while(!pass2);
                Console.WriteLine();
                Console.WriteLine("Estado Civil: S|C ");
                do{
                    pass2 = true;
                    string option = ReadChar().ToString();
                    option = option.ToLower();
                    switch(option)
                    {
                        case "s":
                            toCode += option;
                            break;
                        case "c":
                            toCode += option;
                            break;
                        default:
                            Console.WriteLine("La opcion no es valida");
                            pass2 = false;
                            continue;
                    }
                }while(!pass2);
                Console.WriteLine();
                Console.WriteLine("Grado academico: I|M|G|P");
                do{
                    pass2 = true;
                    string option = ReadChar().ToString();
                    option = option.ToLower();
                    switch(option)
                    {
                        case "i":
                            toCode += option;
                            break;
                        case "m":
                            toCode += option;
                            break;
                        case "g":
                            toCode += option;
                            break;
                        case "p":
                            toCode += option;
                            break;
                        default:
                            Console.WriteLine("La opcion no es valida");
                            pass2 = false;
                            continue;
                    }
                }while(!pass2);
                Console.WriteLine();
                int code = ToCode(toCode,age);
                register = cedula + "," + name + "," + lastName + "," + save + "," + password + "," + code;
                pass = true;
                Console.WriteLine("Grabar(G), Continuar(C), Salir(S)?");
                do{
                    pass2 = true;
                    string option = Console.ReadLine();
                    option = option.ToLower();
                    switch(option)
                    {
                        case "g":
                            break;
                        case "c":
                            pass = false;
                            break;
                        case "s":
                            Environment.Exit(1);
                            break;
                        default:
                            Console.WriteLine("La opcion no es valida");
                            pass2 = false;
                            continue;
                    }
                }while(!pass2);
            }while(!pass);

            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int currentLine = 1; currentLine <= lines.Length; ++currentLine)
                {
                    if (currentLine == line)
                    {
                        writer.WriteLine(register);
                    }
                    else
                    {
                        writer.WriteLine(lines[currentLine - 1]);
                    }
                }
            }
            Console.WriteLine("Se ha editado exitosamente.");
            Menu();
        }
        private static void DeleteRegister(string[] lines, int line)
        {
           Console.Clear();
           using (StreamWriter writer = new StreamWriter(path))
            {
                for (int currentLine = 1; currentLine <= lines.Length; ++currentLine)
                {
                    if (currentLine == line)
                    {
                        continue;
                    }
                    else
                    {
                        writer.WriteLine(lines[currentLine - 1]);
                    }
                }
            }
            Console.WriteLine("Se ha borrado exitosamente.");
            Menu();
        }
        private static string Decode(int code)
        {
            string decoded = "";
            string grado = "";
            string estado = "";
            string sexo = "";
            if(code == (code|1))
                grado = "Media";
            else if(code == (code|2))
                grado = "Grado";
            else if(code == (code|3))
                grado = "Post-grado";
            else
                grado = "Basica";
            if(code == (code|4))
                estado = "Casado";
            else 
                estado = "Soltero";
            if(code == (code|8))
                sexo = "Femenino";
            else 
                sexo = "Masculino";
            int edad = code >> 4;
            decoded = edad + "," + sexo + "," + estado + "," + grado;
            return decoded;
        }
        private static int ToCode(string toCode,int age)
        {
            int code = 0;
            code = code | age;
            code = code << 4;
            switch(toCode[0].ToString().ToLower())
            {
                case "f":
                    code = code | 8;
                    break;
                case "m":
                    break;
            }
            switch(toCode[1].ToString().ToLower())
            {
                case "c":
                    code = code | 4;
                    break;
                case "s":
                    break;
            }
            switch(toCode[2].ToString().ToLower())
            {
                case "i":
                    break;
                case "m":
                    code = code | 1;
                    break;
                case "g":
                    code = code | 2;
                    break;
                case "p":
                    code = code | 3;
                    break;
            }

            
            return code;
        }
        private static char ReadChar()
        {
            ConsoleKeyInfo key;
            string theChar = "";
            do
                {
                    key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {

                        if (theChar.Length < 1)
                        {
                            theChar = key.KeyChar.ToString();
                            Console.Write(key.KeyChar);
                        }
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && theChar.Length > 0)
                        {
                            theChar = theChar.Substring(0, (theChar.Length - 1));
                            Console.Write("\b \b");
                        }
                    }
                }
                // Stops Receving Keys Once Enter is Pressed
                while (key.Key != ConsoleKey.Enter);
                return theChar[0];
        }
        private static string ReadCedula()
        {
            bool pass = true;
            string cedula = "";
            Console.Write("Escribe la cedula: ");
            ConsoleKeyInfo key;
            do
            {

                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace)
                    {
                        double val = 0;
                        bool _x = double.TryParse(key.KeyChar.ToString(), out val);
                        if (_x)
                        {
                            cedula += key.KeyChar;
                            Console.Write(key.KeyChar);
                        }
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && cedula.Length > 0)
                        {
                            cedula = cedula.Substring(0, (cedula.Length - 1));
                            Console.Write("\b \b");
                        }
                    }
                }
                // Stops Receving Keys Once Enter is Pressed
                while (key.Key != ConsoleKey.Enter);
                if (cedula.Length != 11 )
                {    
                    pass = false;
                    Console.WriteLine("Tiene que ser 11 numeros");
                    continue;
                }
            }while(!pass);
            Console.WriteLine();
            return cedula;
        }
        private static string ReadName()
        {
            bool pass = true;
            string name = "";
            ConsoleKeyInfo key;
            do{
                pass = true;
                Console.WriteLine("Escibe tu nombre:");

                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace)
                    {
                        if(key.Key != ConsoleKey.Enter)
                        {
                            name += key.KeyChar;
                            Console.Write(key.KeyChar);
                        }
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && name.Length > 0)
                        {
                            name = name.Substring(0, (name.Length - 1));
                            Console.Write("\b \b");
                        }
                    }
                }
                // Stops Receving Keys Once Enter is Pressed
                while (key.Key != ConsoleKey.Enter);

                if (name.Length == 0 )
                {    
                    pass = false;
                    Console.WriteLine("No puedes dejarlo vacio");
                    continue;
                }
            }while(!pass);
            Console.WriteLine();
            return name;
            
        }
        private static string ReadLastName()
        {
            bool pass = true;
            string lastName = "";
            ConsoleKeyInfo key;
            do{
                pass = true;
                Console.WriteLine("Escibe tu apellido:");
               
                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace)
                    {
                         if(key.Key != ConsoleKey.Enter)
                        {
                            lastName += key.KeyChar;
                            Console.Write(key.KeyChar);
                        }
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && lastName.Length > 0)
                        {
                            lastName = lastName.Substring(0, (lastName.Length - 1));
                            Console.Write("\b \b");
                        }
                    }
                }
                // Stops Receving Keys Once Enter is Pressed
                while (key.Key != ConsoleKey.Enter);

                if (lastName.Length == 0 )
                {    
                    pass = false;
                    Console.WriteLine("No puedes dejarlo vacio");
                    continue;
                }
            }while(!pass);
            Console.WriteLine();
            return lastName;
        }
        private static int ReadAge()
        {
            bool pass = true;
            string age = "";
            ConsoleKeyInfo key;
            do{
                pass = true;
                Console.WriteLine("Escibe tu edad:");
                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace)
                    {
                        double val = 0;
                        bool _x = double.TryParse(key.KeyChar.ToString(), out val);
                        if (_x)
                        {
                            age += key.KeyChar;
                            Console.Write(key.KeyChar);
                        }
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && age.Length > 0)
                        {
                            age = age.Substring(0, (age.Length - 1));
                            Console.Write("\b \b");
                        }
                    }
                }
                // Stops Receving Keys Once Enter is Pressed
                while (key.Key != ConsoleKey.Enter);
                if (age.Length == 0 )
                {    
                    pass = false;
                    Console.WriteLine("No puede dejarlo vacio");
                    continue;
                }

            }while(!pass);
            Console.WriteLine();
            return Convert.ToUInt16(age);
        }
        private static decimal ReadSave()
        {
            bool pass = true;
            string saving = "";
            ConsoleKeyInfo key;
            decimal save = 0;
            do{
                pass = true;
                Console.WriteLine("Escribe cuanto quieres ahorrar:");
                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace)
                    {
                        if(!saving.Contains(".")){
                            double val = 0;
                            bool _x = double.TryParse(key.KeyChar.ToString(), out val);
                            if (_x)
                            {
                                saving += key.KeyChar;
                                Console.Write(key.KeyChar);
                            }
                        }else if(saving.Contains("."))
                        {
                            string[] dec = saving.Split(".");
                            if(dec[1].Length < 2)
                            {
                                saving += key.KeyChar;
                                Console.Write(key.KeyChar);
                            }
                        }
                        if(key.KeyChar == '.' && !saving.Contains("."))
                        {
                            saving += key.KeyChar;
                            Console.Write(key.KeyChar);
                        }

                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && saving.Length > 0)
                        {
                            saving = saving.Substring(0, (saving.Length - 1));
                            Console.Write("\b \b");
                        }
                    }
                }
                // Stops Receving Keys Once Enter is Pressed
                while (key.Key != ConsoleKey.Enter);
                if (saving.Length == 0 )
                {    
                    pass = false;
                    Console.WriteLine("No puede dejarlo vacio");
                    continue;
                }
                try
                {
                    save = Convert.ToDecimal(saving);
                }catch
                {
                    pass = false;
                    Console.WriteLine("Tiene que ser un numero con un maximo de dos decimales");
                    continue;
                }
            }while(!pass);
            Console.WriteLine();
            return save;
        }
        private static string ReadPassword()
        {ConsoleKeyInfo key;
            bool pass = true;
            string password = "";
            string confirmPassword = "";
            do{
                pass = true;
                Console.WriteLine("Escibe la contraseña:");
               
                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace)
                    {
                        if(key.Key != ConsoleKey.Enter)
                        {
                            password += key.KeyChar;
                            Console.Write("*");
                        }
                        
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                        {
                            password = password.Substring(0, (password.Length - 1));
                            Console.Write("\b \b");
                        }
                    }
                }
                // Stops Receving Keys Once Enter is Pressed
                while (key.Key != ConsoleKey.Enter);

                if (password.Length == 0 )
                {    
                    pass = false;
                    Console.WriteLine("No puede dejarlo vacio");
                    continue;
                }
                if (password.Length < 7 )
                {    
                    pass = false;
                    Console.WriteLine("Tiene que ser tener mas de 6 caracteres.");
                    continue;
                }
                Console.WriteLine();
                Console.WriteLine("Confirme la contraseña:");
               
                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace)
                    {
                        if(key.Key != ConsoleKey.Enter)
                        {
                            confirmPassword += key.KeyChar;
                            Console.Write("*");
                        }
                        
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && confirmPassword.Length > 0)
                        {
                            confirmPassword = confirmPassword.Substring(0, (confirmPassword.Length - 1));
                            Console.Write("\b \b");
                        }
                    }
                }
                // Stops Receving Keys Once Enter is Pressed
                while (key.Key != ConsoleKey.Enter);
                if(password != confirmPassword)
                {
                    pass = false;
                    Console.WriteLine("Las contraseñas no son iguales");
                    continue;
                }

            }while(!pass);
            Console.WriteLine();
            return password;
        }
    }
}


