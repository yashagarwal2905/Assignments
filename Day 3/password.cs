string pwd = "";
  do {
  key = Console.ReadKey(true);
  if(keey.Key != ConsoleKey.Enter)
  {
    strPassword += key.KeyChar;
    Console.Write("*");
  }
  }
  while (key.Key != ConsoleKey.Enter);
